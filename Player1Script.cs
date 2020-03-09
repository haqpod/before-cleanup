using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Script : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public Healthbar healthbar;

    public float speed;
    public float rightScreenEdge;
    public float leftScreenEdge;
    public float bottomScreenEdge;
    public float topScreenEdge;
    public Transform P1Explosion;
    public GameObject playerone;
   
    public bool inPlay;
    public GameManager gm;
    public Rigidbody2D rb;

    public bool gameOver;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Cursor.visible = false;

        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
      
        if (gm.gameOver)
        {
            return;
        }
        // left right movement
        {
            float horizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);
            // this makes left and right screen edge block player
            if (transform.position.x < leftScreenEdge)
            {
                transform.position = new Vector2(leftScreenEdge, transform.position.y);
            }
            if (transform.position.x > rightScreenEdge)
            {
                transform.position = new Vector2(rightScreenEdge, transform.position.y);
            }
        }
    

        // up down movement and block player from going out of top and bottom of canvas
        {
            float vertical = Input.GetAxis("Vertical");
            transform.Translate(Vector2.up * vertical * Time.deltaTime * speed);
            if (transform.position.y < bottomScreenEdge)
            {
                transform.position = new Vector2(transform.position.x, bottomScreenEdge );
            }
            if (transform.position.y > topScreenEdge)
            {
                transform.position = new Vector2(transform.position.x, topScreenEdge);
            }

        }

 

    }
    void OnTriggerEnter2D(Collider2D other)
    { 
         if (other.CompareTag("boss"))
         {
            Transform newExplosion = Instantiate(P1Explosion, transform.position, transform.rotation);
            Destroy(newExplosion.gameObject, 1.5f);
            Destroy(playerone);
            TakeDamage(10);
            gm.UpdateLives(-100);
            gameOver = true;
         }

         else if(other.CompareTag("bossProjectile1"))
         {
            TakeDamage(1);
            
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Transform newExplosion = Instantiate(P1Explosion, transform.position, transform.rotation);
            Destroy(newExplosion.gameObject, 1.5f);
            Destroy(playerone);
            gm.UpdateLives(-1);     
        }
    }
}


