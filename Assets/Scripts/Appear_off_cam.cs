using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear_off_cam : MonoBehaviour
{

    public Camera targetCam;
    private Camera_Oscilate C_OS;
    //public float targetAngle;
    public GameObject targetObject;
    public float triggerAngle;

    private bool appeared;
    //private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        appeared = false;
        targetObject.transform.Translate(0, 100, 0, Space.World);
        
       //rb = targetObject.GetComponent<Rigidbody>();
        //rb.
        //  this.gameObject.
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((targetCam.transform.rotation.y > triggerAngle) && (appeared == false))
        {
            appeared = true;
            targetObject.transform.Translate(0, -100, 0, Space.Self);

        }
    }
}
