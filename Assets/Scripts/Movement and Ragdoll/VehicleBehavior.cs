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
            JointMotor FLmotor = frontleft.motor;
            FLmotor.targetVelocity = 400;
            FLmotor.force = 400;
            frontleft.motor = FLmotor;

            JointMotor BLmotor = backleft.motor;
            BLmotor.targetVelocity = 400;
            BLmotor.force = 400;
            backleft.motor = BLmotor;

            JointMotor FRmotor = frontright.motor;
            FRmotor.targetVelocity = -400;
            FRmotor.force = 400;
            frontright.motor = FRmotor;

            JointMotor BRmotor = frontright.motor;
            BRmotor.targetVelocity = -400;
            BRmotor.force = 400;
            backright.motor = BRmotor;

        }
        //else if(Input.GetKeyDown(KeyCode.S))
        //{
        //    JointMotor FLmotor = frontleft.motor;
        //    FLmotor.targetVelocity = 0;
        //    FLmotor.force = 0;
        //    frontleft.motor = FLmotor;

        //    JointMotor BLmotor = backleft.motor;
        //    BLmotor.targetVelocity = 0;
        //    BLmotor.force = 0;
        //    backleft.motor = BLmotor;

        //    JointMotor FRmotor = frontright.motor;
        //    FRmotor.targetVelocity = -0;
        //    FRmotor.force = 0;
        //    frontright.motor = FRmotor;

        //    JointMotor BRmotor = frontright.motor;
        //    BRmotor.targetVelocity = -0;
        //    BRmotor.force = 0;
        //    backright.motor = BRmotor;
        //}
    }
}
