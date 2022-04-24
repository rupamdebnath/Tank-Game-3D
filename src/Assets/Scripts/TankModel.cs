using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    public float speed;
    public TankModel(TankType type, float _speed, float _health, float _damage)
    {
        speed = _speed;
        Health = _health;
        Damage = _damage;
    }


    public float getSpeed()
    {
        return speed;
    }

    public float Health { get; }
    public float Damage { get; }
}
