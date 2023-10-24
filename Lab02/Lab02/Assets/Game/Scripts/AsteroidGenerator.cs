using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public GameObject asteroid1Prefab;
    public GameObject asteroid2Prefab;
    public GameObject bonusPrefab;
    public GameObject boostPrefab;
    public int numberOfAsteroids = 25;
    public float minDistance = 5f;
    public float spawnInterval = 15f;
    public float rotationSpeed = 20f;
    public float deletionDistance = 30f;
    public float spawnDistance = 430f;
    private float lastSpawnPositionZ = 0f;

    private Vector3 minBounds;
    private Vector3 maxBounds;
    private Queue<GameObject> asteroidQueue = new Queue<GameObject>();

    private List<int> livesIndexes = new List<int>() { 1, 6, 20, 30, 76 };
    private List<int> boostIndexes = new List<int>() { 3, 45, 81, 99, 64 };


    private void Start()
    {
        minBounds = new Vector3(-13, 0, 30);
        maxBounds = new Vector3(13, 0, 200);
        GenerateAsteroids();
    }

    void GenerateAsteroids()
    {
        lastSpawnPositionZ = minBounds.z;

        for (int i = 0; i < numberOfAsteroids; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(minBounds.x, maxBounds.x),
                0,
                lastSpawnPositionZ
            );

            GameObject asteroid;

            int randNum = Random.Range(1, 100);

            if (livesIndexes.Contains(randNum))
            {
               Instantiate(bonusPrefab, new Vector3(Random.Range(minBounds.x, maxBounds.x), 0, lastSpawnPositionZ), Quaternion.Euler(-90, 0, 0));
            }
            else if (boostIndexes.Contains(randNum))
            {
                Instantiate(boostPrefab, new Vector3(Random.Range(minBounds.x, maxBounds.x), 0, lastSpawnPositionZ), Quaternion.identity);
            }
            else if (Random.Range(1, 3) % 2 == 0)
            {
                asteroid = Instantiate(asteroid2Prefab, randomPosition, Quaternion.identity);
                asteroid.transform.rotation = Random.rotation;
                asteroidQueue.Enqueue(asteroid);
            }
            else
            {
                asteroid = Instantiate(asteroid1Prefab, randomPosition, Quaternion.identity);
                asteroid.transform.rotation = Random.rotation;
                asteroidQueue.Enqueue(asteroid);
            }
            lastSpawnPositionZ += spawnInterval;
        }
    }

    private void Update()
    {

        if (lastSpawnPositionZ < transform.position.z + spawnDistance)
        {

            GameObject asteroid;
            int randNum = Random.Range(1, 100);

            if (livesIndexes.Contains(randNum))
            {
               Instantiate(bonusPrefab, new Vector3(Random.Range(minBounds.x, maxBounds.x), 0, lastSpawnPositionZ), Quaternion.Euler(-90, 0, 0));
            }
            else if (boostIndexes.Contains(randNum))
            {
                Instantiate(boostPrefab, new Vector3(Random.Range(minBounds.x, maxBounds.x), 0, lastSpawnPositionZ), Quaternion.identity);
            }
            else if (Random.Range(1, 3) % 2 == 0)
            {
                asteroid = Instantiate(asteroid2Prefab, new Vector3(Random.Range(minBounds.x, maxBounds.x), 0, lastSpawnPositionZ), Quaternion.identity);
                asteroidQueue.Enqueue(asteroid);
            }
            else
            {
                asteroid = Instantiate(asteroid1Prefab, new Vector3(Random.Range(minBounds.x, maxBounds.x), 0, lastSpawnPositionZ), Quaternion.identity);
                asteroidQueue.Enqueue(asteroid);
            }
            
            lastSpawnPositionZ += spawnInterval;
        }

        GameObject lastAsteroid = asteroidQueue.Peek();

        if (lastAsteroid.transform.position.z < transform.position.z - deletionDistance)
        {
            asteroidQueue.Dequeue();
            Destroy(lastAsteroid);
        }

        foreach (GameObject asteroid in GameObject.FindGameObjectsWithTag("Asteroid"))
        {
            asteroid.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}

