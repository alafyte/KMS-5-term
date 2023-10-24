using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriggerBoost : MonoBehaviour
{
    public float speedBoostAmount = 23.0f;
    public float boostDuration = 10.0f;

    private SpaceShipMovement spaceShipComponent;
    private bool alreadyUsed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!alreadyUsed && other.gameObject.tag != "Asteroid")
        {
            GameObject ship = GameObject.FindGameObjectsWithTag("Player").Single();
            spaceShipComponent = ship.GetComponent<SpaceShipMovement>();

            spaceShipComponent.currentSpeed = speedBoostAmount;
            alreadyUsed = true;

            StartCoroutine(RemoveSpeedBoostAfterDuration(boostDuration));
        }
    }

    IEnumerator RemoveSpeedBoostAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);

        spaceShipComponent.currentSpeed = spaceShipComponent.initialSpeed;
    }
}
