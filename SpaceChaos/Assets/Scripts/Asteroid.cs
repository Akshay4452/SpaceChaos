using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private Animator hitEffect;
    [SerializeField] private Animator explosionEffect;
    [SerializeField] private ScoreHandler scoreHandler;

    private int hitScore;
    private int explosionScore;

    private int asteroidHealth;

    private void Start()
    {
        asteroidHealth = 2;
        hitScore = 1; // After hitting asteroid, increase score by 1
        explosionScore = 10; // After destroying asteroid, increase score by 10
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
            AudioManager.Instance.PlaySFX("Explosion");
            // Update the score
            ScoreHandler.Instance.UpdateScore(explosionScore);
            GameObject effect = Instantiate(explosionEffect.gameObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(effect, 1f);
        }
        else
        {
            AudioManager.Instance.PlaySFX("Hit");
            ScoreHandler.Instance.UpdateScore(hitScore);
            GameObject effect = Instantiate(hitEffect.gameObject, this.transform);
            Destroy(effect, 0.5f);
        }
    }

    private void OnBecameInvisible()
    {
        // This method destroys the gameobjects once they are no longer being rendered by the main camera
        Destroy(gameObject);
    }
}
