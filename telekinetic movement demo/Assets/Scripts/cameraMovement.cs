using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    [Tooltip("player object")]
    public Rigidbody player;
    [Tooltip("how zoomed in the camera is")]
    public float zoom = 10f;
    [Tooltip("z offset - gives a greater angle to the camera the bigger it is. 0 is directly above")]
    public float zOffset = 1.5f;
    //y offset
    private float yOffset;
    [Tooltip("max distance the camera can move per frame")]
    public float maxCameraDist;
    //describe this better at some point
    [Tooltip("factor used to determine camera move speed after teleport.")]
    public float cameraMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //set the y offset based on the zoom given
        yOffset = 100 / zoom;
        //set up the camera's position based on y and z offsets
        transform.position = new Vector3(player.position.x, player.position.y + yOffset, player.position.z - zOffset);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //determine the position the camera should be this frame
        Vector3 targetPos = new Vector3(player.position.x, player.position.y + yOffset, player.position.z - zOffset);
        //get the vector between current camera position and desired camera position
        Vector3 moveDir = targetPos - transform.position;
        //if the distance between this two is less than/equal to the maximum camera move distance per frame, jump to the desired position
        if (moveDir.magnitude <= maxCameraDist) {
            transform.position = targetPos;
        }
        //else move towards the desired position at a speed determined by to the distance between the current and desired positions and other given variables (gives it a smooth effect)
        else
        {
            transform.position += moveDir.normalized * (moveDir.magnitude / (maxCameraDist * cameraMoveSpeed));
        }
    }
}
