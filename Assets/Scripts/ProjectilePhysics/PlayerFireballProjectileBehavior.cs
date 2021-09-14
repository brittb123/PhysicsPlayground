using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireballProjectileBehavior : MonoBehaviour
{
    public MeshRenderer WeakPoint;

    [SerializeField]
    private HealthBehavior _health;
    private void OnTriggerEnter(Collider other)
    {
        WeakPoint.enabled = false;
        _health.takeDamage(2);
    }
}
