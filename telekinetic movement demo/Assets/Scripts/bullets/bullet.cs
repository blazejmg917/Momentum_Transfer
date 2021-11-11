using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [Header("general bullet settings")]
    [Tooltip("the particle effect for a bullet collision")]
    public ParticleSystem hitEffect;
    [Tooltip("the particle effect to be shown while the bullet is traveling")]
    public ParticleSystem flyEffect;
    [Tooltip("the velocity of this bullet")]
    public Vector3 velocity;
    [Tooltip("the starting velocity of this bullet")]
    public Vector3 startVelocity;
    [Tooltip("the rigidbody of this bullet")]
    public Rigidbody rb;
    //this bullet's mass"
    private float mass;
    [Tooltip("this bullet's speed")]
    public float speed;
    [Tooltip("the damage dealt by this bullet")]
    public float damage;
    [Tooltip("the time it takes for this bullet to destroy itself")]
    public float destroyTime;
    [Tooltip("a factor by which the knockback this bullet deals is multiplied")]
    public float knockback;
    [Tooltip("true if this bullet will damage the player, false if it will damage the enemy")]
    public bool hostile;


    // Start is called before the first frame update
    public virtual void Start()
    {
        mass = rb.mass;
        if(flyEffect != null)
        {
            Instantiate(flyEffect, parent: transform);
        }
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        //get current velocity
        rb.velocity = startVelocity;
        velocity = rb.velocity * Time.timeScale;
        //if the destroy timer has hit 0, destroy this object
        if (destroyTime <= 0f)
        {
            OnTimeRunout();
        }
        //else, decrease the timer
        else
        {
            destroyTime -= Time.fixedDeltaTime;
        }
    }

    //set the bullet's velocity to the given vector
    public void setVelocity(Vector3 vel)
    {
        startVelocity = vel;
        rb.velocity = vel;
    }

    //add the given vector to the bullet's current velocity
    public void addVelocity(Vector3 vel)
    {
        rb.velocity += vel;
    }

    //add a force to the bullet, which adjusts the momentum and in turn the velocity (yes this should be an impulse for it to properly adjust momentum, but oh well)
    public virtual void addForce(Vector3 force)
    {
        Vector3 momentum = velocity * mass;
        momentum += force;
        velocity += momentum / mass;
    }

    //get the vector of the strength of the impact the bullet produces, used to apply force to collided object
    public virtual Vector3 getImpact()
    {
        //Debug.Log("Vel: " + velocity + " kb: " + knockback + " mass: " + mass);
        return velocity * knockback * mass;
    }

    //get the bullet's starting speed
    public float getSpeed()
    {
        return speed;
    }

    //get the bullet's mass
    public float getMass()
    {
        return mass;
    }

    //get the damage the bullet deals
    public virtual float getDamage()
    {
        return damage;
    }

    //called when hitting a valid  target
    public virtual void HitTarget( GameObject target)
    {
        DealDamage(target, getDamage());
        //check if a force can be applied and if so, apply it
        if (target.layer == LayerMask.NameToLayer("Interactable"))
        {
            Debug.DrawRay(transform.position, getImpact(), Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 10f);
            ApplyForceToTarget(target, getImpact());
        }
        DestroyThis();
    }

    //deal damage to a target
    public virtual bool DealDamage( GameObject target, float damage )
    {
        //if the target has an OtherHealth component, deal damage
        if ( target.GetComponent<OtherHealth>())
        {
            target.GetComponent<OtherHealth>().Damage(getDamage());
            return true;
        }
        //if the target has a PlayerHealth component, deal damage
        else if (target.GetComponent<PlayerHealth>())
        {
            Debug.Log("player hit");
            target.GetComponent<PlayerHealth>().Damage(getDamage());
            return true;
        }
        return false;
    }

    //called when destroyTime runs out before bullet has hit an object
    public virtual void OnTimeRunout()
    {
        Destroy(gameObject);
    }

    //destroy the game object and cause a particle effect
    public virtual void DestroyThis()
    {
        Instantiate(hitEffect, transform.position, Quaternion.LookRotation(-velocity));
        Destroy(gameObject);
    }

    //called when hitting a non-interactable object such as a wall
    public virtual void OnWallHit( Collision col )
    {
        DestroyThis();
    }

    void OnCollisionEnter(Collision col)
    {
        Collider other = col.collider;
        //if the bullet is colliding with another projectile, ignore the collision
        if( other.transform.tag == "projectile" || other.transform.tag == "pickup")
        {
            return;
        }
        //if the bullet is hostile
        if (hostile)
        {
            //if the other object is the player, deal damage and apply a force
            if (other.transform.tag == "Player")
            {
                HitTarget(other.gameObject);
                
            }
            //if the other object is an ally, deal damage and apply a force if applicable
            if (other.transform.tag == "ally")
            {
                HitTarget(other.gameObject);
                
            }
            //if the other object is an enemy, ignore the collision
            if( other.transform.tag == "enemy")
            {
                return;
            }
        }
        //if the bullet is not hostile
        else
        {
            //if the other object is an enemy, deal damage and apply a force if applicable
            if (other.transform.tag == "enemy")
            {
                HitTarget(other.gameObject);
            }
            //if the other object is the player or an ally ignore the collision
            if (other.transform.tag == "Player" || other.transform.tag == "ally")
            {
                return;
            }
        }
        //if the other object is a destructible, deal damage and apply a force if applicable
        if (other.transform.tag == "destructible")
        {
            HitTarget(other.gameObject);
            
        }
        //if the other object is a different object with health, deal damage and apply a force if applicable
        else if (other.transform.tag == "hasHealth")
        {
            HitTarget(other.gameObject);
            
        }
        //Debug.Log("collided with: " + other.gameObject.tag);
        //destroy the bullet
        OnWallHit(col);
    }

    //apply the necessary force to a target
    public virtual void ApplyForceToTarget(GameObject target, Vector3 force)
    {
        target.GetComponent<Interactable>().ApplyForce(force);
    }
}
