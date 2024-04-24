using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float horsePower = 0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;

    private Rigidbody playerRb;

    /* public Camera mainCamera;
     public Camera driverCamera;
     public KeyCode switchKey;
     public string inputID;*/


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();   
    }

    void FixedUpdate()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //move the vehicle forward
        playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        /*if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            driverCamera.enabled = !driverCamera.enabled;
        }*/

    }
}
                                             