using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumppadScript : MonoBehaviour
{
    [Tooltip("Gets the Render for the first platform")]
    public MeshRenderer platform1Render;

    [Tooltip("The render of the second platform")]
    public MeshRenderer platform2Render;

    private void OnTriggerEnter(Collider other)
    {
        // If the player enters the trigger area..
       if(other.CompareTag("Player"))
       {
            // Turn on the render for both platforms to see in the scene!
            platform1Render.enabled = true;
            platform2Render.enabled = true;
       }
    }

}
