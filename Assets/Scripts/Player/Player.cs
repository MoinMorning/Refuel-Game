using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Defines Player Controls
*/
public class Player : MonoBehaviour
{

    [SerializeField]
    private float movementSpeed = 3f;
    float moveVertical;
    float moveHorizontal;
    private Rigidbody2D rb2D;
    Vector2 movement;
    public GameObject health;
    
    public static Player playerStats;
    public int plasma;
    public int hp;
    public int fuel;
    public int maxFuel = 100;

    public Animator animator;
    public Camera cam;
    private Vector2 mousePos;
    
    public GameObject gameOverScreen;
    
    void Awake()
    {
    	if(playerStats != null)
    	{
    	Destroy(playerStats);
    	}
    	else
    	{
    	playerStats = this;
    	}
    	DontDestroyOnLoad(this);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
   }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveHorizontal, moveVertical).normalized;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Animations with the Blend tree
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // change idle when standing still and shooting
        if(mousePos.x < gameObject.transform.position.x && animator.GetFloat("Speed") < 0.01 && !animator.GetBool("left_idle") && Input.GetButton("Fire1")){
            animator.SetBool("left_idle", true);
        }
        else if(animator.GetBool("left_idle") && (animator.GetFloat("Speed") > 0.01 || !Input.GetButton("Fire1") || mousePos.x > gameObject.transform.position.x)){
            animator.SetBool("left_idle", false);
        }
        else if(mousePos.x > gameObject.transform.position.x && animator.GetFloat("Speed") < 0.01 && !animator.GetBool("right_idle") && Input.GetButton("Fire1")){
            animator.SetBool("right_idle", true);
        }
        else if(animator.GetBool("right_idle") && (animator.GetFloat("Speed") > 0.01 || !Input.GetButton("Fire1")|| mousePos.x < gameObject.transform.position.x)){
            animator.SetBool("right_idle", false);
        }

    }

    /*Flip Character while running left or right*/
    void FixedUpdate()
    {
        rb2D.velocity = movement * movementSpeed;
    }

    // What happens if the player gets hit by an Alien 
    private void OnCollisionEnter2D(Collision2D other) {    
        if (other.gameObject.tag == "Alien") {
            Debug.Log("You were hit!");
            FindObjectOfType<AudioManager>().Play("Hit");
            health.GetComponent<Health>().reduceHealth();
        } 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            Items items = collision.gameObject.GetComponent<Items>();
            switch (items.type)
            {
                case "Fuel":
                    if (fuel == maxFuel)
                    {
                        // Rocket can launch now and the game ends.
                        gameOverScreen.SetActive(true);
                        Time.timeScale = 0f;
                    }
                    else
                    {
                        fuel++;
                    }
                    break;
                case "HP":
                    
                    break;
                case "Plasma":
                    
                    break;
            }
            
            Destroy(collision.gameObject);
        }
    }
}
