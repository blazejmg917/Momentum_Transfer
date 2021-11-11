using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatteredLifetime : MonoBehaviour
{
    [Tooltip("How long this shattered object will last before being removed")]
    public float lifetime;

    void FixedUpdate()
    {
        //if the timer has run out, destroy this object
        if(lifetime < 0)
        {
            Destroy(gameObject);
        }
        //reduce the timer
        lifetime -= Time.fixedDeltaTime;
    }
}
