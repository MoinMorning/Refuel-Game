using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private PlasmaBar plasmaBar;
    void Start()
    {
        plasmaBar = (PlasmaBar) GameObject.Find("EnergyBar").GetComponent<PlasmaBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Reduce all the health of an alien if it gets hit by the nuke
    // Remove it afterwards
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Alien")
        {
            Alien alien = collision.gameObject.GetComponent<Alien>();
            alien.reduceHealth(10);
            if (alien.getHealth() < 1) 
            {
                Destroy(collision.gameObject);
                plasmaBar.addPlasma(1);
            }
        }        
    }
}
