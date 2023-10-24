using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratetrafficLights : MonoBehaviour
{
    public GameObject prefabToGenerate;
    public float spawnInterval = 2f;
    public float distanceBetweenObjects = 3f;
    public float deletionDistance = 30f;
    public float spawnDistance = 630f;
    private float lastSpawnPositionZ = 0f;
    private Queue<GameObject> spawnQueue = new Queue<GameObject>();

    private void Start()
    {
        for (int i = 0; i < 150; i++)
        {
            GameObject leftLight = Instantiate(prefabToGenerate, new Vector3(-18, 1.69f, lastSpawnPositionZ), Quaternion.identity);
            GameObject rightLight = Instantiate(prefabToGenerate, new Vector3(18, 1.69f, lastSpawnPositionZ), Quaternion.identity);
            lastSpawnPositionZ += distanceBetweenObjects;

            spawnQueue.Enqueue(leftLight);
            spawnQueue.Enqueue(rightLight);
        }
    }

    void Update()
    {

        if (lastSpawnPositionZ < transform.position.z + spawnDistance)
        {
            GameObject leftLight = Instantiate(prefabToGenerate, new Vector3(-18, 1.69f, lastSpawnPositionZ), Quaternion.identity);
            GameObject rightLight = Instantiate(prefabToGenerate, new Vector3(18, 1.69f, lastSpawnPositionZ), Quaternion.identity);
            spawnQueue.Enqueue(leftLight);
            spawnQueue.Enqueue(rightLight);
            lastSpawnPositionZ += distanceBetweenObjects;
        }

        GameObject lastLightLeft = spawnQueue.Peek();

        if (lastLightLeft.transform.position.z < transform.position.z - deletionDistance)
        {
            spawnQueue.Dequeue();
            Destroy(lastLightLeft);

            GameObject lastLightRight = spawnQueue.Peek();
            spawnQueue.Dequeue();
            Destroy(lastLightRight);
        }

    }
}
