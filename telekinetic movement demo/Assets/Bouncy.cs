using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    [Tooltip("the bounciness of this object. determines what an object's force is multiplied by if it bounces off of this object")]
    public static float bounciness = 2F;

    public static float getBounce()
    {
        return bounciness;
    }
}
