using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableHealth : OtherHealth
{
    [Tooltip("the shattered version of this object")]
    public GameObject shattered;
    [Tooltip("the magnitude of force required to break this object without damage")]
    public float shatterForce = 1000F;
    //whether the object is destroyed or not. Used to ensure multiple destructions can't occur in one frame
    private bool destroyed = false;


    //checks to see what happens when a force is applied to this object.
    public bool ApplyForce(Vector3 force)
    {
        return force.magnitude > shatterForce;
    }

    //if the object is destroyed
    public override void Die()
    {
        //double check to ensure this object hasn't already been set for destruction on the next frame
        if (!destroyed)
        {
            //instantiate the shattered object and remove this one
            Instantiate(shattered, position: transform.position, rotation: transform.rotation);
            Debug.Log("destroyed");
            destroyed = true;
            Destroy(gameObject);
        }
        
    }
}
