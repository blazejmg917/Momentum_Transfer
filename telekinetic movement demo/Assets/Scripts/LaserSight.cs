using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSight : MonoBehaviour
{
    //help with LineRenderers found in youtube video tutorial https://www.youtube.com/watch?v=hUg3UfE186Q

    [Tooltip(" the LineRenderer we need to adjust")]
    public LineRenderer line;
    //the maximum distance that can be viewed
    private float viewDist;
    //the layer for interactable objects
    private string interactLayer = "Interactable";

    // Start is called before the first frame update
    void Start()
    {
        //set up the linerenderer
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //set up a raycasthit
        RaycastHit hit;
        //set the layer mask to only read for transparent (and projectile) objects
        int layerMask = (1 << 10) + (1 << 12);
        //if a raycast hits anything other than a transparent object, draw a line to that object
        if(Physics.Raycast( origin: transform.position, direction: transform.forward, hitInfo: out hit, maxDistance: viewDist, layerMask: ~layerMask)){
            line.SetPosition(1, new Vector3(0,0,hit.distance));
            //Debug.Log("raycast hit at dist");
        }
        //else draw a line to the laser sight's max distance
        else
        {
            line.SetPosition(1, new Vector3(0, 0, viewDist));
        }
    }
    //sets the length of the laser
    public void SetLength(float dist)
    {
        //Debug.Log("length set");
        viewDist = dist;
        line.SetPosition(1, new Vector3(0,0,viewDist));
        
    }
    //uses the direct line and length of the laser to determine if there is a suitable target to interact with
    public GameObject checkTarget()
    {
        //set up a raycasthit
        RaycastHit hit;
        //set the layer mask to only read for transparent objects
        int layerMask = (1 << 10) + (1 << 12);
        //if the raycast hits anything other than a transparent object
        if (Physics.Raycast(origin: transform.position, direction: transform.forward, hitInfo: out hit, maxDistance: viewDist, layerMask: ~layerMask))
        {
            Debug.Log(hit.collider.gameObject.layer);
            //if the object was an interactable object, return that object
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer(interactLayer)){
                return hit.collider.gameObject;
            }
        }
        //else return nothing
        return null;
    }
}
