 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

 
// SpeedUp : inherited from Item
//  SpeedUp Item is destroyed 4 seconds after it is generated.
 
// public class SpeedUp : Item
// {
// 	       PlayerControl playerControl = playerObject.GetComponent<PlayerControl>();
//     public override void DestroyAfterTime()
//     {
//         Invoke("DestroyObject", 4.0f);
//     }

//     public override void RunItem()
//     {
//         GameObject playerObject = GameObject.Find("Player");
//
//         playerControl.speed *= 3f;

//         DestroyObject();
//     }

//     public void DestroyObject()
//     {
//         Destroy(gameObject);
//     }

   // When they collides, tags are compared. If the tag is Player, the method "RunItem" executes.
//     public void OnCollisionEnter2D(Collision2D col)
//     {
//         if(col.gameObject.CompareTag("Player"))
//         {
 //            RunItem();
   //      }
    //         }
// }
