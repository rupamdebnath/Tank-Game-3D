using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObjList", menuName = "ScriptableObjects/NewTankSOList")]
public class TankScriptableObjList : ScriptableObject
{
    public TankScriptable[] tanks;

    public int getLength()
    {
        return tanks.Length;

    }
}