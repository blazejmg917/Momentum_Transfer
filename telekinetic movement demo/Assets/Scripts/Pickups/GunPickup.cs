using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : Pickup
{
    //the gun to be picked up 
    public GameObject gun;
    //private variable to ensure gun isn't picked up multiple times in one frame
    private bool destroyed = false;

    public override void OnPickup(GameObject pickupper)
    {
        if (!destroyed)
        {
            pickupper.GetComponent<playerMovement>().AddGun(gun);
            destroyed = true;
            Destroy(gameObject);
        }
        

    }

    public override bool CheckPickupper(GameObject pickupper)
    {
        return pickupper.CompareTag("Player");
    }
}
