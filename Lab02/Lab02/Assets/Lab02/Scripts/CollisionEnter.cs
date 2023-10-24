using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall1")
            Debug.Log("Hit the wall #1");
        else if (collision.gameObject.name == "Wall2")
            Debug.Log("Hit the wall #2");
        else if (collision.gameObject.name == "Floor")
            Debug.Log("Hit the floor");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
