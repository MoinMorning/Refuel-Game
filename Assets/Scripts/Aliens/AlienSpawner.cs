using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;

public class AlienSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Brainiac;
    [SerializeField]
    private GameObject Scuttler;
    [SerializeField]
    private GameObject Elector;
    private const int RAND_RANGE = 10;
    [SerializeField]
    private float respawnTime = 2.0f;

    public List<Transform> spawnPoints;

    public TextMeshProUGUI waveCounter;
    private IEnumerator coroutine;

    private Wave wave;
    private Vector2 screenBounds;
    void Start() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        wave = new Wave();
        coroutine = AlienWave();
        StartCoroutine(coroutine);
        StartCoroutine(FlashText());
    }

    /*
    Restart Coroutine spawning Aliens once all GameObjects of Tag "Alien" are gone
    */
    void Update() {
        if(GameObject.FindGameObjectsWithTag("Alien").Length == 0) {
            StartCoroutine(coroutine);
            waveCounter.text = "WAVE: " + wave.getWave();
            StartCoroutine(FlashText());
        }

    }

    /* 
    Spawn ( Sqrt( Number of waves ) + 1 ) aliens of Random Types within this wave at a Random Spawnpoint each 
    until all current Aliens in Wave are exhausted
    */

    void SpawnAlien(){
        ArrayList alienInstances = new ArrayList();
        bool waveOver = false;
        int sum = wave.getCurrentEnemies().Sum();
        if (sum > 0) {
        int spawnCount = (int) Math.Sqrt(double.Parse(wave.getWave())) + 1;
        if (spawnCount > sum) {
            spawnCount = sum;
        }
            while (spawnCount > 0) {
                int enemyType = 0;
                enemyType = UnityEngine.Random.Range(0,3);
                while (wave.getCurrentEnemies()[enemyType] == 0) 
                {
                    enemyType++;
                    if (enemyType > 2)
                    {
                        enemyType = 0;
                    }
                }
                switch (enemyType) 
                {
                    case 0: 
                    
                        alienInstances.Add(Instantiate(Scuttler) as GameObject);
                        wave.spawnedCurrentScuttlers(1);
                        spawnCount --;
                        break;
                    
                    case 1:
                    
                        alienInstances.Add(Instantiate(Brainiac) as GameObject);
                        wave.spawnedCurrentBrainiacs(1);                
                        spawnCount --;
                        break;

                    case 2:

                        alienInstances.Add(Instantiate(Elector) as GameObject);
                        wave.spawnedCurrentElectors(1);
                        spawnCount --;
                        break;

                    default: 
                    
                    Debug.Log("Error spawning enemies");
                    StopCoroutine(coroutine);
                    break;
                    
                }                
            }
        } else {
            waveOver = true;
        }

        if (!waveOver) {
            // float x;
            // if (UnityEngine.Random.Range(0, 2) == 0)
            // {
            //     x = UnityEngine.Random.Range(-RAND_RANGE - screenBounds.x, -screenBounds.x + 1);
            // } 
            // else
            // {
            //     x = UnityEngine.Random.Range(screenBounds.x + 1, screenBounds.x + RAND_RANGE);
            // }
            // float y;
            // if (UnityEngine.Random.Range(0, 2) == 0)
            // {
            //     y = UnityEngine.Random.Range(-RAND_RANGE - screenBounds.y, -screenBounds.y - 1);
            // } 
            // else
            // {
            //     y  = UnityEngine.Random.Range(screenBounds.y + 1, screenBounds.y + RAND_RANGE);
            // }
            Debug.Log("Spawning " + alienInstances.Count + " aliens");
            foreach (GameObject alienToSpawn in alienInstances) 
            {
            Transform spawnPoint = spawnPoints[UnityEngine.Random.Range(0,spawnPoints.Count())].transform;
            alienToSpawn.transform.position = (spawnPoint.position);
            }
        } else {
            wave.waveUp();
            StopCoroutine(coroutine);
        }
    }

    /* 
    Coroutine to Spawn waves every ( respawnTime / Sqrt(WaveCounter) + 1 ) seconds
    */
    private IEnumerator AlienWave(){
        while(true){
            yield return new WaitForSeconds(respawnTime  / (float) (Math.Sqrt(float.Parse(wave.getWave()) + 1)) + 1);
            SpawnAlien();
        }
    }

    /*
    Make WaveText flash in GameUI
    */
    private IEnumerator FlashText()
    {
        int textBlink = 5;
        while (textBlink > 0)
        {
            waveCounter.enabled = false;
            yield return new WaitForSeconds(.2f);
            waveCounter.enabled = true;
            yield return new WaitForSeconds(.2f);
            textBlink --;
        }
    }
}
