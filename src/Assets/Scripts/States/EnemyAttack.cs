using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyState
{
    private bool fired = false;
    public override void OnEnterState()
    {
        base.OnEnterState();
        Debug.Log("Inside Attack");
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        if (fired)
        {
            yield return new WaitForSeconds(2f);
            fired = false;
        }
        else if (!fired)
        {
            Debug.Log("Fired");
            enemyTankView.getTankController().ShootBullets();
            yield return new WaitForSeconds(2f);
            fired = true;
            enemyTankView.ChangeState(enemyTankView.chasingState);
        }
        if (Vector3.Distance(enemyTankView.transform.position, playerobj.transform.position) > 15)
        {
            enemyTankView.ChangeState(enemyTankView.patrollingState);
        }
    }
}
