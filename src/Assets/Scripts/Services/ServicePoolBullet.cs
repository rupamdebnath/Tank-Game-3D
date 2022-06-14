using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicePoolBullet : ServicePool<Rigidbody>
{
    protected override Rigidbody CreateItem()
    {
        return BulletService.Instance.GetBullet();
    }
}
