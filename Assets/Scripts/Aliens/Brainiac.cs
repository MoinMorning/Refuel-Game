using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;

public class Brainiac : Alien
{
    [SerializeField]
    private float speed = 15f;

    private int health = 1;
    private float waiting = 0f;
    private Rigidbody2D rb2D;
    private Vector2 movement;

    public Transform player;
    
    public GameObject itemFuel;
    public GameObject itemHP;
    public GameObject itemPlasma;
    
    private bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("character").transform;
        rb2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position -transform.position;
        direction.Normalize();
        movement = direction;
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
        if (waiting < 10) {
            waiting += 1f;
        } else {
        rb2D.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
            waiting += 1f;
            if (waiting > 30f) {
                waiting = 0f;
            }
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    public override void reduceHealth(int i)
    {
        this.health = health - i;
    }

    public override int getHealth()
    {
        return this.health;
    }
    
    public void OnHit()
    {
        if (health <= 0)
        {
            return;
        }
        
        if (health <= 0)
        {
            int ran = Random.Range(0, 10);
            if (ran < 3)
            {
                // 30% : No item is droped.
                Debug.Log("No item is droped.");
            }
            else if (ran < 4)
            {
                // 10% : Droprate for Fuel.
                Instantiate(itemFuel, transform.position, itemFuel.transform.rotation);
            }
            else if (ran < 7)
            {
                // 20% : Droprate for HP.
                Instantiate(itemHP, transform.position, itemHP.transform.rotation);
            }
            else if (ran < 10)
            {
                // 40% : Droprate for Plasma.
                Instantiate(itemPlasma, transform.position, itemPlasma.transform.rotation);
            }

            Destroy(gameObject);
        }
    }
}
