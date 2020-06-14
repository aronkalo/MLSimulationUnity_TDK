using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SensorDirection
{
    Up = 1,
    Down = 2,
    Right = 3,
    Left = 4,
    Forward = 5,
    Backward = 6,
}

public class LaserSensor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        laserRay = new Ray(attachedTransform.position, attachedTransform.rotation * Vector3.forward * SensorMaxDistance);
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        if (DirectionVector == Vector3.zero || DirectionVector == null)
        {
            switch (direction)
            {
                case SensorDirection.Up:
                    dVec = Vector3.up;
                    break;
                case SensorDirection.Down:
                    dVec = Vector3.down;
                    break;
                case SensorDirection.Right:
                    dVec = Vector3.right;
                    break;
                case SensorDirection.Left:
                    dVec = Vector3.left;
                    break;
                case SensorDirection.Forward:
                    dVec = Vector3.forward;
                    break;
                case SensorDirection.Backward:
                    dVec = Vector3.back;
                    break;
                default:
                    break;
            }
        }
        else
        {
            dVec = DirectionVector;
        }
    }

    public Vector3 DirectionVector;

    private Ray laserRay;

    public float SensorMaxDistance;

    public SensorDirection direction;

    public float Range { get; private set; }

    public bool state = false;

    private LineRenderer lineRenderer;

    public Transform attachedTransform;

    private Vector3 dVec;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        laserRay = new Ray(attachedTransform.position, attachedTransform.rotation * dVec);
        if (Physics.Raycast(laserRay.origin, laserRay.direction, out hit, SensorMaxDistance))
        {
            state = true;
            Range = hit.distance;
        }
        else
        {
            state = false;
            Range = SensorMaxDistance;
        }
        lineRenderer.SetPosition(0, laserRay.origin);
        lineRenderer.SetPosition(1, laserRay.origin + (laserRay.direction.normalized  * Range));
    }
}
