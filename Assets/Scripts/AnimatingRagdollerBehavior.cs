using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatingRagdollerBehavior : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    public bool ragodolltest;

    private void OnCollisionEnter(Collision collision)
    {
        if (ragodolltest)
            _animator.enabled = false;

    }
}
