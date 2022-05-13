using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : EnemyState
{
    public override void OnEnterState()
    {
        base.OnEnterState();

    }
    private void Start()
    {
        Debug.Log("Inside Chase");
    }
}
