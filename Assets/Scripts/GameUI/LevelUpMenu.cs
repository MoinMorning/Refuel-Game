using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpMenu : MonoBehaviour
{

    public GameObject levelUpMenu;
    public GameObject victoryMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void keepOnPlaying() {
        victoryMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void levelUpSuccessful() 
    {
        levelUpMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
