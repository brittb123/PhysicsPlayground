using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WakeupMaterialBehavior : MonoBehaviour
{
    public Material awakeMaterial = null;
    public Material asleepMaterial = null;

    private Rigidbody _rigidbody = null;
    private MeshRenderer _render = null;

    private bool _wasAsleep = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _render = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        //Set material to asleep if rigidbody is asleep
        if (_wasAsleep && _rigidbody.IsSleeping() && asleepMaterial)
        {
            _wasAsleep = false;
            _render.material = asleepMaterial;
        }

        else if (!_wasAsleep && !_rigidbody.IsSleeping() && awakeMaterial)
        {
            _wasAsleep = true;
            _render.material = awakeMaterial;
        }
        //Set material to awake if rigidbody is awake
    }
}
