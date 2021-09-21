using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehavior : MonoBehaviour
{
    [SerializeField]
    private float _health;

    public float Health
    {
        get
        {
            return _health;
        }  

    }

    private void Update()
    {
        if (_health < 0)
        {
            _health = 0;
        }
    }
    public void takeDamage(float damage)
    {
        _health -= damage;
    }
}
