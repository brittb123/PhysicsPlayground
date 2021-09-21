using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleBehavior : MonoBehaviour
{
    [SerializeField]
    private HingeJoint frontleft;
    [SerializeField]
    private HingeJoint frontright;
    [SerializeField]
    private HingeJoint backleft;
    [SerializeField]
    private HingeJoint backright;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            // Sets the motor to have a force and targetvelocity of 400
            JointMotor FLmotor = frontleft.motor;
            FLmotor.targetVelocity = 400;
            FLmotor.force = 400;
            frontleft.motor = FLmotor;

            // Sets the motor to have a force and targetvelocity of 400
            JointMotor BLmotor = backleft.motor;
            BLmotor.targetVelocity = 400;
            BLmotor.force = 400;
            backleft.motor = BLmotor;

            // Sets the motor to have a force of 400 and targetvelocity of -400
            JointMotor FRmotor = frontright.motor;
            FRmotor.targetVelocity = -400;
            FRmotor.force = 400;
            frontright.motor = FRmotor;

            // Sets the motor to have a force of 400 and targetvelocity of -400
            JointMotor BRmotor = frontright.motor;
            BRmotor.targetVelocity = -400;
            BRmotor.force = 400;
            backright.motor = BRmotor;

        }
       
    }
}
