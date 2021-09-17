using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformButtonBehavior : MonoBehaviour
{
    public ProjectileLanucher launcher;

    private bool Launched;

    private void OnMouseDown()
    {
        if (!Launched)
        {
            launcher.LanuchProjectile();
            Launched = true;
        }
      
   
    }

}
