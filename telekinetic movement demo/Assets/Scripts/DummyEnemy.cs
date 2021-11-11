using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Gives the basic scripting for the enemy which handles the interactable script and the movement given each frame
public class DummyEnemy : MonoBehaviour
{
    [Tooltip("The rigidbody of this object")]
    public Rigidbody rb;
    //the movement from the interactable itself, stays local after teleportation
    private Vector3 localVelocity;
    //forces from an external object, transferred upon teleportation
    private Vector3 extForces;
    //object's mass in kg
    private float mass;
    [Tooltip("the magnitude that external forces are decreased by every frame")]
    public float friction = 10f;
    [Tooltip("the interactable script")]
    public Interactable interact;
    [Tooltip("normal material")]
    public Material defaultMat;
    [Tooltip("the material to be used when taking damage")]
    public Material damageMat;
    //the gamemanager
    private GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        //set up the interactable script
        interact = GetComponent<Interactable>();
        //initialize local velocity and external forces
        localVelocity = Vector3.zero;
        extForces = Vector3.zero;
        //get gamemanager instance
        instance = GameManager.GetInstance();
        //get mass from rigidbody
        mass = rb.mass;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if game isn't paused
        if (!instance.Paused())
        {
            //get external forces
            extForces = interact.GetForce();
            //calculate momentum
            Vector3 momentum = localVelocity * mass;
            //update momentum with forces
            momentum += extForces * Time.fixedDeltaTime;
            //set velocity from momentum
            rb.velocity = momentum / mass;
            //Debug.Log("force on enemy: " + extForces);
            //decrease external forces by friction
            if (extForces.magnitude < friction)
            {
                interact.SetForce(Vector3.zero);
            }
            else if (extForces.magnitude > 0f)
            {
                interact.ApplyForce(-extForces.normalized * friction);
            }
        }
    }
    //used to set the local velocity
    void SetLocalVelocity(Vector3 vel)
    {
        localVelocity = vel;
    }
    //used to set the rotation
    void SetRotationalVelocity(float vel)
    {

    }
    //used to adjust the local velocity
    void AddLocalVelocity(Vector3 vel)
    {
        localVelocity += vel;
    }
    //used to adjust the rotation
    void AddRotationalVelocity(float vel)
    {

    }
    //used to set the local velocity
    Vector3 GetLocalVelocity()
    {
        return localVelocity;
    }
    //used to set the rotation
    float GetRotationalVelocity()
    {
        return 0f;
    }
}
