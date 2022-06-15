using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : MonoSingletonGeneric<BulletService>
{
    public BulletScriptableObjList BulletList;

    private ServicePoolBullet servicePoolBullet;

    //public BulletSO bulletSOReference;
    //private void Start()
    //{
    //    StartGame();
    //}

    //public void StartGame()
    //{
    //    servicePoolBullet.GetBullet();
    //}

    public Rigidbody InstantiateBullet()
    {
        BulletSO bulletSOReference = BulletList.bullets[0];
        return bulletSOReference._shellPrefab;
    }

    public void DisableObject(Rigidbody _object, float _lifetime)
    {
        StartCoroutine(ReturnObjectToPool(_object, _lifetime));
    }

    IEnumerator ReturnObjectToPool(Rigidbody _object, float _lifetime)
    {
        yield return new WaitForSeconds(_lifetime);
        _object.gameObject.SetActive(false);
        //servicePoolBullet.ReturnToPool(_object);
    }
}
