using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : MonoSingletonGeneric<BulletService>
{
    public BulletView bulletPrefabView;

    private ServicePoolBullet servicePoolBullet;
    BulletController bulletcontroller;
    //public BulletSO bulletSOReference;
    private void Start()
    {
        servicePoolBullet = GetComponent<ServicePoolBullet>();
        StartGame();
    }

    public void StartGame()
    {
        
        for(int i = 0; i < 5; i++)
        {
            bulletcontroller = servicePoolBullet.GetBullet(bulletPrefabView);
            DisableObject(bulletcontroller, bulletPrefabView.maxLifeTime);
            //bulletPrefabView.gameObject.SetActive(false);
            //bulletcontroller.Disable();
            //servicePoolBullet.ReturnItem(bulletcontroller);
        }

    }

    public BulletController GetBullet()
    {
        BulletController bullet = servicePoolBullet.GetBullet(bulletPrefabView);
        bullet.Enable();
        return bullet;
    }

    public void DisableObject(BulletController _object, float _lifetime)
    {
        StartCoroutine(ReturnObjectToPool(_object, _lifetime));
    }

    IEnumerator ReturnObjectToPool(BulletController _object, float _lifetime)
    {
        yield return new WaitForSeconds(_lifetime);
        _object.Disable();
        servicePoolBullet.ReturnItem(_object);
    }

    public void ReturnObjectToPoolDirectly(BulletController _bulletController)
    {
        servicePoolBullet.ReturnItem(_bulletController);
    }

}
