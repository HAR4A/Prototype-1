using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower = 0f;
    [SerializeField] float speed;
    [SerializeField] float rpm;
    [SerializeField] int wheelsOnGround;

    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;
  
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;  
    [SerializeField] GameObject centerOfMass;
    [SerializeField] List<WheelCollider> allWheels;

    /* public Camera mainCamera;
     public Camera driverCamera;
     public KeyCode switchKey;
     public string inputID;*/


    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.localPosition;
    }


    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal1");
        verticalInput = Input.GetAxis("Vertical1");

        if (IsOnGround())
        {
            //move the vehicle forward
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
                      
            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);          //speedometer
            speedometerText.SetText("Score: " + speed + " km/h");

            rpm = Mathf.Round((speed % 30) * 40);                                  //tachometer
            rpmText.SetText("RPM: " + rpm);


            /*if (Input.GetKeyDown(switchKey))
            {
                mainCamera.enabled = !mainCamera.enabled;
                driverCamera.enabled = !driverCamera.enabled;
            }*/
        }
    }


    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)  //атрибут isGrounded постоянно обновляется и проверяет находятся ли "колёса" на земле
            {
                wheelsOnGround++;
            }          
        }

        if (wheelsOnGround == 2)     //при значении 4 машина не едет
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
                                             