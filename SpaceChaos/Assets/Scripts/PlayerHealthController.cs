using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    private int health;
    private bool isAlive;
    private Rigidbody2D rb;
    void Start()
    {
        health = 3;
        isAlive = true;
        rb = GetComponent<Rigidbody2D>();   
    }

    public void TakeDamage()
    {
        // Take damage and reduce player health
        health--;
        if (health > 0)
        {
            Debug.Log("Current Player health: " + health);
        }
        else
        {
            isAlive = false;
            Debug.Log("Player Died");
            rb.simulated = false;
            Destroy(gameObject, 2f);
        }
    }

    // Return the Player Alive Status
    public bool IsAlive { get { return isAlive; } }
}
