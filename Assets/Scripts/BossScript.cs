using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossScript : MonoBehaviour
{
    public Enemy enemyScript;

    void Update()
    {
        if (enemyScript.health <= 0)
        {
            enemyScript.bossDead = true;
        }

        if (enemyScript.bossDead == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Destroy(gameObject);
        }
    }
}
