using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceEvents : SingletonGeneric <ServiceEvents>
{

    public Action<int> ScoreCounter;

	public Action<int> OnEnemyDeath;
	public Action<int> OnFire;
    int deadEnemiesCount=0;
	public void Count()
    {
        deadEnemiesCount++;
    }
    public int GetCountOfEnemiesDead()
    {
        return deadEnemiesCount;
    }
}
