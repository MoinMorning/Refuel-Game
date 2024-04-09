using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

/*MainMenu behaviour, skip, start, options*/
public class MainMenu : MonoBehaviour
{

    public string loadingScreen;
    public string mainMenu;

    public GameObject optionsPanel;

    // Start is called before the first frame update
    void Start()
    {
        optionsPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame() 
    {
        SceneManager.LoadScene(loadingScreen);
    }

    public void openOptions() 
    {
        optionsPanel.SetActive(true);
    }

    public void quitGame() 
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
