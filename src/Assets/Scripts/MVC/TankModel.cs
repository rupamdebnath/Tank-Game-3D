using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    TankScriptable tankScriptableObject;
    public TankModel(TankScriptable _tankScriptable)
    {
        tankType = _tankScriptable.TankType;
        Speed = _tankScriptable.Speed;
        Health = _tankScriptable.Health;
        Damage = _tankScriptable.Damage;
    }
    public TankModel(TankType type, float _speed, float _health, float _damage)
    {
        //Speed = _speed;
        Health = _health;
        Damage = _damage;
    }


    //public float Speed { get { return tankScriptableObject.Speed; } }

    public float Speed { get; }
    public float Health { get; }
    public float Damage { get; }

    public TankType tankType { get; }
}
