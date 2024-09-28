using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Oscilate : MonoBehaviour
{
    public float angle_1;
    public float angle_2;
    public Camera targetCam;

    public bool rotate_left;
    public bool rotate_right;
    public bool rotate_camera;
    public bool camera_waiting;
    public float wait_time;
    public float cameraTimer;
    public float cameraSpeed;

    void Start()
    {

        
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
       



        if (rotate_camera == true && !camera_waiting)
        {
            Debug.Log(targetCam.transform.rotation.y);


            if ((targetCam.transform.rotation.y >= angle_1) && (rotate_left==true))
            {
                targetCam.transform.Rotate(0, -cameraSpeed, 0, Space.World);
                
            }

            if ((targetCam.transform.rotation.y < angle_1) && (rotate_left == true))
            {
                Debug.Log("We hit the LEFT WALL");

                rotate_right = true;
                rotate_left = false;
                camera_waiting = true;
                cameraTimer = wait_time;
            }

            if ((targetCam.transform.rotation.y <= angle_2) && (rotate_right == true))
            {
                targetCam.transform.Rotate(0, cameraSpeed, 0, Space.World);
                
            }

            if ((targetCam.transform.rotation.y > angle_2) && (rotate_right == true))
            {
                Debug.Log("We hit the RIGHT WALL");

                rotate_right = false;
                rotate_left = true;
                camera_waiting = true;
                cameraTimer = wait_time;
            }
        }

        if (camera_waiting)
        {
            cameraTimer -= Time.deltaTime;
            if (cameraTimer < 0)
            {
                camera_waiting = false;
            }
        }
            



    }
}
