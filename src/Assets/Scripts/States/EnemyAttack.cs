﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyState
{
    public override void OnEnterState()
    {
        base.OnEnterState();
        Debug.Log("Inside Attack");
    }
}
