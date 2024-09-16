using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arquivo : MonoBehaviour
{
    // playerShoot.ammoDoze = 0;
    // playerShoot.ammoMetralhadora = 0;
    /*
     else if (playerInput.actions["Fire"].triggered && ammoDoze > 0 && ammoMetralhadora <= 0)
                    {
                        ShootDoze();
                        nextShoot = Time.time + 1f / fireRate;
                        animator.SetTrigger("isShooting");
                        ammoDoze -= 1;
                    }
    }
    */

    /*
     * void ShootDoze()
    {
        if(playerMovement.isFacingRight == true)
        {
            Instantiate(shoot, shootPoint.position, shootPoint.rotation = Quaternion.Euler(0, 0, 10));
            Instantiate(shoot, shootPoint.position, shootPoint.rotation = Quaternion.Euler(0, 0, 0));
            Instantiate(shoot, shootPoint.position, shootPoint.rotation = Quaternion.Euler(0, 0, -10));
            shootSound.Play();
            Instantiate(shootEffect, shootPoint.position, shootPoint.rotation);
        }
        else if (playerMovement.isFacingRight == false)
        {
            Instantiate(shoot, shootPoint.position, shootPoint.rotation = Quaternion.Euler(0, 180, 10));
            Instantiate(shoot, shootPoint.position, shootPoint.rotation = Quaternion.Euler(0, 180, 0));
            Instantiate(shoot, shootPoint.position, shootPoint.rotation = Quaternion.Euler(0, 180, -10));
            shootSound.Play();
            Instantiate(shootEffect, shootPoint.position, shootPoint.rotation);
        }
    }
    */
}
