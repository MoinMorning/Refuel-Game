using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddArrow : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private GameObject arrow;
    private GameObject rocket;
    private Vector3 rocket_position;
    private Vector3 player_position;
    // Start is called before the first frame update
    void Start()
    {   // Get rocket and arrow
        rocket = GameObject.FindGameObjectWithTag("Rocket");
        arrow = Instantiate(arrow) as GameObject;
        arrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        rocket_position = rocket.transform.position;
        Vector3 viewPos = cam.WorldToViewportPoint(rocket_position);
        // set active if not visible
        if (viewPos.x > 0 && viewPos.x < 1 && viewPos.y > 0 && viewPos.y < 1)
        {
            arrow.SetActive(false);
        }
        else{
            arrow.SetActive(true);
            player_position = gameObject.transform.position;   
            // Rotate fixedShooting point towards the mouseButton
            Vector2 lookDir = player_position - rocket_position;
            arrow.transform.position = new Vector3(lookDir.x, lookDir.y, 0);
            // position at delta percentage
            arrow.transform.position = new Vector3(rocket_position.x + (player_position.x - rocket_position.x) * 2 / 3,
                                                                        rocket_position.y + (player_position.y - rocket_position.y) * 2 / 3, 0);
            // rotate accordingly
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -180f;
            arrow.transform.rotation = Quaternion.Euler(arrow.transform.rotation.x, arrow.transform.rotation.y, angle);
        }
    }
}
