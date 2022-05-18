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

        if (Vector3.Distance(enemyTankView.transform.position, playerobj.transform.position) < 15)
        {
            enemyTankView.ChangeState(enemyTankView.chasingState);
        }
    }

}
