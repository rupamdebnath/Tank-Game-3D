using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    private TankController tankController;
    public float speed;
    public TankModel(float _speed)
    {
        speed = _speed;
    }

    public void setTankController(TankController _tankController)
    {
        tankController = _tankController;
    }

    public float getSpeed()
    {
        return speed;
    }
}
