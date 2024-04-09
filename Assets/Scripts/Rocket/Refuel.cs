using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refuel : MonoBehaviour
{
	public int fuel = 0;
	public int count = 10;
	private Rigidbody2D rocket;
    // Start is called before the first frame update
    void Start()
    {
        rocket = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void refuel(int count){
    count = count + 10;
}
	public void full(){
	if(count == 100){
	finish();
 }
  }
 	void finish(){
 	
 	}
  }
