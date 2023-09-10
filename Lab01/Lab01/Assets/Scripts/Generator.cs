using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    MeshRenderer render;
    // Start is called before the first frame update
    void Start()
    {
       render = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float minX = render.bounds.min.x;
        float minZ = render.bounds.min.z;
        float maxX = render.bounds.max.x;
        float maxZ = render.bounds.max.z;

        float newX = Random.Range(minX, maxX);
        float newZ = Random.Range(minZ, maxZ);
        float newY = gameObject.transform.position.y + 5;

        //if (Input.GetKeyDown(KeyCode.Space)) 
        //{
        //    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //    cube.transform.position = new Vector3(newX, newY, newZ);

        //    cube.AddComponent<Rigidbody>();
        //}

        if (Input.GetMouseButtonDown(0))
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = new Vector3(newX, newY, newZ);

            sphere.AddComponent<Rigidbody>();

            Renderer sphereRenderer = sphere.GetComponent<Renderer>();
            sphereRenderer.material.color = Random.ColorHSV();

        }
    }
}
