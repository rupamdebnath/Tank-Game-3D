using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyTankView))]
public class EnemyState : MonoBehaviour
{
    protected EnemyTankView enemyTankView;
    protected GameObject playerobj;
    private void Awake()
    {
        enemyTankView = GetComponent<EnemyTankView>();
        playerobj = GameObject.FindGameObjectWithTag("Player");
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
