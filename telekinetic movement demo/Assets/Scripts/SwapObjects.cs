using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapObjects : MonoBehaviour
{
    //swaps the two object
    public void Swap(Interactable ob1, Interactable ob2, bool swapForce, ParticleSystem swapEffect)
    {
        //if both objects are swappable
        if (ob1.canSwap() && ob2.canSwap()) { 
            //swap the two object positions
            Vector3 pos1 = ob1.GetPos();
            ob1.SetPos(ob2.GetPos());
            ob2.SetPos(pos1);
            //if swapForce is true, swap the external forces acting on the two objects
            if (swapForce)
            {
                Vector3 force1 = ob1.GetForce();
                ob1.SetForce(ob2.GetForce());
                ob2.SetForce(force1);
            }
            //instantiate the particle effects for swapping on both objects
            Instantiate(swapEffect, ob1.GetPos(), swapEffect.transform.rotation);
            Instantiate(swapEffect, ob2.GetPos(), swapEffect.transform.rotation);
        }
    }
}
