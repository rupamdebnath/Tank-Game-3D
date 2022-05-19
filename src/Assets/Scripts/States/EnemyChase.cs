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
            //enemyTankView.ChangeState(enemyTankView.attackingState);
        }
        else if(Vector3.Distance(enemyTankView.transform.position, playerobj.transform.position) < 10)
        {
            enemyTankView.ChangeState(enemyTankView.attackingState);
        }

        //StartCoroutine(AttackBehaviour());

    }
    IEnumerator AttackBehaviour()
    {
        Debug.Log("Attack");
        yield return new WaitForSeconds(2f);

    }
}
