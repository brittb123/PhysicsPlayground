﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform Target;
    public float distanceFromTarget = 10;
    public float sensitivity = 5;
    public bool invertY = false;

    private void Update()
    {
        //Rotate the camera
        if (Input.GetMouseButton(1))
        {
            Vector3 angles = transform.eulerAngles;
            Vector2 rotation;
            rotation.x = Input.GetAxis("Mouse Y") * (invertY ? -1.0f : 1.0f);
            rotation.y = Input.GetAxis("Mouse X");
            //Looks up and down by rotating around X-axis
            angles.x = Mathf.Clamp(angles.x + rotation.x * sensitivity * Time.deltaTime, 0.0f, 70.0f);
            //Looks to the left and right by rotating around Y-axis
            angles.y += rotation.y * sensitivity * Time.deltaTime;
            //Sets the angles
            transform.eulerAngles = angles;
        }

        //Move the camera
        transform.position = Target.position + (distanceFromTarget * -transform.forward);
    }
}
