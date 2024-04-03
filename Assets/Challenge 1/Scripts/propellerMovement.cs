using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propellerMovement : MonoBehaviour
{
    float speed = 5.0f;

    void Update()
    {
        transform.Rotate(0, 0, speed);
    }
}
