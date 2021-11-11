using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherHealth : MonoBehaviour
{
    [Tooltip("the maximum health for this object")]
    public float maxHealth = 1;
    [Tooltip("the current health for this object")]
    public float currentHealth;
    [Tooltip("the object that this health refers to")]
    public GameObject thisObject;
    [Tooltip("the default material for this object")]
    public Material defaultMat;
    [Tooltip("the damage material for this object")]
    public Material damageMat;
    [Tooltip("the length of time the damage mat stays active")]
    public float damageTimeMax;
    //current timer on the damage mat
    private float damageTime;
    //whether or not the damage mat is active
    private bool damaged;

    // Start is called before the first frame update
    void Start()
    {
        //set current health to max
        currentHealth = maxHealth;
    }
    void FixedUpdate()
    {        
        //if object is in the damaged state but the timer has run out
        if (damageTime <= 0f && damaged)
        {
            //turn off the damaged state
            gameObject.GetComponent<MeshRenderer>().material = defaultMat;
            damaged = false;
        }
        //else if the object is damaged
        else if (damaged)
        {
            //decrease the timer
            damageTime -= Time.fixedDeltaTime;
        }
    }
    // damage the object
    public void Damage( float damage )
    {
        //reduce the object's health by the amount of damage taken
        currentHealth -= damage;
        //if health hits 0, destroy this object
        if(currentHealth <= 0f)
        {
            Die();
        }
        //if the object isn't already in the damaged state, set the object to the damaged state
        if(!damaged)
        {
            damaged = true;
            gameObject.GetComponent<MeshRenderer>().material = damageMat;
            damageTime = damageTimeMax;
        }
    }
    //destroy this object
    public virtual void Die()
    {
        Destroy(gameObject);
    }

}
