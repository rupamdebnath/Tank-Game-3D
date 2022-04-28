using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankView : MonoBehaviour
{
    private EnemyTankController enemyTankController;

    Rigidbody rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();  
    }

    private void Start()
    {
        
    }
    private void Update()
    {        
        
    }

    public void setTankController(EnemyTankController _enemyTankController)
    {
        enemyTankController = _enemyTankController;
    }

    public Rigidbody getRigidBody()
    {
        return rb;
    }
}
