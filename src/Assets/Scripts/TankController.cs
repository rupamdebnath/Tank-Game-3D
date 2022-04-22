using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 //|| Input.GetMouseButtonDown(0)
public class TankController : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField]
    Joystick joystick;
    public float speed = 5f;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        Move(rb);        
    }
    public void Move(Rigidbody rb)
    {
        Vector3 movement = joystick.Vertical * transform.forward * PlayerTank.Instance.getSpeed() * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
        float turn = joystick.Horizontal * 180 * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        rb.MoveRotation(rb.rotation * turnRotation);
    }

}
