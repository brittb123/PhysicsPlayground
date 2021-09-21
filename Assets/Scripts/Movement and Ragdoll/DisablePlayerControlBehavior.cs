using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayerControlBehavior : MonoBehaviour
{
    [Tooltip("This is the projectile launcher that will be used to shoot to turn off")]
    [SerializeField]
    private PlayerFireballBehavior _launcher;

    [Tooltip(" The animator is used  to turn off animations and ragdoll the player upon hit")]
    [SerializeField]
    private Animator _animator;

    [Tooltip("The player object is grabbed to turn off the character controller as well as any other moving scripts")]
    [SerializeField]
    private GameObject _player;

    private void Start()
    {
        // Gets the player behavior attached to the player
        _player.GetComponent<PlayerBehavior>();
    }

    private void OnTriggerEnter(Collider other)

    {
        //If the player is hit with a object that has this tag...
        if (other.CompareTag("EnemyProjectile"))
        {
            // Disable the animator, player controls, and the ability to throw fireballs!
          _animator.enabled = false;
          _player.GetComponent<PlayerBehavior>().enabled = false;
          _launcher.GetComponent<PlayerFireballBehavior>().enabled = false;
        }


    }
}
