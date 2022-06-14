using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : MonoSingletonGeneric<BulletService>
{
    public BulletScriptableObjList BulletList;

    //public BulletSO bulletSOReference;

    public Rigidbody GetBullet()
    {
        BulletSO bulletSOReference = BulletList.bullets[0];
        return bulletSOReference._shellPrefab;
    }
}
