using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicePoolBullet : ServicePool<BulletController>
{
    private BulletView objectPrefabView;
    protected override BulletController CreateItem()
    {
        BulletController bulletController = new BulletController(objectPrefabView);
        return bulletController;          
    }

    public BulletController GetBullet(BulletView objectPrefabView)
    {
        this.objectPrefabView = objectPrefabView;
        return GetItem();
    }

}
