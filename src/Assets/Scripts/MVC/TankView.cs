using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private ServicePoolBullet servicePoolBullet;
    [SerializeField]
    Joystick joystick;
    
    Rigidbody rb;
    Vector3 movement;
    float turn;
    public Transform fireTransform;
    public Slider aimSlider;
    //offset for camera distance from player
    public Vector3 Offset;
    public string fireButton;
    public ParticleSystem tankExplosion;
    int bulletCount = 0;
    private void Awake()
    {
        servicePoolBullet = new ServicePoolBullet();
        rb = gameObject.GetComponent<Rigidbody>();
        joystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
    }

    private void Start()
    {
        Offset = new Vector3(-6f, 2.8f, 0);
        GameObject cam = GameObject.Find("Main Camera");

        cam.transform.position = transform.position + Offset;

        cam.transform.SetParent(transform);

        tankController.getTankModel().BulletShell.currentLaunchForce = tankController.getTankModel().BulletShell.minlaunchForce;
        fireButton = "Jump";
        aimSlider.value = tankController.getTankModel().BulletShell.minlaunchForce;
        tankController.getTankModel().BulletShell.chargeSpeed = (tankController.getTankModel().BulletShell.maxlaunchForce - tankController.getTankModel().BulletShell.minlaunchForce) / tankController.getTankModel().BulletShell.maxchargeTime;
    }

    public void setHealth(float _damagevalue)
    {
        tankController.getTankModel().Health -= _damagevalue;
    }

    private void Update()
    {
        Movement(rb);
        tankController.Move(movement, turn);
        tankController.ShootBullets();
    }

    public void setTankController(TankController _tankController)
    {
        tankController = _tankController;        
    }
    public void Movement(Rigidbody rb)
    {
        movement = joystick.Vertical * transform.forward * tankController.getTankModel().Speed * Time.deltaTime;

        turn = joystick.Horizontal * 180 * Time.deltaTime;
    }

    public Rigidbody getRigidBody()
    {
        return rb;
    }

    public float getHealth()
    {
        return tankController.getTankModel().Health;
    }

    public Rigidbody InstantiateBullet()
    {
        Rigidbody bulletTemp = BulletService.Instance.GetBullet().GetBulletView().GetRigidBody();
        bulletTemp.transform.position = fireTransform.position;
        bulletTemp.transform.rotation = fireTransform.rotation;
        //Rigidbody bulletInstance = Instantiate(BulletService.Instance.GetBullet().GetBulletView().gameObject, fireTransform.position, fireTransform.rotation);
        bulletCount++;
        ServiceEvents.Instance.OnFire?.Invoke(bulletCount);
        return bulletTemp;
    }
    public void PlayExplosion()
    {
        tankExplosion.transform.parent = null;
        tankExplosion.Play();
        GameObject.FindGameObjectWithTag("MainCamera").transform.parent = null;
        Destroy(tankExplosion.gameObject, tankExplosion.main.duration);
        GameOverManager.Instance.PlayerDeath();
    }

}
