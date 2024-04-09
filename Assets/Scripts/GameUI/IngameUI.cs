using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameUI : MonoBehaviour
{

    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape") && !pauseMenu.activeSelf) {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        } else if (Input.GetKeyDown("escape")) {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
