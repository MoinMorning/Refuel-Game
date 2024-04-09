using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*LoadingScreen behaviour, skip to game*/
public class LoadingScreen : MonoBehaviour
{

    public string gameScreen;
    public string loadingScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void skipStory() 
    {
        SceneManager.LoadScene(gameScreen);
    }

}
