using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script handles following of the main player
with the camera
*/
public class FollowCharacter : MonoBehaviour
{
    private Transform playerTransform;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // store current cameras position in var temp
        Vector3 temp = transform.position;
        //set cameras position x to be equasl to the players positon x
        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;
        // add offset value to the temp camera x pos
        temp.y += offset;
        temp.x += offset;
        // set cameras temp pos to cameras current pos
        transform.position = temp;

    }
}
