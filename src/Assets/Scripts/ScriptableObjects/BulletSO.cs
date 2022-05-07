using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "BulletSO", menuName = "ScriptableObjects/NewBulletSO")]
public class BulletSO : ScriptableObject
{ 
    public Rigidbody _shellPrefab;
   
    public float minlaunchForce;
    public float maxlaunchForce;
    public float maxchargeTime;
    public float currentLaunchForce;
    public float chargeSpeed; 
}

[CreateAssetMenu(fileName = "BulletScriptableObjList", menuName = "ScriptableObjects/NewBulletSOList")]
public class BulletScriptableObjList : ScriptableObject
{
    public BulletSO[] bullets;

    public int getLength()
    {
        return bullets.Length;

    }
}
