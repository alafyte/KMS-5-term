using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private Vector3 initialScale;
    public GameObject sphere;
    public float scaleFactor = 2;
    private bool isInsideTrigger = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == sphere)
        {
            isInsideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == sphere)
        {
            isInsideTrigger = false;
        }
    }

    private void FixedUpdate()
    {
        if (isInsideTrigger)
        {
            sphere.transform.localScale = initialScale * scaleFactor;
        }
        else
        {
            sphere.transform.localScale = initialScale;
        }
    }

    void Start()
    {
        initialScale = sphere.transform.localScale;
    }

    void Update()
    {
        
    }
}
