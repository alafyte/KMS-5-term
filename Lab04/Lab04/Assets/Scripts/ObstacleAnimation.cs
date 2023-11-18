using UnityEngine;

public class ObstacleAnimation : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float lowerLimit = 1.0f;
    public float upperLimit = 8.0f;

    private bool movingForward = true;

    private void Update()
    {
        Vector3 currentPosition = transform.position;

        if (movingForward)
        {
            currentPosition.z += moveSpeed * Time.deltaTime;
            if (currentPosition.z >= upperLimit)
            {
                currentPosition.z = upperLimit;
                movingForward = false;
            }
        }
        else
        {
            currentPosition.z -= moveSpeed * Time.deltaTime;
            if (currentPosition.z <= lowerLimit)
            {
                currentPosition.z = lowerLimit;
                movingForward = true;
            }
        }

        transform.position = currentPosition;
    }
}
