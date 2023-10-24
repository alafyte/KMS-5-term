using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSpheres : MonoBehaviour
{

    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 1, Random.Range(-10.0f, 10.0f));
        Instantiate(prefab, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
