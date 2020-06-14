using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultCamRender : MonoBehaviour
{
    // Start is called before the first frame update

    private Camera attachedCam;

    public Camera smallCam;
    
    void Start()
    {
        attachedCam = (Camera)this.gameObject.GetComponent("Camera");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
