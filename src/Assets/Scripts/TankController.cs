using UnityEngine;
 //|| Input.GetMouseButtonDown(0)
public class TankController
{
    TankModel tankModel;
    TankView tankView;

    public TankController(TankModel _tankModel, TankView _tankview)
    {
        tankModel = _tankModel;
        tankView = _tankview;

        GameObject.Instantiate(tankView.gameObject);
    }
}
