using System;
using UnityEngine;

[CreateAssetMenu(fileName ="TankScriptableObj", menuName = "ScriptableObjects/NewTankSO")]
public class TankScriptable : ScriptableObject
{
    public TankType TankType;
    public String TankName;
    public float Speed;
    public float Health;
    public float Damage;
    public TankView tankView;
    public EnemyTankView enemytankView;
    public GameObject TankPrefab;
}


[CreateAssetMenu(fileName = "TankScriptableObjList", menuName = "ScriptableObjects/NewTankSOList")]
public class TankScriptableObjList : ScriptableObject
{
    public TankScriptable[] tanks;

    public int getLength()
    {
        return tanks.Length;

    }
}