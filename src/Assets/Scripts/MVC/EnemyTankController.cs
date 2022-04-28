using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController
{
    EnemyTankModel enemytankModel;
    EnemyTankView enemytankView;

    Rigidbody rb;
    public EnemyTankController(EnemyTankModel _enemytankModel, EnemyTankView _enemytankView)
    {
        enemytankModel = _enemytankModel;
        enemytankView = GameObject.Instantiate(_enemytankView, new Vector3(10,0,0), Quaternion.Euler(0,180,0));
        rb = _enemytankView.getRigidBody();

        enemytankView.setTankController(this);
    }

    public void Patrol(Vector3 movement)
    {

    }

    public EnemyTankModel getTankModel()
    {
        return enemytankModel;
    }
}
