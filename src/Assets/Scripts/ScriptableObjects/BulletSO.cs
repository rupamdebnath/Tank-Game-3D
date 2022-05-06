using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "BulletScriptableObj", menuName = "ScriptableObjects/NewBulletSO")]
public class BulletScriptableObj : ScriptableObject
{
    public Rigidbody _shellPrefab;

    public Transform _fireTransform;
    public Slider _aimslider;
    public float minlaunchForce;
    public float maxlaunchForce;
    public float maxchargeTime;

    public string fireButton;
    public float currentLaunchForce;
    public float chargeSpeed; 
}

[CreateAssetMenu(fileName = "BulletScriptableObjList", menuName = "ScriptableObjects/NewBulletSOList")]
public class BulletScriptableObjList : ScriptableObject
{
    public BulletScriptableObj[] bullets;

    public int getLength()
    {
        return bullets.Length;

    }
}
