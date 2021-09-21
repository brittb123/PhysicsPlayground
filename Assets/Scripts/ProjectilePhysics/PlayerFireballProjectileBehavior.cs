using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireballProjectileBehavior : MonoBehaviour
{
    [Tooltip("This is the object that can be destroyed")]
    public MeshRenderer WeakPoint;

    [Tooltip("A reference to the health of the robot")]
    [SerializeField]
    private HealthBehavior _health;

    private void OnTriggerEnter(Collider other)
    {
        // When it hits the target the renderer is turned off and the health bar is subtracted by 2
        WeakPoint.enabled = false;
        _health.takeDamage(2);
    }
}
