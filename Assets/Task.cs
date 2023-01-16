using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(MyCoroutine());
    }
    IEnumerator MyCoroutine()
    {
        int i = 0;

        while (i < 5)
        {
            Debug.Log(rb.velocity = new Vector2(-3, 0));
            yield return new WaitForSeconds(2);
            Debug.Log(rb.velocity = new Vector2(3, 0));
            yield return new WaitForSeconds(0.5f);
            Debug.Log(rb.velocity = new Vector2(0, 0));
            yield return new WaitForSeconds(0.5f);
            i++;
        }
    }
}
