using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clicker : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 pointA = eventData.pointerPressRaycast.worldPosition;
        Vector3 pointB = Camera.main.transform.position;
        Vector3 direction = pointA - pointB;

        direction = direction.normalized;

        float distance = Vector3.Distance(pointA, transform.position);
        Vector3 force = direction * (500 * (1 / distance));

        Vector3 target = eventData.pointerPressRaycast.worldPosition;

        gameObject.GetComponent<Rigidbody>().AddForceAtPosition(force, target);
    }

}
