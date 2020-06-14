using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class MedianFilter
{
    public static float GetMedian(float[] dataSet)
    {
        var sorted = dataSet.OrderBy(x => x);
        int half = dataSet.Length / 2;
        return sorted.ElementAt(half);
    }

    public static float[] AddElement(float[] array, float newElement)
    {
        float[] newArray = new float[array.Length];
        Array.Copy(array, 1, newArray, 0, array.Length - 1);
        newArray[newArray.Length -1] = newElement;
        array = null;
        return newArray;
    }
}
public class RotaryEncoder : MonoBehaviour
{
    public float RoundPerMinute;
    private float prevAngle;
    private const int maxDegree = 360;
    private const int fromSecToMin = 60;
    public Vector3 RotAxis;
    void Update()
    {
        /*
         * Set RotAxis to (1,0,0) to get RPM around the x axis,
         * set RotAxis to (0,1,0) to get RPM around the y axis,
         * set RotAxis to (0,0,1) to get RPM around the z axis,
         */
        //  Get the object current rotation, in degrees
        Vector3 rot = this.gameObject.transform.rotation.eulerAngles;
        //  calculate the angle, based on the not zeroed axis. 
        float angle = Mathf.Abs((rot.x * RotAxis.x) + (rot.y * RotAxis.y) + (rot.z * RotAxis.z));
        //  calculate RPM
        RoundPerMinute = Mathf.Abs(prevAngle - angle) * fromSecToMin / (maxDegree * Time.deltaTime);
        //  save for next iteration
        prevAngle = angle;
    }
}
