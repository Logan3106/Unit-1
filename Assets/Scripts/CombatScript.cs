using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CombatScript : MonoBehaviour
{
    public float coolDown = 1;
    public float timeFromShot = 0;
    public int ammo;
    public GameObject fireball;
    PlayerScript playerScript;
    public GameObject shield;
    public GameObject shield1;
    private Animator anim;
    void Start()
    {
        ammo = 20;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Attack", false);
        if (ammo > 0)
        {
            if(Time.time > timeFromShot)
            {
                int moveDirection = 1;
                if (Input.GetMouseButtonDown(0))
                {
                    print("ability used, cooldown started");
                    timeFromShot = Time.time + coolDown;
                    // Instantiate the bullet at the position and rotation of the player
                    GameObject clone;
                    clone = Instantiate(fireball, transform.position, transform.rotation);

                    // get the rigidbody component
                    Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

                    // set the velocity
                    rb.velocity = new Vector3(15 * moveDirection, 0, 0);

                    // set the position close to the player
                    rb.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);

                    ammo--;
                    anim.SetBool("Attack", true);

                    if (Input.GetKey(KeyCode.A))
                    {
                        rb.transform.position = new Vector3(transform.position.x + -1, transform.position.y, transform.position.z);
                        rb.velocity = new Vector3(-15 * moveDirection, 0, 0);
                    }
                    else
                    {
                        rb.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                        rb.velocity = new Vector3(15 * moveDirection, 0, 0);
                    }
                }
            }
        }
        
    }
    public void ShieldDetector(bool Shield)
    {
        if (Input.GetMouseButton(1))
        {
            shield.GetComponent<SpriteRenderer>().enabled = true;
            print("shield on");
        }
        else
        {
            shield.GetComponent<SpriteRenderer>().enabled = false;
            Shield = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Amunition")
        {
            ammo = ammo + 10;
            Destroy(collision.gameObject);
        }
    }

}
