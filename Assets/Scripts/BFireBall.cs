using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFireBall : MonoBehaviour
{
    float moveSpeed = 3.5f;

    Rigidbody2D rb;
    CombatScript combat;
    PlayerScript target;
    Vector2 moveDirection;
    Shield shieldscript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerScript>();
        shieldscript = GetComponent<Shield>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void OntriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            Debug.Log("Hit!");
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Shield>(out Shield shieldComponent))
        {
            shieldComponent.TakeDamage(1);
        }
        if (collision.gameObject.TryGetComponent<PlayerScript>(out PlayerScript playerComponent))
        {
            playerComponent.TakeDamage(1);
        }
            if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Fball")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }


    }
}
