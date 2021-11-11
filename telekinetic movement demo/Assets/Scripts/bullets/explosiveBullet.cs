using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosiveBullet : bullet
{
    [Header("explosion stats")]
    [Tooltip("the damage dealt by the explosion")]
    public float explosionDmg = 5;
    [Tooltip("the knockback force dealt by the explosion")]
    public float explosionForce = 400f;
    [Tooltip("the radius of the explosion's damage")]
    public float explosionRadius = 1f;
    //ensures that no objects are damaged twice
    private bool destroyed = false;

    //destroy the gameobject to cause an explosion
    public override void HitTarget(GameObject target)
    {
        DestroyThis();
    }

    //destroy the game object and cause an explosion which will damage all interactable objects within its radius
    public override void DestroyThis()
    {
        Explode();
        destroyed = true;
        base.DestroyThis();
    }

    public override void OnTimeRunout()
    {
        DestroyThis();
    }

    //explode and deal damage to all valid targets in range
    public virtual void Explode()
    {
        if (destroyed)
        {
            return;
        }
        int layerMask = (1 << 9) + (1 << 8) + (1 << 10) + (1 << 11);
        Collider[] targets = Physics.OverlapSphere(transform.position, explosionRadius, layerMask);
        Debug.Log("targets " + targets.Length);
        foreach(Collider target in targets)
        {
            Debug.Log("damaged " + target);
            DealDamage(target.gameObject, explosionDmg);

            if (target.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {
                
                Vector3 lineOfForce = target.transform.position - transform.position;
                Debug.Log("pushed " + target + " with force of " + lineOfForce.normalized * explosionForce);
                ApplyForceToTarget(target.gameObject, lineOfForce.normalized * explosionForce);
            }
        }
    }
}
