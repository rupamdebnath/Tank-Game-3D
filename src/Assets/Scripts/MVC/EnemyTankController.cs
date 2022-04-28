using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankController
{
    EnemyTankModel enemytankModel;
    EnemyTankView enemytankView;

    Rigidbody rb;

    NavMeshAgent agent;
    Transform[] waypoints;
    int waypointindex;
    Vector3 target;
    public EnemyTankController(EnemyTankModel _enemytankModel, EnemyTankView _enemytankView)
    {
        enemytankModel = _enemytankModel;
        enemytankView = GameObject.Instantiate(_enemytankView, new Vector3(10,0,0), Quaternion.Euler(0,180,0));
        rb = enemytankView.getRigidBody();

        enemytankView.setTankController(this);
        agent = enemytankView.GetComponent<NavMeshAgent>();
        waypoints = enemytankView.getWayPoints();

        waypointindex = 0;
    }

    public void Patrol()
    {
        if (Vector3.Distance(enemytankView.transform.position, target) > 1)
        {            
            UpdateDestination();
        }
        else
        {
            IterateWayPointIndex();
            UpdateDestination();
        }
    }

    public EnemyTankModel getTankModel()
    {
        return enemytankModel;
    }
    public EnemyTankView getTankView()
    {
        return enemytankView;
    }
    void UpdateDestination()
    {
        target = waypoints[waypointindex].position;
        agent.SetDestination(target);
    }

    void IterateWayPointIndex()
    {
        waypointindex++;
        if (waypointindex == waypoints.Length)
        {
            waypointindex = 0;
        }
    }
}
