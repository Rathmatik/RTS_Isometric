using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera eye;
    public float cameraRotationSpeed;

    void Start()
    {

    }

    void Update()
    {
        // For keyboard scrolling
        float translationX = Input.GetAxis("Horizontal");
        float translationY = Input.GetAxis("Vertical");

        // Keyboard camera movement
        float speedModifier = Input.GetKey(KeyCode.LeftShift) ? 2.0f : 1.0f;
        transform.Translate(speedModifier * (translationX + translationY), 0.0f, speedModifier * (translationY - translationX));

        // Rotating
        if (Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(new Vector3(0.0f, 0.0f, 0.0f), Vector3.up, cameraRotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(new Vector3(0.0f, 0.0f, 0.0f), Vector3.up, -cameraRotationSpeed * Time.deltaTime);
        }

        // Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && eye.fieldOfView > 20)
        {
            eye.fieldOfView = eye.fieldOfView - 4;
        }

        // Zoom out
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && eye.fieldOfView < 80)
        {
            eye.fieldOfView = eye.fieldOfView + 4;
        }

        // Default zoom
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            eye.fieldOfView = 50;
        }
    }
}
