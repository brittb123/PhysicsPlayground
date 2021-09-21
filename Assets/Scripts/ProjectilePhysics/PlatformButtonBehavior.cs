using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformButtonBehavior : MonoBehaviour
{
    [Tooltip("This is the launcher used to shoot at the robot!")]
    public ProjectileLanucher launcher;

    [Tooltip("This is to check if the button was already pressed")]
    private bool Launched;

    private void Update()
    {
        RaycastHit Hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // If the player presses the mouse on the button it fires all cannons
        if (Input.GetMouseButtonDown(0))
        {
            // sends a ray and gets back the first collider it hits
            Physics.Raycast(ray, out Hit);
           
            // if the ray hits the collider with the tag then..
            if(Hit.collider.tag == "ButtonToFire" && !Launched)
            {
                // Launch the projectiles and turn the bool true!
                launcher.LanuchProjectile();
                Launched = true;
            }
        }
    }

}
