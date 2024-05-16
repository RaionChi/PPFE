using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Car_controller : MonoBehaviour
{
    public TMP_Text textSpeed;
    public WheelCollider front_left;
    public WheelCollider front_right;
    public WheelCollider back_left;
    public WheelCollider back_right;
    public float Torque;
    public float Speed;
    public float MaxSpeed = 200f;
    public int Brake = 10000;
    public float CoefAcceleration = 10f;
    public float WhellAngleMAx = 10f;
    public float DAmax = 40f;
    public bool Freinage = false;
    public GameObject Backlight;

   

    // Update is called once per frame
    void Update()
    {
        Speed = GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        textSpeed.text = "Speed : " + (int) Speed ;

        //Accelleration
        if (Speed < MaxSpeed)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {

                if (!Freinage)
                {
                    front_left.brakeTorque = 0;
                    front_right.brakeTorque = 0;
                    back_left.brakeTorque = 0;
                    back_right.brakeTorque = 0;
                    back_left.motorTorque = Input.GetAxis("Vertical") * Torque * CoefAcceleration * Time.deltaTime;
                    back_right.motorTorque = Input.GetAxis("Vertical") * Torque * CoefAcceleration * Time.deltaTime;
                }
            }
               
        }
        
        //Déceleration
        if (!Input.GetKey(KeyCode.UpArrow) && !Freinage || Speed>MaxSpeed)
        {
            back_left.motorTorque = 0;
            back_right.motorTorque = 0;
            back_left.brakeTorque = Brake * CoefAcceleration * Time.deltaTime;
            back_right.brakeTorque = Brake * CoefAcceleration * Time.deltaTime;
        }

        //direction du vehicule

        float DA = (((WhellAngleMAx - DAmax)/MaxSpeed)* Speed) + DAmax;
        front_left.steerAngle = Input.GetAxis("Horizontal") * DA;
        front_right.steerAngle = Input.GetAxis("Horizontal") * DA;

        //Freinage

        if(Input.GetKey(KeyCode.Space)) 
        {
            Freinage = true;
            Backlight.SetActive(true);
            back_left.brakeTorque = Mathf.Infinity;
            back_right.brakeTorque = Mathf.Infinity;
            front_left.brakeTorque = Mathf.Infinity;
            front_right.brakeTorque = Mathf.Infinity;
            back_left.motorTorque = 0;
            back_right.motorTorque = 0;
           
            

        }
        else
        {
            Freinage = false;
            Backlight.SetActive(false);    
        }

        //Marche arrière
        if (Input.GetKey(KeyCode.DownArrow)) 
        {
            front_left.brakeTorque = 0;
            front_right.brakeTorque = 0;
            back_left.brakeTorque = 0;
            back_right.brakeTorque = 0;
            back_left.motorTorque = Input.GetAxis("Vertical") * Torque * CoefAcceleration * Time.deltaTime;
            back_right.motorTorque = Input.GetAxis("Vertical") * Torque * CoefAcceleration * Time.deltaTime;
        }
    }

}
