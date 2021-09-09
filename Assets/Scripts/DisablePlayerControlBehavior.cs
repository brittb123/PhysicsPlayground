using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayerControlBehavior : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private GameObject _player;

    private void Start()
    {
        _player.GetComponent<PlayerBehavior>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _animator.enabled = false;
        GetComponent<PlayerBehavior>().enabled = false;
        
    }
}
