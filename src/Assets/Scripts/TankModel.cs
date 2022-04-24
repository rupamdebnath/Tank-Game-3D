using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    public float speed;
    public TankModel(float _speed)
    {
        speed = _speed;
    }


    public float getSpeed()
    {
        return speed;
    }
}
