using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultShotgun : gun
{
    [Header("shotgun specific settings")]
    [Tooltip("the number of bullets fired per shot")]
    public int numBullets = 5;
    [Tooltip("the minimum tolerance angle between the headings of each bullet. Currently unused")]
    public float minTolerance = .01f;
    //shotgun version of shoot
    public override void Shoot()
    {
        //if the cooldown is zero
        if (cooldown <= 0f)
        {
            //ArrayList headings = new ArrayList();
            //fire all of the bullets in a spread
            for( int i = 0; i < numBullets; i++)
            {
                Vector3 newHeading = ChooseHeading();
                //(int j = 0; j < headings.)
                SpawnBullet(newHeading);
                Debug.Log("spawned bullet");
            }
            Debug.Log("done firing");
            //set cooldown to max
            cooldown = maxCooldown;

        }
    }
}
