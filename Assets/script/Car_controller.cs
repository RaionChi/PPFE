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


    void Start()
    {
        
    }

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
                back_left.brakeTorque = 0;
                back_right.brakeTorque = 0;
                back_left.motorTorque = Input.GetAxis("Vertical") * Torque * CoefAcceleration * Time.deltaTime;
                back_right.motorTorque = Input.GetAxis("Vertical") * Torque * CoefAcceleration * Time.deltaTime;
            }
        }
        
        //Déceleration
        if (!Input.GetKey(KeyCode.UpArrow) )
        {
            back_left.motorTorque = 0;
            back_right.motorTorque = 0;
            back_left.brakeTorque = Brake * CoefAcceleration * Time.deltaTime;
            back_right.brakeTorque = Brake * CoefAcceleration * Time.deltaTime;
        }

        //direction du vehicule
        front_left.steerAngle = Input.GetAxis("Horizontal") * WhellAngleMAx;
        front_right.steerAngle = Input.GetAxis("Horizontal") * WhellAngleMAx;
    }
}
