using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    BulletView bulletView;
    Rigidbody rb;
    public BulletController(BulletView _bulletView)
    {
        bulletView = GameObject.Instantiate(_bulletView, new Vector3(0,0,0), Quaternion.identity);

        bulletView.setBulletController(this);

        rb = bulletView.GetRigidBody();
    }

    public BulletView GetBulletView()
    {
        return bulletView;
    }

    public void Disable()
    {
        bulletView.Disable();
    }

    public void Enable()
    {
        bulletView.Enable();
    }
}
