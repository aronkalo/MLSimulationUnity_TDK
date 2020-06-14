using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyroscope : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        baseRotation = this.gameObject.transform.rotation;
    }

    private Quaternion baseRotation;

    // Update is called once per frame
    void Update()
    {
        Quaternion currentRotation = this.gameObject.transform.rotation;

        Quaternion.Dot(baseRotation, currentRotation);
        float rot = Quaternion.Angle(baseRotation, currentRotation);
    }
}
