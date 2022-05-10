using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankController
{
    EnemyTankModel enemytankModel;
    EnemyTankView enemytankView;

    Rigidbody rb;
    
    NavMeshAgent agent;
    int waypointindex;
    Vector3 target;

    private bool fired = false;
    public EnemyTankController(EnemyTankModel _enemytankModel, EnemyTankView _enemytankView)
    {
        enemytankModel = _enemytankModel;
        enemytankView = GameObject.Instantiate(_enemytankView, enemytankModel.SpawnPosition.position, enemytankModel.SpawnPosition.rotation);
        rb = enemytankView.getRigidBody();
        
        enemytankView.setTankController(this);
        agent = enemytankView.GetComponent<NavMeshAgent>();
        waypointindex = 0;
        //waypoints = new Vector3[2];
    }

    public void Patrol()
    {        
        target = enemytankView.waypointsvector[waypointindex];
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
        target = enemytankView.waypointsvector[waypointindex];
        agent.SetDestination(target); 
    }

    void IterateWayPointIndex()
    {
        waypointindex++;
        if (waypointindex == 2)
        {
            waypointindex = 0;
        }
    }

    public Vector3[] SetupWayPoints()
    {
        Vector3[] waypoints = new Vector3[2];
        waypoints[0] = enemytankModel.SpawnPosition.position + enemytankView.transform.forward * enemytankModel.patroldistance;
        waypoints[1] = enemytankModel.SpawnPosition.position - enemytankView.transform.forward * enemytankModel.patroldistance;
        return waypoints;

    }
    public async void ShootBullets()
    {
        //    //enemytankView.aimSlider.value = tankModel.BulletShell.minlaunchForce;
        //    //if (enemytankModel.BulletShell.currentLaunchForce >= enemytankModel.BulletShell.maxlaunchForce && fired)
        //    //{
        //    //enemytankModel.BulletShell.currentLaunchForce = enemytankModel.BulletShell.maxlaunchForce;
        //    //EnemyFire();

        //    if (!fired)
        //    {
        //        //Debug.Log("waiting...");
        //        //await Task.Delay(TimeSpan.FromSeconds(5f));
        //        //Debug.Log("Fire");
        //        //fired = true;
        //        //await (Wait());
        //    }
        //    else
        //    {
        //        //EnemyFire();

        //        Debug.Log("Not fired.");
        //        fired = false;
        //        await Task.Delay(TimeSpan.FromSeconds(5f));
        //        //await (Wait());
        //    }
        //    //}
        //    //else if (Input.GetButtonDown(enemytankModel.fireButton))
        //    //{
        //    //    fired = false;
        //    //    enemytankModel.BulletShell.currentLaunchForce = enemytankModel.BulletShell.minlaunchForce;
        //    //}
        //    //else if (Input.GetButton(tankView.fireButton) && !fired)
        //    //{
        //    //    enemytankModel.BulletShell.currentLaunchForce += enemytankModel.BulletShell.chargeSpeed * Time.deltaTime;
        //    //    tankView.aimSlider.value = enemytankModel.BulletShell.currentLaunchForce;
        //    //}
        //    //else if (Input.GetButtonUp(tankView.fireButton) && !fired)
        //    //{
        //    //    PlayerFire();
        //    //}
    }

    private void EnemyFire()
    {
        fired = true;
        Rigidbody _bullet = enemytankView.InstantiateBullet();
        _bullet.velocity = enemytankModel.BulletShell.currentLaunchForce * enemytankView.fireTransform.forward;

        enemytankModel.BulletShell.currentLaunchForce = enemytankModel.BulletShell.minlaunchForce;
    }

    //async Task Wait()
    //{

    //    //yield return new WaitForSeconds(5f);
    //    //await Task.Delay(TimeSpan.FromSeconds(5));
    //    //float t = 0;
    //    //while(t < 5f)
    //    //{
    //    //    t += Time.deltaTime;

    //    //    await Task.Yield();
    //    //}
    //    //Debug.Log("Started task...");
    //    //EnemyFire();
        
    //    //await Task.Delay(TimeSpan.FromSeconds(5));

    //    //EnemyFire();
    //    //throw new System.Exception();
    //}
}
