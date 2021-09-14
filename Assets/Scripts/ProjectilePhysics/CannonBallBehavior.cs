using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CannonBallBehavior : MonoBehaviour
{
    public float ForceonFire = 100;
    private Rigidbody _rigidbody = null;
    bool canFire = true;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }
    private void FixedUpdate()
    {
        if(Input.anyKeyDown && canFire)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(transform.forward * ForceonFire);
            canFire = false;
        }
    }

}
