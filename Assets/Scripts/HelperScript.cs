using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperScript : MonoBehaviour
{
    LayerMask platformLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        platformLayerMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    public void FlipObject(bool flip)

    {
        // get the SpriteRenderer component
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    public bool DoRayCollisionCheck()
    {
        float rayLength = 0.28f;

        //cast a ray downward of length 1
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, rayLength, platformLayerMask);

        Color hitColor = Color.white;


        hit = Physics2D.Raycast(transform.position, -Vector2.up, rayLength, platformLayerMask);

        Debug.DrawRay(transform.position, -Vector2.up * rayLength, (hit.collider != null) ? Color.green : Color.white);

        return hit.collider != null;
        // draw a debug ray to show ray position
        Debug.DrawRay(transform.position, -Vector2.up * rayLength, hitColor);
}   }
