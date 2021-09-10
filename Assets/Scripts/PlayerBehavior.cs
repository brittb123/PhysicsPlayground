using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float speed = 4.0f;
    public float jumpStrength = 10.0f;
    public float airControl = 1;
    public float gravityModifier = 1.0f;
    private bool _isGrounded = false;
    public bool faceWithCamera;

    public Camera PlayerCamera;
    public float Speed = 5.0f;

    [SerializeField]
    private CharacterController _playerController;

    [SerializeField]
    private Animator _animator;

    private Vector3 _desiredGroundVelocity;
    private Vector3 _desiredAirVelocity;

    private bool _needToJump;

    public List<Rigidbody> rigidbodies = new List<Rigidbody>();

    [SerializeField]
    private bool _ragdolling;

    private void Awake()
    {
        _playerController.GetComponent<CharacterController>();
    }

    private void Ragdoll()
    {
        if (_ragdolling)
        {
            _desiredGroundVelocity = Vector3.zero;
            _needToJump = false;
            _animator.enabled = !_animator.enabled;
        }
    }

    private void Update()
    {
        //Gets the jump input
        _needToJump = Input.GetButtonDown("Jump");
        
        //Sets the movement input from player
        _desiredGroundVelocity.x = Input.GetAxis("Horizontal");
        _desiredGroundVelocity.z = Input.GetAxis("Vertical");
        float inputFoward = Input.GetAxis("Vertical");
        float inputRight = Input.GetAxis("Horizontal");

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

        if (faceWithCamera)
        {
            transform.forward = cameraForward;
            _animator.SetFloat("Speed", inputFoward);
            _animator.SetFloat("Direction", inputRight);
        }
        else
        {
            if(_desiredGroundVelocity != Vector3.zero)
            {
                transform.forward = _desiredGroundVelocity.normalized;
            }
            _animator.SetFloat("Speed", _desiredGroundVelocity.magnitude / Speed);
        }
        _animator.SetBool("Jump", !_isGrounded);
        //_animator.SetFloat("Vertical Speed", _desiredGroundVelocity.y / jumpStrength);

        _playerController.Move((_desiredGroundVelocity + _desiredAirVelocity) * Time.deltaTime);

        //Stop on ground
        if (_isGrounded && _desiredAirVelocity.y < 0)
        {
            _desiredAirVelocity.y = -1;
        }

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Ragdoll();
    //}

}
