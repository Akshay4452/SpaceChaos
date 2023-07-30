using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidPrefabs;
    [SerializeField] private float spawnRate = 1.5f;
    [SerializeField] private Vector2 forceRange; // Min and Max magnitude of the force applied to asteroid rigidbody

    private float timer;
    private Camera mainCamera; // Instantiating main camera for viewport to world space conversion

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnAsteroid();
            timer = spawnRate;
        }
    }

    private void SpawnAsteroid()
    {
        // side variable is for deciding side of Viewport rectangle [0,1,2,3] with 0 = y-axis, 1 = x-axis
        // Viewport rectangle is used for spawning asteroids from randomly selected sides
        int side = Random.Range(0, 4);

        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;

        switch (side)
        {
            case 0:
                spawnPoint.x = 0;
                spawnPoint.y = Random.value; // Spawning at random height (between 0,1) on y-axis
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            case 1:
                spawnPoint.x = Random.value; // Spawning at random width (between 0,1) on x-axis
                spawnPoint.y = 0;
                direction = new Vector2(Random.Range(-1f, 1f), 1f);
                break;
            case 2:
                spawnPoint.x = 1;
                spawnPoint.y = Random.value; // Spawning at random height (between 0,1) on y-axis
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;
            case 3:
                spawnPoint.x = Random.value; // Spawning at random width (between 0,1) on x-axis
                spawnPoint.y = 1;
                direction = new Vector2(Random.Range(-1f, 1f), -1f);
                break;
        }

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint); // world coordinates of the asteroids
        worldSpawnPoint.z = 0f;

        // Randomly select the asteroid
        GameObject asteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];

        GameObject spawnedAsteroid = Instantiate(asteroid, worldSpawnPoint, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));

        Rigidbody2D rb = spawnedAsteroid.GetComponent<Rigidbody2D>();

        rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);
    }
}
