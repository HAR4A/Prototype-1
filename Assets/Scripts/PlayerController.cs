using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float speed = 15.0f;
    private float turnSpeed = 25.0f;

    private float horizontalInput;
    private float forwardInput;

    public Camera mainCamera;
    public Camera driverCamera;
    public KeyCode switchKey;

    public string inputID;



    void FixedUpdate()
    {

        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        //move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            driverCamera.enabled = !driverCamera.enabled;
        }

    }
}
                                             