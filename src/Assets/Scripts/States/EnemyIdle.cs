using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyState
{
    public override void OnEnterState()
    {
        base.OnEnterState();
        
    }
    private void Update()
    {
        Debug.Log("Inside Child");
    }
}
