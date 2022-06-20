using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObjList", menuName = "ScriptableObjects/NewBulletSOList")]
public class BulletScriptableObjList : ScriptableObject
{
    public BulletSO[] bullets;

    public int getLength()
    {
        return bullets.Length;

    }
}
