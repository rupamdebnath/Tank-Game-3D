using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyState
{    
    public override void OnEnterState()
    {
        base.OnEnterState();
        //Debug.Log("Inside Idle");
        StartCoroutine(GoTo());
    }

    IEnumerator GoTo()
    {        
        yield return new WaitForSeconds(3f);
        enemyTankView.ChangeState(enemyTankView.patrollingState);
    }
}
