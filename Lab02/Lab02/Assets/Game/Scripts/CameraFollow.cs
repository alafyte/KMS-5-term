using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;


    private void Start()
    {
       offset = new Vector3(0, 6, -17);
    }

    private void Update()
    {
        transform.position = target.position + offset;
    }
}
