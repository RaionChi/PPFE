using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car_controller : MonoBehaviour
{
    public Text TxtSpeed;
    public WheelCollider front_left;
    public WheelCollider front_right;
    public WheelCollider back_left;
    public WheelCollider back_right;
    public float Torque;
    public float Speed;
    public float MaxSpeed = 200f;
    public int Brake = 10000;
    public float CoefAcceleration = 10f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {

        }
    }
}
