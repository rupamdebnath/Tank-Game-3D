﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    private TankController tankController;

    public TankModel()
    {
        
    }

    public void setTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
