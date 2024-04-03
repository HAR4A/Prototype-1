using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float speed = 20.0f;
    private float rotationSpeed = 55.0f;
    private float verticalInput;

    void Update()
    {    
        verticalInput = Input.GetAxis("Vertical"); 
       
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Rotate(Vector3.left, Time.deltaTime * rotationSpeed * verticalInput);
    }
}
