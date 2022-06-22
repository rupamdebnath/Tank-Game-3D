using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : MonoSingletonGeneric<BulletService>
{
    public BulletView bulletPrefabView;

    private ServicePoolBullet servicePoolBullet;
    BulletController bulletcontroller;

    private void Start()
    {
        servicePoolBullet = GetComponent<ServicePoolBullet>();
    }

    public BulletController GetBullet()
    {
        BulletController bullet = servicePoolBullet.GetBullet(bulletPrefabView);
        bullet.Enable();
        return bullet;
    } 

    public void ReturnObjectToPoolDirectly(BulletController _bulletController)
    {
        servicePoolBullet.ReturnItem(_bulletController);
    }

}
