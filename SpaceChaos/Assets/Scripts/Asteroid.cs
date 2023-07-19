using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    //[SerializeField] private GameObject explosionEffect;

    private int asteroidHealth;

    private void Start()
    {
        asteroidHealth = 3;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealthController>() != null)
        {
            PlayerHealthController playerHealthController = collision.gameObject.GetComponent<PlayerHealthController>();
            playerHealthController.TakeDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // when bullet hits asteroid, decrease its health by 1
        asteroidHealth--;
        if (asteroidHealth < 0)
        {
            Destroy(gameObject);
        } 
    }

    private void OnBecameInvisible()
    {
        // This method destroys the gameobjects once they are no longer being rendered by the main camera
        Destroy(gameObject);
    }
}
