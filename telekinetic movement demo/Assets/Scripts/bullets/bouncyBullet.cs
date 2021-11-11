using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncyBullet : bullet
{
    [Header("bouncy bullet setting")]
    [Tooltip("how bouncy the bullet is magnitude of velocity will be multiplied by this number when bouncing. 1 = stop on wall, 2 = perfect bounce")]
    public float bounceFactor = 2;
    [Tooltip("the total number of times this bullet can bounce before disappearing")]
    public int maxBounce = 3;
    //the number of times this has bounced
    private int bounce = 0;


    public override void OnWallHit(Collision wall)
    {
        if (bounce < maxBounce)
        {
            bounce++;
        }
        else
        {
            base.OnWallHit(wall);
        }
        foreach (ContactPoint contact in wall.contacts)
        {
            GameObject otherObject = contact.otherCollider.gameObject;
            if (otherObject.CompareTag("Wall") || otherObject.CompareTag("bouncy"))
            {

                //get the normal force in 2d from the contact point
                Vector3 normal = new Vector3(contact.normal.x, 0, contact.normal.z);
                //Vector3 proj2 = ((Vector3.Dot(a, b)) / (b.magnitude * b.magnitude)) * b;
                Vector3 proj = Vector3.Project(startVelocity, normal);
                Debug.DrawRay(contact.point, proj, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 10f);
                Debug.Log("velocity before : " + startVelocity);
                Debug.Log("proj: " + proj + ", bf: " + bounceFactor);
                startVelocity -= (proj * bounceFactor);
                Debug.Log("velocity after : " + startVelocity);
                //RaycastHit hit;
                //Debug.Log(Physics.Raycast(transform.position, velocity, out hit));
                //Vector3 normal = new Vector3(hit.normal.x, 0, hit.normal.z);
                Debug.DrawRay(contact.point, proj, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 10f);
                //velocity -= Vector3.Project(velocity, normal) * bounceFactor;
            }

        }
    }
}
