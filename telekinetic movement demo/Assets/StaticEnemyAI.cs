using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemyAI : MonoBehaviour
{
    [Tooltip("the distance at which the enemy can see the player")]
    public float viewDist;
    [Tooltip("the angle at which the enemy cans see the player (total FOV, so half of this angle on either side)")]
    [Range(0, 360)]
    public float viewAngle;
    [Tooltip("the speed at which the enemy rotates")]
    public float rotateSpeed;
    [Tooltip("the angle at which the enemy will fire at the player")]
    public float fireAngle;
    [Tooltip("the player GameObject")]
    public GameObject player;
    [Tooltip("the bullet that the GameObject fires")]
    public GameObject bullet;
    [Tooltip("the gun where the bullet are fired from")]
    public GameObject gun;
    [Tooltip("the maximum cooldown for the enemy's bullets")]
    public float maxCooldown;
    [Tooltip("the script to call for movement")]
    public DummyEnemy move;
    [Tooltip("the player layer to search for")]
    public LayerMask playerMask;
    //obstacle layers to avoid
    private int obstacleMask;
    //whether or not the enemy is locked onto the player
    private bool playerLock = false;
    //current cooldown for firing
    private float cooldown = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //set up the obstacle mask for walls
        obstacleMask = 1 << 11;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if the player has not been found, search for the player
        if (!playerLock)
        {
            SearchForPlayer();
        }
        //if the player has been found, try to follow/shoot the player
        else
        {
            PlayerFound();
        }
        //if the cooldown is not yet 0, decrease the cooldown
        if(cooldown >= 0f)
        {
            cooldown -= Time.fixedDeltaTime;
        }
    }
    //search for the player
    void SearchForPlayer()
    {
        //determine the vector between the player and this object
        Vector3 toPlayer = (player.transform.position - transform.position);
        //if the player is within the view angle of the enemy's line of sight
        if (Vector3.Angle(transform.forward, toPlayer.normalized) < (viewAngle / 2) && toPlayer.magnitude < viewDist)
        {
            //Debug.Log("player within potential view. Ang: " + toPlayer.normalized + " dist: " + toPlayer.magnitude);
            //if there are not obstacles beetween the player and the enemy
            if (!Physics.Raycast(origin: transform.position, direction: toPlayer.normalized, maxDistance: toPlayer.magnitude, layerMask: obstacleMask))
            {
                //Debug.Log("player seen");
                //note that the player has been spotted
                playerLock = true;
                return;
            }
            //otherwise, spin and search for the player
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(transform.right), rotateSpeed * Time.fixedDeltaTime);

    }
    //what to do if the player has been located
    void PlayerFound()
    {
        //determine the vector between the player and this object
        Vector3 toPlayer = (player.transform.position - transform.position);
        toPlayer = new Vector3(toPlayer.x, 0, toPlayer.z);
        //if the player is within the field of view
        if (Vector3.Angle(transform.forward, toPlayer.normalized) < (viewAngle / 2) && toPlayer.magnitude < viewDist)
        {
            //if there is an obstacle between the player and the enemy, the player can no longer be seen and is lost
            if (Physics.Raycast(origin: transform.position, direction: toPlayer.normalized, maxDistance: toPlayer.magnitude, layerMask: obstacleMask))
            {
                //Debug.Log("player lost");
                playerLock = false;
                return;
            }
            //rotate towards the player
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(toPlayer), rotateSpeed * Time.fixedDeltaTime);
            //if the player is within the fire angle, fire towards the player
            if (Vector3.Angle(transform.forward, toPlayer.normalized) < (fireAngle / 2))
            {
                Fire();
            }
        }
        //else if the player is not within the fov, the player is lost
        else
        {
            //Debug.Log("player lost");
            playerLock = false;
            return;
        }
        
    }
    //fire a bullet
    void Fire()
    {
        //if the cooldown is zero
        if(cooldown <= 0f)
        {
            //Debug.Log("bullet fired");
            //instantiate the new bullet
            GameObject newProjectile = (GameObject)Instantiate(bullet.gameObject, gun.transform.position, transform.rotation);
            newProjectile.SetActive(true);
            //get the bullet script
            bullet newProjBullet = newProjectile.GetComponent<bullet>();
            //set the cooldown to max
            cooldown = maxCooldown;
            //Debug.Log("shoot: " + cooldown);
            //give the bullet it's velocity
            newProjBullet.setVelocity(newProjBullet.getSpeed() * transform.forward);
        }
    }
}
