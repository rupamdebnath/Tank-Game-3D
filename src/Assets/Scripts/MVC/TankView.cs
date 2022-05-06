using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour
{
    private TankController tankController;

    //public TankType tankType;
    [SerializeField]
    Joystick joystick;
    
    Rigidbody rb;
    Vector3 movement;
    float turn;
    BulletScriptableObj normalBullet;
    public Vector3 Offset;

    //public Transform _fireTransform;
    //public Slider _aimslider;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        joystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        //tankController.getTankModel().BulletShell._aimslider = GameObject.Find("AimSlider").GetComponent<Slider>();
        //tankController.getTankModel().BulletShell._fireTransform = GameObject.Find("FireTransform").transform;
    }

    private void Start()
    {
        Offset = new Vector3(-6f, 2.8f, 0);
        GameObject cam = GameObject.Find("Main Camera");

        cam.transform.position = transform.position + Offset;

        cam.transform.SetParent(transform);
        //Debug.Log(cam.transform.localPosition);
        tankController.getTankModel().BulletShell._aimslider = GameObject.Find("AimSlider").GetComponent<Slider>();
        tankController.getTankModel().BulletShell._fireTransform = GameObject.Find("FireTransform").transform;
        tankController.getTankModel().BulletShell.currentLaunchForce = tankController.getTankModel().BulletShell.minlaunchForce;
        tankController.getTankModel().BulletShell.fireButton = "Jump";
        tankController.getTankModel().BulletShell._aimslider.value = tankController.getTankModel().BulletShell.minlaunchForce;
        tankController.getTankModel().BulletShell.chargeSpeed = (tankController.getTankModel().BulletShell.maxlaunchForce - tankController.getTankModel().BulletShell.minlaunchForce) / tankController.getTankModel().BulletShell.maxchargeTime;
    }
    private void Update()
    {
        Movement(rb);
        tankController.Move(movement, turn);
        //Rigidbody bulletInstance = Instantiate(tankController.getTankModel().BulletShell._shellPrefab, tankController.getTankModel().BulletShell._fireTransform.position, tankController.getTankModel().BulletShell._fireTransform.rotation) as Rigidbody;
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
        Rigidbody bulletInstance = Instantiate(tankController.getTankModel().BulletShell._shellPrefab, tankController.getTankModel().BulletShell._fireTransform.position, tankController.getTankModel().BulletShell._fireTransform.rotation) as Rigidbody;
        return bulletInstance;
    }
}
