﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float speed = 4.0f;
    public float jumpStrength = 10.0f;
    public float airControl = 1;
    public float gravityModifier = 1.0f;
    private bool _isGrounded = false;

    public Camera PlayerCamera;

    [SerializeField]
    private CharacterController _playerController;

    private Vector3 _desiredGroundVelocity;
    private Vector3 _desiredAirVelocity;

    private bool _needToJump;

    private void Awake()
    {
        _playerController.GetComponent<CharacterController>();
    }

    private void Update()
    {
        //Gets the jump input
        _needToJump = Input.GetButtonDown("Jump");
        
        //Sets the movement input from player
        _desiredGroundVelocity.x = Input.GetAxis("Horizontal");
        _desiredGroundVelocity.z = Input.GetAxis("Vertical");

        //Get camera normal
        Vector3 cameraForward = PlayerCamera.transform.forward;
        cameraForward.y = 0.0f;
        cameraForward.Normalize();
        //Get Camera Right
        Vector3 cameraRight = PlayerCamera.transform.right;

        _desiredGroundVelocity = (_desiredGroundVelocity.x * cameraRight + _desiredGroundVelocity.z * cameraForward);

        //Sets the movement magnitude
        _desiredGroundVelocity.Normalize();
        _desiredGroundVelocity *= speed;

        //Applys air control to player
        

        //Check for ground
        _isGrounded = _playerController.isGrounded;

     
        if (_needToJump && _isGrounded)
        {
            _desiredAirVelocity.y = jumpStrength;
            _needToJump = false;
        }

        //Applies the gravity
        _desiredAirVelocity += Physics.gravity * gravityModifier * Time.deltaTime;

      

        _playerController.Move((_desiredGroundVelocity + _desiredAirVelocity) * Time.deltaTime);

        //Stop on ground
        if (_isGrounded && _desiredAirVelocity.y < 0)
        {
            _desiredAirVelocity.y = -1;
        }

    }


}
