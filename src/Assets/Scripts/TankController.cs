using UnityEngine;
 //|| Input.GetMouseButtonDown(0)
public class TankController
{
    TankModel tankModel;
    TankView tankView;

    Rigidbody rb;
    public TankController(TankModel _tankModel, TankView _tankview)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankview);
        rb = tankView.getRigidBody();
        tankModel.setTankController(this);
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
}
