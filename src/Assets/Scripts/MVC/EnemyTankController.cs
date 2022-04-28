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
        enemytankView = GameObject.Instantiate(_enemytankView, new Vector2(10,0), Quaternion.identity);
        rb = _enemytankView.getRigidBody();

        enemytankView.setTankController(this);
    }

    public void Patrol(Vector3 movement, float turn)
    {

    }

    public EnemyTankModel getTankModel()
    {
        return enemytankModel;
    }
}
