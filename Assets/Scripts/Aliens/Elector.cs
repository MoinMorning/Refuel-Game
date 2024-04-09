using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;

public class Elector : Alien
{
    private int health = 5;
    private float speed = 10f;

    private float nextShot = 0f;

    private float fireRate = 1f;

    private Vector2 movement;
    private Transform player;

    private Rigidbody2D rb2D;

    GameObject lightning;

    float lightningSpeed = 20f;

    private bool facingRight = true;

    public GameObject lightningPrefab;

    public override int getHealth()
    {
        return health;
    }

    public override void reduceHealth(int i)
    {
        this.health = health - i;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("character").transform;
        rb2D = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        float alien_x = gameObject.transform.position.x;
        float player_x = player.transform.position.x;

        // alien left, player right
        if((alien_x  < player_x) && !facingRight){
            Flip();
        }

        // alien right, player left
        else if((alien_x  > player_x) && facingRight){
            Flip();
        }
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction){
        if ((Vector3.Distance(player.transform.position,rb2D.transform.position) < 10)) 
        {
            if ((nextShot < Time.time)) {
                Shoot();
                nextShot = Time.time + fireRate;
            }
        } 
        else 
        {
            rb2D.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
    }

    void Shoot() {
        FindObjectOfType<AudioManager>().Play("GunShot");

        Vector2 direction = (Vector2) player.position - (Vector2) transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90f;
        rb2D.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y,angle);

        lightning = Instantiate(lightningPrefab, rb2D.position, transform.rotation);
        Rigidbody2D rb = lightning.GetComponent<Rigidbody2D>();
        rb.AddForce(rb2D.transform.up * lightningSpeed, ForceMode2D.Impulse);
    }
}
