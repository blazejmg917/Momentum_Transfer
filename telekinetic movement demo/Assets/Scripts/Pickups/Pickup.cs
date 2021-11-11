using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [Tooltip("how quickly the pickup rotates")]
    public float rotateSpeed = 60F;
    [Tooltip("how far up and down the pickup can bob")]
    public float bobAmplitude = .5F;
    [Tooltip("determines how quickly the pickup bobs up and down")]
    public float bobPeriod = 1F;
    [Tooltip("starting y position")]
    public float startHeight = 1.5f;


    //float to keep track of the bobbing

    /**
     * determines what occurs when a player or other valid interactable object picks up this object
     */
    public abstract void OnPickup(GameObject pickupper);

    /**
     * checks if the object attempting to pick up this Pickup is a valid pickupper (holder of the item_
     */
    public abstract bool CheckPickupper(GameObject pickupper);

    void OnTriggerEnter(Collider other)
    {
        //if the collider is a valid pickupper, call the pickup method for them
        if (CheckPickupper(other.gameObject))
        {
            OnPickup(other.gameObject);
        }

    }

    void FixedUpdate()
    {
        //rotate slowly and bob slowly up and down.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(transform.right), rotateSpeed * Time.fixedDeltaTime);
        transform.position = new Vector3(transform.position.x, startHeight + bobAmplitude * Mathf.Sin(Time.fixedTime * Mathf.PI / bobPeriod), transform.position.z);
        //Debug.Log(transform.position);
    }
}
