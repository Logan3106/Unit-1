using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private GameObject levelShift;
    public string destination;
    void Update()
    {
        if(levelShift != null)
        {
            SceneManager.LoadScene(destination);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelShift = collision.gameObject;
        }
    }
}
