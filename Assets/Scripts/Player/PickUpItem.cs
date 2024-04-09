using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
	public int q;
	public enum pickupObject{PLASMA,FUEL,HP};
	public pickupObject current;

	void OnTriggerEnter2D(Collider2D other){
		if(other.name == "Plasma")
			print(other);
		{
			if(current == pickupObject.PLASMA)
			{
				Player.playerStats.plasma +=q;
				Debug.Log(Player.playerStats);
			}
			else if(current == pickupObject.FUEL){
				Player.playerStats.fuel +=q;
				Debug.Log(Player.playerStats.fuel);
			}
			else if(current == pickupObject.HP){
				Player.playerStats.hp +=q;
				Debug.Log(Player.playerStats.hp);
			}
			Destroy(gameObject);
		}


	}
}
