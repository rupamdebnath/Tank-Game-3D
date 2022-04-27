using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    public TankView tankView;

    public TankScriptableObjList tankList;

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        CreateTank(0);

        //for(int i = 0; i < tankList.getLength() ; i++)
        //{
        //    CreateTank(i);
        //    Debug.Log("Type:" + tankList.tanks[i].TankName);
        //}
    }

    private void CreateTank(int index)
    {
        TankScriptable tankSO = tankList.tanks[index];
        TankModel tankModel = new TankModel(tankSO);
        TankController tankController = new TankController(tankModel, tankView);
    }

}
