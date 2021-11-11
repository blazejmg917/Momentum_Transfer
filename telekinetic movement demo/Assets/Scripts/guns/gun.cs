using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    
    //the current cooldown to shoot
    protected float cooldown;
    [Header("general gun settings")]
    [Tooltip("The time between shots")]
    public float maxCooldown;
    [Tooltip("The bullet projectile that this gun fires")]
    public bullet projectile;
    [Tooltip("the gun object to be fired from")]
    public GameObject gunPiece;
    [Tooltip("the sights used by this gun")]
    public LaserSight sight;
    [Tooltip("the gun's length")]
    public float length;
    [Tooltip("the spread of the bullets fired by this gun")]
    [Range(0, 360)]
    public float spread = 0f;
    [Tooltip("the starting x position of the gun")]
    public float xPos = .3f;
    [Tooltip("the starting y position of the gun")]
    public float yPos = 0f;
    [Tooltip("the starting z position of the gun")]
    public float zPos = .485f;
    // Start is called before the first frame update
    void Start()
    {
        //set the current cooldown to 0, and set up the gun piece
        cooldown = 0f;
        gunPiece = GetComponent<GameObject>();
        
    }

    //gets the gun's starting position
    public Vector3 getStartPos()
    {
        return new Vector3(xPos, yPos, zPos);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if the cooldown is not yet 0, decrease the cooldown
        if(cooldown > 0f)
        {
            cooldown -= Time.fixedDeltaTime;
        }
    }
    //set the laser sight this gun uses
    public LaserSight getSights()
    {
        return sight;
    }
    //rework ******************
    public void setBulletType( )
    {
        
    }
    //shoot a bullet
    public virtual void Shoot()
    {
        //if the cooldown is zero, spawn a bullet and set the cooldown
        if(cooldown <= 0f)
        {

            SpawnBullet(ChooseHeading());
            cooldown = maxCooldown;

        }
        
    }
    //spawn a new bullet pointing in the given direction
    public void SpawnBullet( Vector3 heading )
    {
        //create the new projectile and set it active
        GameObject newProjectile = (GameObject)Instantiate(projectile.gameObject, transform.position + transform.forward * (length), transform.rotation);
        newProjectile.SetActive(true);
        //get the script for the bullet
        bullet newProjBullet = newProjectile.GetComponent<bullet>();
        Debug.Log("shoot: " + cooldown);
        //set the bullet's velocity
        newProjBullet.setVelocity(newProjBullet.getSpeed() * heading);
    }
    //determine the direction the bullet will fire in. Used to give spread to the bullets fired
    public virtual Vector3 ChooseHeading()
    {
        Vector3 heading;
        //if there is a non-zero spread, get a random heading withing the angle
        if (spread > 0f)
        {
            heading = RandSpreadAngle();
        }
        //else set the heading to straight forward
        else
        {
            heading = transform.forward;
        }
        //return the heading
        return heading;
    }
    //gets a heading from within the angle given by the spread of the bullet
    private Vector3 RandSpreadAngle()
    {
        //determine the random angle
        float randChange = Random.Range(-spread / 2, spread / 2);
        //get the heading that is the determined angle away from the forward vector
        Vector3 newDir = Quaternion.AngleAxis(randChange, Vector3.up) * transform.forward;
        return newDir;
    }
}
