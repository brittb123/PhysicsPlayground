using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireballProjectileBehavior : MonoBehaviour
{
    public MeshRenderer WeakPoint;
    private void OnTriggerEnter(Collider other)
    {
        WeakPoint.enabled = false;
   
    }
}
