using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : EnemyState
{
    public override void OnEnterState()
    {
        base.OnEnterState();
        Debug.Log("Inside Chase");

        enemyTankView.getTankController().ChasePlayer();
        if (Vector3.Distance(enemyTankView.transform.position, playerobj.transform.position) > 15)
        {
            enemyTankView.ChangeState(enemyTankView.patrollingState);
        }
        else if(Vector3.Distance(enemyTankView.transform.position, playerobj.transform.position) < 10)
        {
            enemyTankView.ChangeState(enemyTankView.attackingState);
        }

    }
}
