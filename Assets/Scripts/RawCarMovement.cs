using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RawCarMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Car = this.gameObject.GetComponent<Rigidbody>();
    }

    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float Scaler;
    private float torque;
    private float acceleration;
    private Rigidbody Car;

    public void FixedUpdate()
    {
        float motor = Input.GetAxis("Vertical");
        acceleration = (maxMotorTorque * Scaler / Car.mass);
        if (motor == 0)
        {
            torque = torque <= 0 ? 0 : torque - acceleration;
        }
        else
        {
            float nextTorque = torque + acceleration * motor;
            torque = nextTorque <= maxMotorTorque ? (nextTorque >= -maxMotorTorque ? nextTorque : -maxMotorTorque): maxMotorTorque;
        }
        Debug.Log(torque);
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = torque;
                axleInfo.rightWheel.motorTorque = torque;
            }
        }
    }

    //public void ApplyLocalPositionToVisuals(WheelCollider collider)
    //{
    //    if (collider.transform.childCount == 0)
    //    {
    //        return;
    //    }

    //    Transform visualWheel = collider.transform.GetChild(0);

    //    Vector3 position;
    //    Quaternion rotation;
    //    collider.GetWorldPose(out position, out rotation);
    //    rotation = new Quaternion(rotation.x, rotation.y, 360-rotation.z, rotation.w);
    //    visualWheel.transform.position = position;
    //    visualWheel.transform.rotation = rotation;
    //}
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}