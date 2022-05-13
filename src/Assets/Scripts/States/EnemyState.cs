using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyTankView))]
public class EnemyState : MonoBehaviour
{
    private EnemyTankView enemyTankView;

    private void Awake()
    {
        enemyTankView = GetComponent<EnemyTankView>();
    }
    public virtual void OnEnterState() 
    {
        Debug.Log("Inside Base"); 
        this.enabled = true;
    }
    public virtual void OnExitState() 
    {
        this.enabled = false;
    }
}
