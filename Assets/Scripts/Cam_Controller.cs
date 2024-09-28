using UnityEngine;



public class Cam_Controller : MonoBehaviour
{


    public Camera cam_1;
    public Camera cam_2;
    public bool Cam1_on;
        public bool Cam2_on;

    // Start is called before the first frame update
    void Start()
    {
        cam_2.enabled=false;
        cam_1.enabled = true;

        //GameObject.Find("MainCamera").camera.enabled = false;
       // GameObject.Find("ArialCamera").camera.enabled = true;

        Cam1_on = true;
        Cam2_on = false;

        Debug.Log("starting");
    }
  

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("poop");

            cam_1.enabled = false;
            cam_2.enabled = true;

           // this.enabled = false;
            
          

            


            
            Cam2_on = true;
            Cam1_on = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            cam_1.enabled = true;
            cam_2.enabled = false;
            Cam2_on = false;
            Cam1_on = true;


        }

        

    }
}
