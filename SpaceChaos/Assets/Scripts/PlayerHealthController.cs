using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private Animator playerExplosionEffect;

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
            AudioManager.Instance.musicSource.Stop(); // Stop the background music after player is dead
            AudioManager.Instance.PlaySFX("Explosion"); // Play the explosion sound effect
            isAlive = false;
            rb.simulated = false;
            GameObject effect = Instantiate(playerExplosionEffect.gameObject, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
            Destroy(gameObject, 0.5f);
        }
    }

    // Return the Player Alive Status
    public bool IsAlive { get { return isAlive; } }
}
