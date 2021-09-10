using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGunBehavior : MonoBehaviour
{
    public GameObject FireballPowerUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FireballPowerUp.GetComponent<ProjectileLanucher>().enabled = true;
        }
    }
}
