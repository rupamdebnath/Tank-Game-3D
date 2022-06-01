using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceEvents : SingletonGeneric <ServiceEvents>
{

    public Action<int> ScoreCounter;

	public Action<int> OnEnemyDeath;
	public Action<int> OnFire;

	public void Play()
    {
        Debug.Log("Noth");
    }

}
