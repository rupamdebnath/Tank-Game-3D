using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class ShootBullets : MonoBehaviour
{
    public Rigidbody _shellPrefab;

    public Transform _fireTransform;
    //[SerializeField]
    public Slider _aimslider;
    public float minlaunchForce = 15f;
    public float maxlaunchForce = 30f;
    public float maxchargeTime = 0.75f;

    private string fireButton;
    private float currentLaunchForce;
    private float chargeSpeed;
    private bool fired;

    private void OnEnable()
    {
        
        currentLaunchForce = minlaunchForce;
        _aimslider.value = minlaunchForce;
    }

    private void Start()
    {
        _aimslider = GameObject.Find("AimSlider").GetComponent<Slider>();
        fireButton = "Jump";
        chargeSpeed = (maxlaunchForce - minlaunchForce) / maxchargeTime;
    }

    private void Update()
    {
        _aimslider.value = minlaunchForce;
        if (currentLaunchForce >= maxlaunchForce && !fired)
        {
            currentLaunchForce = maxlaunchForce;
            Fire();
        }
        else if(Input.GetButtonDown(fireButton))
        {
            fired = false;
            currentLaunchForce = minlaunchForce;
        }
        else if (Input.GetButton(fireButton) && !fired)
        {
            currentLaunchForce += chargeSpeed * Time.deltaTime;
            _aimslider.value = currentLaunchForce;
        }
        else if(Input.GetButtonUp(fireButton) && !fired)
        {
            Fire();
        }
    }

    private void Fire()
    {
        fired = true;
        Rigidbody bulletInstance = Instantiate(_shellPrefab, _fireTransform.position, _fireTransform.rotation) as Rigidbody;

        bulletInstance.velocity = currentLaunchForce * _fireTransform.forward;

        currentLaunchForce = minlaunchForce;
    }
}
