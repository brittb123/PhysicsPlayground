using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBulletsBehavior : MonoBehaviour
{
    [Tooltip("This is the time the bullets wait to despawn")]
    public float DespawnTime;
    private float _despawnTime;

    [SerializeField]
    private GameObject bullet;

    private void Update()
    {
        // Destroys the bullet after the timer is done!
        Destroy(bullet, DespawnTime);
    }
}
