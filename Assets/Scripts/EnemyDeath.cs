using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Enemy enemyScript;

    private void Update()
    {
        if (enemyScript.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}    
