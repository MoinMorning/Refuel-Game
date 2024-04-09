using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random=UnityEngine.Random;

/*
Defines the Bullet behaviour
-> Collision with aliens
*/
public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    private Vector2 screenBounds;

    PlasmaBar plasmaBar;
  public GameObject fuel_prefab;
  public GameObject hp_prefab;
  public GameObject plasma_prefab;
    

    void Start(){
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        plasmaBar = (PlasmaBar) GameObject.Find("EnergyBar").GetComponent<PlasmaBar>();
    }

    /*
    void Update(){
        if ((-transform.position.y > screenBounds.y * 4) ||
                (transform.position.y > screenBounds.y * 2) ||
                    (-transform.position.x > screenBounds.x * 4) ||
                        (transform.position.x > screenBounds.x * 2) ) {
            Destroy(this.gameObject);
        }
    }*/
    
    // Start is called before the first frame update
    /*
    -> Collision with aliens: Reduce alien health or destroy game object
    */
    void OnCollisionEnter2D(Collision2D collision){
        GameObject gameEffect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameEffect, .4f);
        Destroy(gameObject);
        if(collision.gameObject.tag == "Alien")
        {
            Alien alien = collision.gameObject.GetComponent<Alien>();
            alien.reduceHealth(1);
            if (alien.getHealth() < 1) 
            {
                int ran = Random.Range(0, 10);
                if (ran < 3)
                {
                    // 30% : No item is droped.
                    Debug.Log("No item is droped.");
                }
                else if (ran < 4)
                {
                    // 10% : Droprate for Fuel.
                    Destroy(collision.gameObject);
                    Instantiate(fuel_prefab,transform.position, Quaternion.identity);
                    plasmaBar.addPlasma(1);
                }
                else if (ran < 7)
                {
                    // 30% : Droprate for HP.
                    Destroy(collision.gameObject);
                    Instantiate(hp_prefab,transform.position, Quaternion.identity);
                    plasmaBar.addPlasma(1);
                }
                else if (ran < 10)
                {
                    // 30% : Droprate for Plasma.
                    Destroy(collision.gameObject);
                    Instantiate(plasma_prefab,transform.position, Quaternion.identity);
                    plasmaBar.addPlasma(1);
                }
            
            }
            
        }        
    }
}
