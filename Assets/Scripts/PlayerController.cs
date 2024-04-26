using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower = 0f;
    [SerializeField] float speed;
    [SerializeField] float rpm;

    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;
    int wheelsOnGround;

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
        if (IsOnGround())
        {
            horizontalInput = Input.GetAxis("Horizontal1");
            verticalInput = Input.GetAxis("Vertical1");

            //move the vehicle forward
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
            speedometerText.SetText("Score: " + speed + " km/h");

            rpm = Mathf.Round((speed % 30) * 40);
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
        foreach(WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)  //������� isGrounded ��������� ����������� � ��������� ��������� �� "�����" �� �����
            {
                wheelsOnGround++;
            }          
        }

        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
                                             