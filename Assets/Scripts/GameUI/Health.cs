using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private int health = 100000;

    public TextMeshProUGUI tmpHealth;
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        tmpHealth.text = "Health: " + health;        
    }

    public void changeHealth(int h) {
        health = health + h;
    }

    
    public void reduceHealth() {
        changeHealth(-1);
        if (health <= 0) {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void increaseHealth()
    {
        changeHealth(1);
    }

    public void lose(){
    
}
}
