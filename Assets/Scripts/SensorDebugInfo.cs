using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SensorDebugInfo : MonoBehaviour
{
    public LaserSensor sensor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var txt = this.gameObject.GetComponent<Text>();
        txt.color = Color.white;
        txt.text = ($"Object Distance: {sensor.Range}");
    }
}
