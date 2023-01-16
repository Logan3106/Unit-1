using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoke : MonoBehaviour
{
    public GameObject health;

    void Start()
    {
        Invoke("SpawnObject", 5);
    }

    // Update is called once per frame
    void SpawnObject()
    {
       Instantiate(health, new Vector2 (-25, 0), Quaternion.identity);
    }
}
