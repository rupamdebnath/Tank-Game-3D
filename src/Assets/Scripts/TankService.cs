using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    public TankView tankView;

    void Start()
    {
        CreateTank();
    }

    private void CreateTank()
    {
        TankModel tankModel = new TankModel(TankType.None, 5f, 100f, 20);
        TankController tankController = new TankController(tankModel, tankView);
    }

}
