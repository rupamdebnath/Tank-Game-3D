using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;

    [SerializeField]
    Joystick joystick;
    public float speed = 5f;
    Rigidbody rb;
    Vector3 movement;
    float turn;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Movement(rb);
        tankController.Move(movement, turn);
    }
    public void setTankController(TankController _tankController)
    {
        tankController = _tankController;
        joystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
    }
    public void Movement(Rigidbody rb)
    {
        movement = joystick.Vertical * transform.forward * speed * Time.deltaTime;
        //rb.MovePosition(rb.position + movement);
        turn = joystick.Horizontal * 180 * Time.deltaTime;
        //Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        //rb.MoveRotation(rb.rotation * turnRotation);
    }

    public Rigidbody getRigidBody()
    {
        return rb;
    }
}
