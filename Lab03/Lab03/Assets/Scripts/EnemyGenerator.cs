using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject Emeny;

    public float spawnFromAreaSize = -30f;
    public float spawnToAreaSize = 30f;

    public int countEmeny = 6;

    private void Start()
    {
        if (Emeny != null)
        {
            for (int i = 0; i < countEmeny; i++)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(spawnFromAreaSize, spawnToAreaSize),
                    0.5f,
                    Random.Range(spawnFromAreaSize, spawnToAreaSize)
                );
                GameObject newPrefab = Instantiate(Emeny, randomPosition, Quaternion.identity);
                float randomYRotation = Random.Range(0f, 360f);
                newPrefab.transform.rotation = Quaternion.Euler(0, randomYRotation, 0);
            }
        }
    }
}
