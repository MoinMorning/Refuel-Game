using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 movement;
        public Transform instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = GameObject.Find("rocket").transform;
        rb2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
