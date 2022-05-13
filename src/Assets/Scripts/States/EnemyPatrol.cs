using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : EnemyState
{
    public override void OnEnterState()
    {
        base.OnEnterState();
        Debug.Log("Inside Patrol");
        enemyTankView.getTankController().Patrol();
    }

}
