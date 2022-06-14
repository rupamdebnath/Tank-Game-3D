using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : MonoSingletonGeneric<BulletService>
{
    public BulletScriptableObjList BulletList;

    public BulletSO bulletSO;

    public Rigidbody GetBullet()
    {
        bulletSO = BulletList.bullets[0];
        return bulletSO._shellPrefab;
    }
}
