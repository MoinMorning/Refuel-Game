using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // TODO: Possible use this to control Waves and all other info
    public static GameManager Instance;
    // Start is called before the first frame update

    public PlasmaBar plasmaBar;

    public void setplasmaBar(PlasmaBar plasmaBar) {
        this.plasmaBar = plasmaBar;
    }
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public enum GameState {
        READY_SCREEN,
        WAVE,
        LEVELUP,
        VICTORY
    }

}
