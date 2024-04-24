using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower = 0f;
    [SerializeField] private GameObject centerOfMass;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;
   

    /* public Camera mainCamera;
     public Camera driverCamera;
     public KeyCode switchKey;
     public string inputID;*/


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();   
        playerRb.centerOfMass = centerOfMass.transform.position;  
    }

    void FixedUpdate()
    {

        horizontalInput = Input.GetAxis("Horizontal1");
        verticalInput = Input.GetAxis("Vertical1");

        //move the vehicle forward
        playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        /*if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            driverCamera.enabled = !driverCamera.enabled;
        }*/

    }
}
                                             