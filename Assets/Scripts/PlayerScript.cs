using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;
    Rigidbody2D rb;
    public int attackDamage = 20;
    public float attackRange = 1f;
    HelperScript helper;
    Shield shieldScript;
    [SerializeField] float health, maxHealth = 10f;
    bool isGrounded;
    bool isJumping;
    public 

     Vector3 PlayerRespawn { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

        helper = gameObject.AddComponent<HelperScript>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        helper.DoRayCollisionCheck();
        CheckForLanding();
        isGrounded = helper.DoRayCollisionCheck();


        Vector2 vel = rb.velocity;

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded == true))
        {
            isJumping = true;
            vel.y = 10;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //rb.velocity = new Vector2(-10, 0);
            vel.x = -2.5f;
            helper.FlipObject(true);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //rb.velocity = new Vector2(10, 0);
            vel.x = 2.5f;
            helper.FlipObject(false);
        }
        rb.velocity = vel;
    }

    void CheckForLanding()
    {
        if ((isJumping == true) && isGrounded && rb.velocity.y <= 0)
        {
            isJumping = false;
        }
    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
    }

    private Transform GetTransform()
    {
        return transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Health")
        {
            health = health + 2;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "HealthBoost")
        {
            health = health + 5;
            maxHealth = maxHealth + 3;
            Destroy(collision.gameObject);
        }

    }
}
