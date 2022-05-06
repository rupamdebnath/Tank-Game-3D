using UnityEngine;
 //|| Input.GetMouseButtonDown(0)
public class TankController
{
    TankModel tankModel;
    TankView tankView;

    Rigidbody rb;
    private bool fired;
    public TankController(TankModel _tankModel, TankView _tankview)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankview);
        rb = tankView.getRigidBody();
        
        tankView.setTankController(this);

    }
    public void Move(Vector3 movement, float turn)
    {
        rb.MovePosition(rb.position + movement);
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
        //ShootBullets();
    }

    public TankModel getTankModel()
    {
        return tankModel;
    }

    public void ShootBullets()
    {
        tankModel.BulletShell._aimslider.value = tankModel.BulletShell.minlaunchForce;
        if (tankModel.BulletShell.currentLaunchForce >= tankModel.BulletShell.maxlaunchForce && !fired)
        {
            tankModel.BulletShell.currentLaunchForce = tankModel.BulletShell.maxlaunchForce;
            PlayerFire();
        }
        else if (Input.GetButtonDown(tankModel.BulletShell.fireButton))
        {
            fired = false;
            tankModel.BulletShell.currentLaunchForce = tankModel.BulletShell.minlaunchForce;
        }
        else if (Input.GetButton(tankModel.BulletShell.fireButton) && !fired)
        {
            tankModel.BulletShell.currentLaunchForce += tankModel.BulletShell.chargeSpeed * Time.deltaTime;
            tankModel.BulletShell._aimslider.value = tankModel.BulletShell.currentLaunchForce;
        }
        else if (Input.GetButtonUp(tankModel.BulletShell.fireButton) && !fired)
        {
            PlayerFire();
        }
        //Debug.Log(getTankModel().BulletShell.minlaunchForce);
    }

    private void PlayerFire()
    {
         fired = true;
        //Rigidbody bulletInstance = Instantiate(tankModel.BulletShell._shellPrefab, tankModel.BulletShell._fireTransform.position, tankModel.BulletShell._fireTransform.rotation) as Rigidbody;
        Rigidbody _bullet = tankView.InstantiateBullet();
        _bullet.velocity = tankModel.BulletShell.currentLaunchForce * tankModel.BulletShell._fireTransform.forward;

        tankModel.BulletShell.currentLaunchForce = tankModel.BulletShell.minlaunchForce;
    }
}
