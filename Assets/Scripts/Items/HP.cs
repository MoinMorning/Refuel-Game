// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//  
// public class HP : Item
// {
//     public override void DestroyAfterTime()
//     {
//         Invoke("DestroyObject", 4.0f);
//     }
//
//     public override void RunItem()
//     {
//         DestroyObject();
//
//     }
//
//     public void DestroyObject()
//     {
//         Destroy(gameObject);
//     }
//
//     public void OnCollisionEnter2D(Collision2D col)
//     {
//         if(col.gameObject.CompareTag("Player"))
//         {
//             RunItem();
//         }
//     }
//
//
//
//     public void OnCollisionEnter2D(Collision2D col)
//     {
//          
//         if(col.gameObject.tag == "Player")
//         {
//
//         }
//     }
// }