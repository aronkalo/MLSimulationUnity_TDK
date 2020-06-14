using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCamera : MonoBehaviour
{
    public Transform lookAt;

    private Transform camTransform;

    private Camera cam;

    public float Distance = 5.0f;

    private float currentX = 0.0f;

    private float currentY = 0.0f;

    public float X_axis_sens = 8.0f;

    public float Y_axis_sens = 3.0f;

    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;


    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        currentX += Input.GetAxis("Mouse Y");
        currentY += Input.GetAxis("Mouse X");
        currentX = Mathf.Clamp(currentX, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -Distance);
        Quaternion rotation = Quaternion.Euler(currentX, currentY, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}

