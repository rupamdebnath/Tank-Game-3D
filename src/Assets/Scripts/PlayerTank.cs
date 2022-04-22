using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoSingletonGeneric<PlayerTank>
{
    //Rigidbody rb;
    RaycastHit hit;
    Camera cam;

    public float getSpeed()
    {
        return 5f;
    }

}
