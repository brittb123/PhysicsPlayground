using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBulletsBehavior : MonoBehaviour
{
    public float DespawnTime;
    private float _despawnTime;

    [SerializeField]
    private GameObject bullet;

    private void Update()
    {
        Destroy(bullet, DespawnTime);
    }
}
