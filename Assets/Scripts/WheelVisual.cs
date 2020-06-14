using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WheelCollider))]
public class WheelVisual : MonoBehaviour
{
    private WheelCollider Collider;

    public GameObject VisualWheel;

    // Start is called before the first frame update
    void Start()
    {
        Collider = this.gameObject.GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ApplyLocalPositionToVisuals(Collider);
    }

    private void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        Transform visualWheel = VisualWheel.transform;

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        rotation = rotation * Quaternion.Euler(new Vector3(0, 0, 90));

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }
}
