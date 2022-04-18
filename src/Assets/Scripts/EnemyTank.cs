using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoSingletonGeneric <EnemyTank>
{
    protected override void Awake()
    {
        base.Awake();
    }
    public void EnemyMovement()
    {
        Debug.Log("Calling Enemy Movement function");
    }
}
