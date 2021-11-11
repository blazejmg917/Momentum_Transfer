using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Tooltip("the maximum health for this object")]
    public float maxHealth = 1;
    [Tooltip("the current health of this object")]
    public float currentHealth;
    [Tooltip("the default material for this object")]
    public Material defaultMat;
    [Tooltip("the damage material for this object")]
    public Material damageMat;
    [Tooltip("the length of time that you have invulnerability after getting hit")]
    public float invulnerabilityTimeMax;
    //the current timer on invulnerability
    private float invulnerabilityTime;
    //whether or not you are currently invulnerable
    private bool invulnerable = false;

    // Start is called before the first frame update
    void Start()
    {
        //set current health to max
        currentHealth = maxHealth;
    }
    void FixedUpdate()
    {
        //if player is invulnerable but the timer has run out
        if(invulnerabilityTime <= 0f && invulnerable)
        {
            //turn off invulnerability
            invulnerable = false;
            //switch back to the default material
            gameObject.GetComponent<MeshRenderer>().material = defaultMat;
        }
        //if player is invulnerable but the timer hasn't run out yet
        else if(invulnerable)
        {
            //decrease the timer
            invulnerabilityTime -= Time.fixedDeltaTime;
        }
    }
    // Damage the player
    public void Damage(float damage)
    {
        Debug.Log("player hit");
        //if player isn't invulnerable
        if (!invulnerable)
        {
            
            //decrease current health by the damage given
            currentHealth -= damage;
            Debug.Log("player hurt: health = " + currentHealth);
            //if health is less than 0
            if (currentHealth <= 0f)
            {
                //kill the player
                Die();
            }
            //switch to the damage material
            gameObject.GetComponent<MeshRenderer>().material = damageMat;
            //make player invulnerable and set up timer 
            invulnerable = true;
            invulnerabilityTime = invulnerabilityTimeMax;
        }
    }
    //kill the player (update)
    public void Die()
    {
        Application.Quit();
    }
}
