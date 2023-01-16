using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shield : MonoBehaviour
{
    PlayerScript playerScript;
    bool shield;
    [SerializeField] float shieldhealth, shieldmaxHealth = 5f;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = gameObject.AddComponent<PlayerScript>();
        shield = false;

    }
    public void TakeDamage(float damageAmount)
    {
        shieldhealth -= damageAmount;
        if (shieldhealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeHealh(float healAmount)
    {
        shieldhealth = shieldmaxHealth;
    }
}
