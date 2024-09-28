using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float angle_1;
    public float angle_2;
    //public Camera targetObj;

    public bool rotate_left;
    public bool rotate_right;
    public bool rotate_camera;
    public bool obj_waiting;
    public float wait_time;
    public float waitTimer;
    public float rotateSpeed;

    void Start()
    {


    }


    // Update is called once per frame
    void FixedUpdate()
    {
        
        this.transform.Rotate(0, -rotateSpeed, 0, Space.World);

    }
}
