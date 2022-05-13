using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyTankView))]
public class EnemyState : MonoBehaviour
{
    protected EnemyTankView enemyTankView;

    private void Awake()
    {
        enemyTankView = GetComponent<EnemyTankView>();
    }
    public virtual void OnEnterState() 
    {
        this.enabled = true;
    }
    public virtual void OnExitState() 
    {
        this.enabled = false;
    }
}
