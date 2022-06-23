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
    public Transform spawnPosition;
    public float patroldistance;
}