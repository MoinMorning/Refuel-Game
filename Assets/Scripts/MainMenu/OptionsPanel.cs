using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour
{
    bool audioToggle;
    public GameObject optionsPanel;
    public TextMeshProUGUI soundButtonText;
    // Start is called before the first frame update
    void Start()
    {
        if (AudioListener.volume == 0) {
            audioToggle = true;
            soundButtonText.SetText("Sound On");
        } else {
            audioToggle = false;
            soundButtonText.SetText("Sound Off");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void soundOnOff() {
        if (audioToggle) {
            AudioListener.volume = 1;
            soundButtonText.SetText("Sound Off");
            audioToggle = false;
        } else {
            AudioListener.volume = 0;
            soundButtonText.SetText("Sound On");
            audioToggle = true;
        }
    }

    public void back() {
        optionsPanel.SetActive(false);
    }
    }
