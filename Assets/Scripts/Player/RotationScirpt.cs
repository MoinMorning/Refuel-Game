using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Handles Rotation of the Shooting Point */
public class RotationScirpt : MonoBehaviour
{
    public Camera cam;
    public GameObject rb;
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per fixed intervall
    void FixedUpdate()
    {
        // Rotate fixedShooting point towards the mouseButton
        Vector2 lookDir = mousePos - (Vector2)rb.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        rb.transform.rotation = Quaternion.Euler(rb.transform.rotation.x, rb.transform.rotation.y,angle);
    }
}
