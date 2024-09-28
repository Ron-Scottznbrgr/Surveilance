using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Flicker : MonoBehaviour
{

    public bool flickerDisableLight;
    public bool flicker_waiting=true;
    public float flickerTimer;
    public float rapidFlickerTimer;
    public int rapidFlickerNum;
    public Light thisLight;
    public bool flicker_on;
    public float rapidFlickerTimer_MIN=0.5f, rapidFlickerTimer_MAX=1.5f;           //
    public int flickerNum_MIN=4, flickerNum_MAX= 9;       //3-10
    public float flickerTimer_MIN = 10f, flickerTimer_MAX = 15f; //20-45
    public float Light_Intensity_MIN=0.18F, Light_Intensity_MAX=1f;
    bool lightOn;
    



    // Start is called before the first frame update
    void Start()
    {
        lightOn = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (flicker_waiting)
        {
            flickerTimer -= Time.deltaTime;
            if (flickerTimer < 0)
            {
                flicker_waiting = false;
            }
        }



        if (!flicker_waiting)
        {
            if ((rapidFlickerNum == 0) && (flicker_on == false))//beginning flicker
            {
                rapidFlickerNum = Random.Range(flickerNum_MIN, flickerNum_MAX);
                rapidFlickerTimer = Random.Range(rapidFlickerTimer_MIN, rapidFlickerTimer_MAX);
                flicker_on = true;
            }

            if ((rapidFlickerNum == 0) && (flicker_on == true))//turning on light for good
            {
                flicker_on = false;
                flicker_waiting = true;
                flickerTimer = Random.Range(flickerTimer_MIN, flickerTimer_MAX);

                ChangeLighting(true); //turn on
                //thisLight.enabled = true;
            }
            if ((flicker_on) && rapidFlickerTimer > 0)      //if light is flickering, take off time.
            {

                rapidFlickerTimer -= Time.deltaTime;
            }

            if ((flicker_on) && rapidFlickerTimer < 0)
            {
                if (lightOn == true)
                {
                    
                    
                    rapidFlickerNum -= 1;
                    if (rapidFlickerNum>0)
                    {
                        ChangeLighting(false); //turn off
                        //thisLight.enabled = false;
                    }


                }
                else
                {
                    ChangeLighting(true); //turn on
                    //thisLight.enabled = true;

                }
                rapidFlickerTimer = Random.Range(rapidFlickerTimer_MIN, rapidFlickerTimer_MAX);
            }




        }

    }

    void ChangeLighting(bool turnON)
    {
        if (turnON)
        {
            lightOn = true;
            if (flickerDisableLight)
            {
                thisLight.enabled = true;
            }
            else
            {
                thisLight.intensity = Light_Intensity_MAX;
            }
        }
        else
        {
            lightOn = false;
            if (flickerDisableLight)
            {
                thisLight.enabled = false;
            }
            else
            {
                thisLight.intensity = Light_Intensity_MIN;
            }
        }



    }


}
