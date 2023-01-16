using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float health, maxHealth = 3f;
    public GameObject bfireball;

    float fireRate;
    float nextFire;
    public bool bossDead = false;
    public GameObject fireball;
    public float move;
    int count;
    



    private void Start()
    {
        
        count = 0;
        fireRate = 3f;
        nextFire = Time.time;
        health = maxHealth;
        InvokeRepeating("SpawnObject",3, 3);
        
    }
    
    void SpawnObject()
    {
        Instantiate(fireball, new Vector2(-17, -1), Quaternion.identity);
    }

    void Update()
    {
        CheckIfTimeToTimeFire();
    }

    void CheckIfTimeToTimeFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bfireball, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerScript>(out PlayerScript playerComponent))
        {
            playerComponent.TakeDamage(1);
        }
    }


}
