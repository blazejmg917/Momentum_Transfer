using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerinteract : Interactable
{
    [Tooltip("the player movement script")]
    public playerMovement playerScript;
    //apply a force to this object
    public override void ApplyForce(Vector3 force)
    {

            playerScript.ApplyForce(force);
    }
    //set this object's external force
    public override void SetForce(Vector3 force)
    {

            playerScript.SetForce(force);

    }
    //get this object's external force
    public override Vector3 GetForce()
    {

            return playerScript.GetForce();

    }
    //get this object's position
    public override Vector3 GetPos()
    {

            return playerScript.GetPos();

    }
    //set this object's position
    public override void SetPos(Vector3 pos)
    {

            playerScript.SetPos(pos);

    }

}
    
