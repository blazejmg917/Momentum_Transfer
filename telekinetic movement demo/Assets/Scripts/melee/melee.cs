using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{
    [Tooltip("the damage dealt by a melee hit")]
    public float damage;
    [Tooltip("the particle effect used by the melee attack")]
    public ParticleSystem hitEffect;
    [Tooltip("the force applied to each enemy hit by the melee attack")]
    public float force;
    [Tooltip("the time the hitbox of the melee attack stays active")]
    public float duration = .1f;
    [Tooltip("whether or not the melee attack can hit the same enemy multiple times")]
    public bool multihit;
    //a list of all of the targets that have been hit by the melee attack
    private ArrayList hits;
    void Start()
    {
        //set up the arraylist
        hits = new ArrayList();
        //instantiate the particle effect
        Instantiate(hitEffect, transform.position, transform.rotation);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //decrease the timer
        duration -= Time.fixedDeltaTime;
        //if the timer hits 0, destroy the gameobject
        if( duration <= 0f)
        {
            Destroy(gameObject);
        }
    }
    //deals damage to the object
    private bool DealDamage(GameObject target)
    {
        //if the target can take damage, damage the target
        if (target.GetComponent<OtherHealth>())
        {
            target.GetComponent<OtherHealth>().Damage(damage);
            return true;
        }
        return false;
    }

    void OnTriggerEnter(Collider other)
    {
        //don't hit the player with their own melee
        if (other.gameObject.CompareTag("Player"))
        {
            return;
        }
        //if the target has already been hit, and the attack is not a multihit attack, skip this target
        if (hits.Contains(other.gameObject) && !multihit)
        {
            return;
        }
        //if the target is an enemy, is destructible, or is a miscellaneous object with health, deal damage
        if( other.transform.tag == "enemy" || other.transform.tag == "hasHealth" || other.transform.tag == "destructible")
        {
            DealDamage(other.gameObject);
        }
        //if the object is interactable, apply a force to it
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            other.gameObject.GetComponent<Interactable>().ApplyForce( transform.forward.normalized * force);
        }
        //if the melee attack isn't a multihit, add this target to the list of hit targets
        if (!multihit)
        {
            hits.Add(other.gameObject);
        }
    }
}
