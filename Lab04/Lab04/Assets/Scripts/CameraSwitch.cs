using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    private bool isFirstCameraActive;

    void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
        isFirstCameraActive = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isFirstCameraActive = !isFirstCameraActive;
            camera1.enabled = isFirstCameraActive;
            camera2.enabled = !isFirstCameraActive;
        }
    }
}
