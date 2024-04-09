using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlasmaBar : MonoBehaviour
{
    private int difficulty = 1;
    public Slider plasmaBar;
    private int maxPlasma = 100;
    public GameObject levelUpMenu;
    public GameObject keepOnPlayingButton;

    public GameObject victoryMenu;
    private int currentPlasma;
    public GameObject player;

    private int level = 0;

    Shooting shooting;
    // Start is called before the first frame update
    void Start()
    {
        victoryMenu.SetActive(false);
        levelUpMenu.SetActive(false);
        currentPlasma = 0;
        plasmaBar.maxValue = maxPlasma;
        plasmaBar.value = 0;
        shooting = player.GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        plasmaBar.value = currentPlasma;
    }

    /*
    Adds p Plasma to the Counter and Slider, once currentPlasma reaches 100, triggers LevelUp
    */
    public void addPlasma(int p) {
        this.currentPlasma = currentPlasma + p * 10 * difficulty;
        if (currentPlasma >= 100) {
            currentPlasma = 0;
            levelUp();
        }
    }

    	/*
        Decreases Firerate Restriction of Player by 5% and launches levelUpMenu
        */
    private void levelUp() {
        Time.timeScale = 0f;

        level++;
        
        shooting.changeFireRate(0.1f);

        if (level == 20) {  
            victoryMenu.SetActive(true);
        } else {
            levelUpMenu.SetActive(true);
        }
    }

    public void resumeGame() {
        levelUpMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void keepOnPlaying() {
        victoryMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void gameOver() {
        
    }
}
