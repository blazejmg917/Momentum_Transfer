using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticles : MonoBehaviour
{
    [Tooltip("How long the particles last")]
    public float lifetime = .5f;
    // Update is called once per frame
    void FixedUpdate()
    {
        //decrease the timer on the particles
        lifetime -= Time.fixedDeltaTime;
        //if the timer hits 0, destroy the particles
        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
