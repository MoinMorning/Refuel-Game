using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Lightning : MonoBehaviour
{

    public GameObject hitEffect;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player") {
        GameObject gameEffect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameEffect, .4f);
        Destroy(gameObject);
        Player player = collision.gameObject.GetComponent<Player>();
        Health health = GameObject.FindObjectOfType<Health>();
        health.reduceHealth();
        } else {
            if(collision.gameObject.tag != "Alien") {
            GameObject gameEffect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameEffect, .4f);
            Destroy(gameObject);
            }     
        }   
    }
}
