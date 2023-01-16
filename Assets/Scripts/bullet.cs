using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(1);
        }
        if (collision.gameObject.tag == "Enemy")
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
        if (collision.gameObject.tag == "FBball")
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, 2f);
    }
}
