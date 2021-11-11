using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Tooltip("the rigidbody to interact with")]
    public Rigidbody rb;
    //forces from an external object, transferred upon teleportation
    private Vector3 extForces;
    [Tooltip("if this object can be swapped with")]
    public bool swappable;
    [Tooltip("the multiplier applied to the normal force when the object hits a wall")]
    public static float wallMod = 1.1F;
    [Tooltip("the multiplier applied to the normal force when the object hits another interactable object")]
    public static float interactMod = 1.01F;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    //apply a force to this object
    public virtual void ApplyForce(Vector3 force)
    {

            extForces += force;

    }
    //set this object's external force
    public virtual void SetForce(Vector3 force)
    {

            extForces = force;

    }
    //get this object's external force
    public virtual Vector3 GetForce()
    {

        return extForces;
    }
    //get this object's position
    public virtual Vector3 GetPos()
    {

        return rb.position;
    }
    //set this object's position
    public virtual void SetPos(Vector3 pos)
    {
 
            rb.position = pos;

    }

    void OnCollisionEnter( Collision col )
    {
        //Debug.Log(col.contactCount);
        foreach (ContactPoint contact in col.contacts)
        {
            //the otherObject is the object this object collided with
            GameObject otherObject = contact.otherCollider.gameObject;
            //Debug.DrawRay(contact.point, contact.normal * 100, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 10f);
            //if the object collided with a wall
            if (otherObject.CompareTag("Wall")){
                //Debug.Log("hit wall");
                //determine the normal vector from that wall, and calculate the projection of the current external force on the normal vector from the collision point
                //this is the magnitude of the external force pointing towards the contact point, but in the opposite direction
                Vector3 normalForceExt = GetNormalProj( contact, true );

                //if that portion of the negative external force is not zero, apply it ot the object to remove that portion of the external force
                if (normalForceExt != Vector3.zero)
                {
                    ApplyForce(normalForceExt * wallMod);
                    //Debug.Log("force after application: " + GetForce());
                }
            }
            //if the object collided with another interactable creature
            if(otherObject.CompareTag("Player") || otherObject.CompareTag("enemy") || otherObject.CompareTag("ally"))
            {
                //Debug.Log("hit other person");
                //determine the normal vector from that wall, and calculate the projection of the current external force on the normal vector from the collision point
                //this is the magnitude of the external force pointing towards the contact point
                Vector3 normalForceExt = GetNormalProj(contact, false);

                //if that portion of the external force is not zero, apply its negative to the object to remove that portion of the external force,
                //then apply it to the other interactable object
                if (normalForceExt != Vector3.zero)
                {
                    ApplyForce(-normalForceExt * interactMod);
                    otherObject.GetComponent<Interactable>().ApplyForce(normalForceExt);
                    //Debug.Log("force after application: " + GetForce());
                }

            }
            //if the object collided with a destructible object
            if (otherObject.CompareTag("destructible"))
            {
                //Debug.Log("hit destructible object");
                //if the force is great enough to break this object, destroy the object
                if (otherObject.GetComponent<BreakableHealth>().ApplyForce(GetForce()))
                {
                    otherObject.GetComponent<BreakableHealth>().Die();
                }
                //otherwise deal with the external force on this object as if the breakable object were a wall.
                else
                {

                    //determine the normal vector from that wall, and calculate the projection of the current external force on the normal vector from the collision point
                    //this is the magnitude of the external force pointing towards the contact point, but in the opposite direction
                    Vector3 normalForceExt = GetNormalProj(contact, true);

                    //if that portion of the negative external force is not zero, apply it ot the object to remove that portion of the external force
                    if (normalForceExt != Vector3.zero)
                    {
                        ApplyForce(normalForceExt * wallMod);
                        //Debug.Log("force after application: " + GetForce());
                    }
                }
            }
            //if the object collided with a bouncy object
            if (otherObject.CompareTag("bouncy"))
            {
                //Debug.Log("hit bouncy object");
                //determine the normal vector from that bouncy object, and calculate the projection of the current external force on the normal vector from the collision point
                //this is the magnitude of the external force pointing towards the contact point, but in the opposite direction
                Vector3 normalForceExt = GetNormalProj(contact, true);

                //if that portion of the negative external force is not zero, multiply it by the bounciness of the wall and then apply it to the current force to make the object bounce
                if (normalForceExt != Vector3.zero)
                {
                    ApplyForce(normalForceExt * Bouncy.getBounce());
                    //Debug.Log("force after application: " + GetForce());
                }
            }

        }
    }

    //gets the projection of the external force vector onto the given vector.
    private Vector3 GetProjExtForceonB( Vector3 b )
    {
        Vector3 a = GetForce();
        //Vector3 proj2 = ((Vector3.Dot(a, b)) / (b.magnitude * b.magnitude )) * b;
        Vector3 proj = Vector3.Project(a, b);
        //Debug.Log(proj2 - proj);
        if(Vector3.Angle(proj, b) < 90)
        {
            return Vector3.zero;
        }
        return proj;
    }

    //gets the normal from a contact point and calculates the projection of the current force onto that normal
    //contact: the ContactPoint to calculate the normal from
    //reverse: whether or not the projection needs to be reversed.
    private Vector3 GetNormalProj( ContactPoint contact, bool reverse )
    {
        //get the normal force in 2d from the contact point
        Vector3 normal = new Vector3(contact.normal.x, 0, contact.normal.z);
        //get the projection of the current force onto the normal
        Vector3 normalForceExt = GetProjExtForceonB(normal);
        //if necessary, reverse the force.
        if (reverse)
        {
            normalForceExt *= -1;
        }
        //Debug.Log("normal force: " + normalForceExt.magnitude + " force: " + GetForce());
        Debug.DrawRay(contact.point, normalForceExt, Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 10f);
        return normalForceExt;
    }

    public bool canSwap()
    {
        return swappable;
    }
}
