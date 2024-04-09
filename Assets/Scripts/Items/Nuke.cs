using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script for the nuke ability
public class Nuke : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject hitEffect;
    [SerializeField]
    private float speed = 40f;
    [SerializeField]
    private GameObject nuke;
    private GameObject nuke_clone;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Sprite NukeReady;
    [SerializeField]
    private Sprite NukeReloading;
    private Vector2 mousePos;
    private Vector3 destination;
    private bool move_to_cursor = false;
    void Start()
    {
        // Wait for nuke ready
        StartCoroutine(NukeWait());
    }

    // Update is called once per frame
    void Update()
    {

        // wait until nuke triggered
        if(move_to_cursor){
            if(nuke_clone.transform.position != destination){
                // Until it reaches the destination
                nuke_clone.transform.position = Vector3.MoveTowards(nuke_clone.transform.position, destination, speed * Time.deltaTime);
            }
            else{
                // Destory and play effect
                Destroy(nuke_clone);
                move_to_cursor = false;
                GameObject gameEffect = Instantiate(hitEffect, destination, Quaternion.identity);
                Destroy(gameEffect, 1f);
            }
        }

        // if ready, start creating the nuke, with relative position to mouse, and y offset
        if(GetComponent<Image>().sprite == NukeReady){
            if(Input.GetMouseButtonDown(1)) {
                mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
                nuke_clone = Instantiate(nuke) as GameObject;
                nuke_clone.transform.position = new Vector3(mousePos.x, mousePos.y + 30, 0);
                destination = new Vector3(mousePos.x, mousePos.y, 0);
                move_to_cursor = true;

                // Play sound and change sprite on nuke
                FindObjectOfType<AudioManager>().Play("Nuke");
                GetComponent<Image>().sprite = NukeReloading;
                StartCoroutine(NukeWait());
            }
        }
        
    }

    // wait for ability ready
    private IEnumerator NukeWait(){
        yield return new WaitForSeconds(10);
        GetComponent<Image>().sprite = NukeReady;
    }
}