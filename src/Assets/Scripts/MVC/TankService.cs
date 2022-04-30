using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    //public TankView tankView;

    public TankScriptableObjList tankList;

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        CreatePlayerTank(0);
        CreateEnemyTank(1);
        CreateEnemyTank(2);
        //for(int i = 0; i < tankList.getLength() ; i++)
        //{
        //    CreateTank(i);
        //    Debug.Log("Type:" + tankList.tanks[i].TankName);
        //}
    }

    private void CreatePlayerTank(int index)
    {
        TankScriptable tankSO = tankList.tanks[index];
        TankModel tankModel = new TankModel(tankSO);
        TankController tankController = new TankController(tankModel, tankSO.tankView);
    }
    private void CreateEnemyTank(int index)
    {
        TankScriptable enemytankSO = tankList.tanks[index];
        EnemyTankModel enemytankModel = new EnemyTankModel(enemytankSO);
        EnemyTankController enemytankController = new EnemyTankController(enemytankModel, enemytankSO.enemytankView);
    }
}
