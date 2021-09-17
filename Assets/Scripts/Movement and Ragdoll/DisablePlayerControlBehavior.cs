using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayerControlBehavior : MonoBehaviour
{

    [SerializeField]
    private PlayerFireballBehavior _launcher;


    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private Rigidbody _playerBody;

    private void Start()
    {
        _player.GetComponent<PlayerBehavior>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyProjectile"))
        {
          _animator.enabled = false;
          _player.GetComponent<PlayerBehavior>().enabled = false;
          _launcher.GetComponent<PlayerFireballBehavior>().enabled = false;
        }

        if (other.CompareTag("JumpPad"))
        {
            _playerBody.AddForce(0, 10, 0);
        }
    }
}
