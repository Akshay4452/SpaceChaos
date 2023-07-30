using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private Animator playerExplosionEffect;

    [SerializeField] private int health;
    private bool isAlive;
    private Rigidbody2D rb;
    void Start()
    {
        isAlive = true;
        rb = GetComponent<Rigidbody2D>();   
    }

    public void TakeDamage()
    {
        // Take damage and reduce player health
        health--;
        if (health == 0)
        {
            AudioManager.Instance.musicSource.Stop(); // Stop the background music after player is dead
            AudioManager.Instance.PlaySFX("Explosion"); // Play the explosion sound effect
            isAlive = false;
            rb.simulated = false;
            GameObject effect = Instantiate(playerExplosionEffect.gameObject, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
            AudioManager.Instance.PlaySFX("GameOver");
            AudioManager.Instance.SetMusicStatus(false);
            Invoke(nameof(GameOver), 2f);
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(3);
    }

    // Return the Player Alive Status
    public bool IsAlive { get { return isAlive; } }
}
