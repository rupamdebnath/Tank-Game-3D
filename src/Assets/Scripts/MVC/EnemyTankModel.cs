using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankModel
{
    TankScriptable tankScriptableObject;
    //Transform WayPoint1;
    //Transform WayPoint2;
    public EnemyTankModel(TankScriptable _tankScriptable, BulletSO _bulletSO)
    {
        tankType = _tankScriptable.TankType;
        Speed = _tankScriptable.Speed;
        Health = _tankScriptable.Health;
        Damage = _tankScriptable.Damage;
        SpawnPosition = _tankScriptable.spawnPosition;
        tankScriptableObject = _tankScriptable;
        BulletShell = _bulletSO;
    }
    public EnemyTankModel(TankType type, float _speed, float _health, float _damage)
    {
        Speed = _speed;
        Health = _health;
        Damage = _damage;
    }


    //public float Speed { get { return tankScriptableObject.Speed; } }

    public float Speed { get; }
    public float Health { set;  get; }
    public float Damage { get; }

    public TankType tankType { get; }

    public Transform SpawnPosition { get; }

    public Transform[] waypoints { set;  get; }

    //public Transform Waypoint2 { set;  get; }

    public float patroldistance { get { return tankScriptableObject.patroldistance; } }
    public BulletSO BulletShell { get; }
}
