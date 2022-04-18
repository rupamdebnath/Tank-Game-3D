using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoSingletonGeneric <PlayerTank>
{
    protected override void Awake()
    {
        base.Awake();
        Debug.Log("Inside Player movemernt Awake() for custom operations");
    }

    public void PlayerMovement()
    {
        Debug.Log("Calling Player Movement function");
    }
}
