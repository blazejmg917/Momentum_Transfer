using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //the input system
    InputSystemAsset inputs;
    //the player's Rigidbody component
    private Rigidbody rb;
    //the movement direction from player input movement, stays local after teleportation
    private Vector2 move;
    //input velocity converted to 3d
    private Vector3 localVelocity;
    //aim direction from player input movement, stays local after teleportation
    private Vector2 aim;
    //forces from an external object, transferred upon teleportation
    private Vector3 extForces;
    //the total cooldown for the dash action
    private float dashTime;
    //the current cooldown for the dash action
    private float dashCooldown = 0f;
    //the current melee cooldown
    private float meleeCooldown;
    //laser sight
    private LaserSight sight;
    //the number of guns
    private int numGuns = 0;
    //the script for the current gun
    private gun gunScript;
    //the object's mass in kg
    private float mass = 10f;

    [Header("physics stats")]
    [Tooltip("the player's movement speed")]
    public float speed = 5f;
    [Tooltip("the max speed at which you rotate")]
    public float rotateSpeed;
    [Tooltip("maximum distance for looking/warping")]
    public float viewdist = 20f;
    [Tooltip("the magnitude that external forces are decreased by every frame - consider changing")]
    public float friction = 10f;
    [Tooltip("the magnitude of the force that is added when you dash")]
    public float dashForce = 1000f;
    [Tooltip("the minimum velocity of this object")]
    public float minVel = .1f;

    [Header("other scripts/objects")]
    [Tooltip("the melee attack")]
    public GameObject meleeAttack;
    [Tooltip("the total cooldown for melee attack")]
    public float meleeCooldownTotal;
    [Tooltip("swap objects script")]
    public SwapObjects swap;
    [Tooltip("the interactable script")]
    public Interactable interact;
    [Tooltip("the current starting gun")]
    public GameObject gun;
    [Tooltip("a second gun to start with (debugging mostly)")]
    public GameObject secondGun;
    [Tooltip("Arraylist of all available guns")]
    public ArrayList guns;
    [Tooltip("the player's warp effect")]
    public ParticleSystem warpEffect;
    [Tooltip("the GameManager")]
    private GameManager instance;


    void Start()
    {
        //sets up inputs
        inputs = new InputSystemAsset();
        inputs.actions.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        inputs.actions.Movement.canceled += ctx => move = Vector2.zero;
        inputs.actions.Aim.performed += ctx => aim = ctx.ReadValue<Vector2>();
        inputs.actions.Aim.canceled += ctx => aim = Vector2.zero;
        inputs.actions.Shoot.performed += ctx => Shoot();
        inputs.actions.Dash.performed += ctx => Dash();
        inputs.actions.Warp.performed += ctx => Warp();
        inputs.actions.Melee.performed += ctx => Melee();
        inputs.actions.Pause.performed += ctx => Pause();
        inputs.actions.NextGun.performed += ctx => NextGun();
        inputs.actions.PrevGun.performed += ctx => PrevGun();
        inputs.Enable();
        //get the interactable script
        interact = GetComponent<Interactable>();
        //get the rigidbody
        rb = GetComponent<Rigidbody>();
        //get the object's mass
        mass = rb.mass;
        //initialize the external forces to nothing
        extForces = new Vector3(0f, 0f, 0f);
        //determine the dash cooldown based on friction and force
        dashTime = dashForce / friction;
        //get the game manager
        instance = GameManager.GetInstance();
        //set up the guns list
        guns = new ArrayList();
        //add the starter gun to the list
        AddGun(gun);
        //if there is a second gun given, set up that gun and add it to the list
        if (secondGun != null)
        {
            AddGun(secondGun);
            numGuns = 2;
            //secondGun.SetActive(false);
        }
        //set the starter gun active
        //gun.SetActive(true);
        SwapGun(0);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if the game isn't paused
        //if (!instance.Paused())
        //{
        //set the local velocity based on the input movement given
        localVelocity = new Vector3(move.x * speed, 0, move.y * speed);
        //Debug.Log("local vel: " + localVelocity);
        //Debug.Log("ext force: " + extForces);
        //calculate momentum
        Vector3 momentum = localVelocity * mass;
        //change momentum based on external forces
        momentum += extForces * Time.fixedDeltaTime;
        //Debug.Log("momentum: " + momentum);
        //apply momentum to velocity
        rb.velocity = momentum / mass;
        //Debug.Log("final vel: " + rb.velocity);
        //get the rotation based on aim input given
        Vector3 rot = new Vector3(aim.x, 0, aim.y);
        //adjust rotation 
        rot *= viewdist;
        rot += rb.position;
        //if a reasonably large value is read through aim that it must be player control rather than noise, look in that direction
        if (rot != new Vector3(0, 0, 0) && (Mathf.Abs(aim.x) > .1 || Mathf.Abs(aim.y) > .1))
        {
            //Debug.Log("aim: " + rot.x + " " + rot.z);
            Quaternion look = Quaternion.LookRotation(rot - rb.position);
            //rb.rotation = look;
            rb.rotation = Quaternion.RotateTowards(rb.rotation, look, rotateSpeed * Time.fixedDeltaTime);
        }
        //if dash is on cooldown, reduce the cooldown
        if (dashCooldown > 0)
        {
            dashCooldown--;
        }
        //if melee is on cooldown, reduce the cooldown
        if (meleeCooldown > 0)
        {
            meleeCooldown -= Time.fixedDeltaTime;
        }
        //if there are any external forces, decrease them with friction over time
        if (extForces.magnitude >= 0f)
        {
            float oldMag = extForces.magnitude;
            extForces -= extForces.normalized * friction;
            if(extForces.magnitude >= oldMag)
            {
                extForces = Vector3.zero;
            }
        }
        //}
        //else
        //{
        //if the game is paused, do not move
        //rb.velocity = Vector3.zero;
        //}
        if (rb.velocity.magnitude < minVel)
        {
            rb.velocity = Vector3.zero;
        }
    }

    //use a melee attack
    void Melee()
    {
        //if the game isn't paused
        if (!instance.Paused())
        {
            //check dash cooldown
            if (meleeCooldown <= 0f)
            {
                //instantiate the melee attack hitbox and set the cooldown
                Instantiate(meleeAttack, transform.position, transform.rotation);
                meleeCooldown = meleeCooldownTotal;
            }
        }
    }

    //use a gun attack
    void Shoot()
    {
        //if the game isn't paused
        if (!instance.Paused())
        {
            //call the gun script to shoot
            gunScript.Shoot();
        }
    }

    //dash in the current direction of movement
    void Dash()
    {
        //if the game isn't paused
        if (!instance.Paused())
        {
            //check dash cooldown
            if (dashCooldown <= 0f)
            {
                //if you aren't moving on your own
                if (localVelocity.magnitude == 0f)
                {
                    //dash in the aim direction
                    ApplyForce(transform.forward.normalized * dashForce);
                }
                //if you are moving
                else
                {
                    //dash in the direction of native movement
                    ApplyForce(localVelocity.normalized * dashForce);
                }
                //Debug.Log("dir: "+transform.forward.normalized);
                //Debug.Log("force applied: " + (transform.forward.normalized * dashForce));
                //set the cooldown timer
                //Debug.Log("dash");
                //set the cooldown
                dashCooldown = dashTime;
            }
            else
            {
                //Debug.Log("cooldown left: " + dashCooldown);
            }
        }

    }

    //attempt to warp and swap places with another object
    void Warp()
    {
        //if the game isn't paused
        if (!instance.Paused())
        {//check for a valid target
            GameObject target = sight.checkTarget();
            //if a target is found swap places
            if (target)
            {
                //Debug.Log("success");
                Interactable interact2 = target.GetComponent<Interactable>();
                swap.Swap(interact, interact2, true, warpEffect);
            }
            else
            {
                //Debug.Log("failure");
            }
        }
    }

    //Pause or unpause
    void Pause()
    {
        instance.Pause();
    }

    //apply a force to this object
    public void ApplyForce(Vector3 force)
    {
        extForces += force;
    }

    //set this object's external force
    public void SetForce(Vector3 force)
    {
        extForces = force;
    }

    //get this object's external force
    public Vector3 GetForce()
    {
        return extForces;
    }

    //get this object's position
    public Vector3 GetPos()
    {
        return rb.position;
    }

    //set this object's position
    public void SetPos(Vector3 pos)
    {
        rb.position = pos;
    }

    //swap to the next gun
    public void NextGun()
    {
        //Debug.Log("next gun");
        //if you have more than one gun
        if (guns.Count > 1)
        {
            //get the index of the next gun
            int newIndex = guns.IndexOf(gun) + 1;
            //wrap around to 0 if you hit the end of the list
            if (newIndex >= guns.Count)
            {
                //Debug.Log("wrapped around from " + newIndex + " to 0");
                newIndex = 0;

            }
            //swap to the new gun
            SwapGun(newIndex);
        }
        else
        {
            //Debug.Log("not enough guns to swap");
        }
    }

    //swap to the previous gun
    public void PrevGun()
    {
        //Debug.Log("Prev gun");
        //if you have more than one gun
        if (guns.Count > 1)
        {
            //get the index of the previous gun
            int newIndex = guns.IndexOf(gun) - 1;
            //wrap around to the end of the list if you hit the start
            if (newIndex < 0)
            {

                newIndex = guns.Count - 1;
                //Debug.Log("wrapped around from -1 to" + newIndex);

            }
            //swap to the previous gun
            SwapGun(newIndex);

        }
        else
        {
            //Debug.Log("not enough guns to swap");
        }
    }

    //swaps to the gun with the specified index
    public void SwapGun(int index)
    {
        if (index < 0 || index >= numGuns)
        {
            Debug.LogWarning("tried to get gun out of bounds");
        }
        //deactivate the current gun
        gun.SetActive(false);
        //get the new gun and set it up
        gun = (GameObject)guns[index];
        GunSetup(gun);
        //Debug.Log("guns swapped");
    }

    //set up the given gun
    public void GunSetup(GameObject gun)
    {
        //Debug.Log("setup gun");
        //set up the gun script
        gunScript = gun.GetComponent<gun>();
        //set up the sights
        sight = gunScript.getSights();
        sight.SetLength(viewdist);
        //activate the gun
        Vector3 posVector = gunScript.getStartPos();
        gun.transform.position = transform.position + transform.TransformDirection(posVector);
        gun.SetActive(true);
    }

    //add a new gun to the list
    public void AddGun(GameObject newGun)
    {
        
        if (!newGun.GetComponent<gun>())
        {
            Debug.LogWarning("new gun not added, no gun script component");
            return;
            
        }
        //Debug.Log("adding gun");
        //if the gun isn't already contained in the list
        if (!guns.Contains(newGun))
        {
            //add the new gun to the list and increase the count of guns
            GameObject newGunCopy = Instantiate(newGun, parent: transform);
            guns.Add(newGunCopy);
            //create the new gun
            //Debug.Log("gun added");
            numGuns++;
            SwapGun(numGuns - 1);
        }
        else
        {
            //Debug.Log("already has gun");
        }
    }
    //remove a gun from the list
    public void RemoveGun(GameObject gunToRemove)
    {
        //if the gun is contained in the list
        if (guns.Contains(gunToRemove) && numGuns > 1)
        {
            //remove the gun from the list and decrease the count of guns
            guns.Remove(gunToRemove);
            //Debug.Log("gun removed");
            numGuns--;
            PrevGun();
            Destroy(gunToRemove);
        }
        else
        {
            //Debug.Log("does not have gun");
        }
    }
}
