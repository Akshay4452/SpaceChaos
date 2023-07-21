using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 20f;

    private float destroyTime = 5f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (GetComponent<PlayerHealthController>().IsAlive)
            {
                // Shoot the bullets only if the player is alive
                ShootBullet();
            }
            else
            {
                Debug.Log("Can't Fire, Player is Dead");
            }
        }
    }

    private void ShootBullet()
    {
        AudioManager.Instance.PlaySFX("Shoot");  // Play the bullet shooting sound
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, destroyTime);
    }
}
