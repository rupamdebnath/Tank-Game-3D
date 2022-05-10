using UnityEngine;

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
    }

    public TankModel getTankModel()
    {
        return tankModel;
    }

    public void ShootBullets()
    {
        tankView.aimSlider.value = tankModel.BulletShell.minlaunchForce;
        if (tankModel.BulletShell.currentLaunchForce >= tankModel.BulletShell.maxlaunchForce && !fired)
        {
            tankModel.BulletShell.currentLaunchForce = tankModel.BulletShell.maxlaunchForce;
            PlayerFire();
        }
        else if (Input.GetButtonDown(tankView.fireButton))
        {
            fired = false;
            tankModel.BulletShell.currentLaunchForce = tankModel.BulletShell.minlaunchForce;
        }
        else if (Input.GetButton(tankView.fireButton) && !fired)
        {
            tankModel.BulletShell.currentLaunchForce += tankModel.BulletShell.chargeSpeed * Time.deltaTime;
            tankView.aimSlider.value = tankModel.BulletShell.currentLaunchForce;
        }
        else if (Input.GetButtonUp(tankView.fireButton) && !fired)
        {
            PlayerFire();
        }       
    }

    private void PlayerFire()
    {
         fired = true;        
        Rigidbody _bullet = tankView.InstantiateBullet();
        _bullet.velocity = tankModel.BulletShell.currentLaunchForce * tankView.fireTransform.forward;

        tankModel.BulletShell.currentLaunchForce = tankModel.BulletShell.minlaunchForce;
    }

    //public void SetDamage()
    //{
    //    BulletExplosion.Instance.setMaxDamage(30f);
    //}
}
