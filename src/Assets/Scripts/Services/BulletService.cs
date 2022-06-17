using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : MonoSingletonGeneric<BulletService>
{
    public BulletView bulletPrefabView;

    private ServicePoolBullet servicePoolBullet;
    
    [SerializeField]
    GameObject[] bulletObject;
    //public BulletSO bulletSOReference;
    private void Start()
    {
        bulletObject = new GameObject[5];
        servicePoolBullet = GetComponent<ServicePoolBullet>();
        StartGame();
    }

    public void StartGame()
    {
        
        for(int i = 0; i < 5; i++)
        {
            //bulletObject[i] = Instantiate(servicePoolBullet.GetBullet());
            //bulletObject[i] = InstantiateBullet();
            //InstantiateBullet();
            ////servicePoolBullet.ReturnItem(bulletObject[i]);
            //bulletObject[i].SetActive(false);
            //Debug.Log(bulletObject[i]);
            //ServicePool.Instance.ReturnItem(bulletObject[i]);
            
        }
        //for (int i = 0; i < 5; i++)
        //{
        //    servicePoolBullet.ReturnItem(bulletObject[i]);
        //}
    }

    public BulletController GetBullet()
    {
        return servicePoolBullet.GetBullet(bulletPrefabView);
    }

    public void DisableObject(BulletController _object, float _lifetime)
    {
        StartCoroutine(ReturnObjectToPool(_object, _lifetime));
    }

    IEnumerator ReturnObjectToPool(BulletController _object, float _lifetime)
    {
        yield return new WaitForSeconds(_lifetime);
        //_object.gameObject.SetActive(false);
        servicePoolBullet.ReturnItem(_object);
    }

}
