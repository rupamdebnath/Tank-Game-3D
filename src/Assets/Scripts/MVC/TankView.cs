using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;

    //public TankType tankType;
    [SerializeField]
    Joystick joystick;
    
    Rigidbody rb;
    Vector3 movement;
    float turn;

    public Vector3 Offset;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        joystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
    }

    private void Start()
    {
        Offset = new Vector3(-6f, 2.5f, 0);
        GameObject cam = GameObject.Find("Main Camera");

        cam.transform.position = transform.position + Offset;

        cam.transform.SetParent(transform);
        //Debug.Log(cam.transform.localPosition);
    }
    private void Update()
    {
        Movement(rb);
        tankController.Move(movement, turn);
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
}
