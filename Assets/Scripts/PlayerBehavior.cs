using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float speed = 4.0f;
    public float jumpStrength = 10.0f;
    public float gravityModifier = 1.0f;

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

        //Sets the movement magnitude
        _desiredGroundVelocity.Normalize();
        _desiredGroundVelocity *= speed;

        if (_needToJump)
        {
            _desiredAirVelocity.y = jumpStrength;
            _needToJump = false;
        }

        //Applies the gravity
        _desiredAirVelocity += Physics.gravity * gravityModifier * Time.deltaTime;

        _playerController.Move((_desiredGroundVelocity + _desiredAirVelocity) * Time.deltaTime);
    }


}
