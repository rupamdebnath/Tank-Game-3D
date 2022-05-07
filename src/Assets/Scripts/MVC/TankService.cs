using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    //public TankView tankView;

    public TankScriptableObjList tankList;
    public BulletScriptableObjList BulletList;

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        CreatePlayerTank(0);
        CreateEnemyTank(1);
        CreateEnemyTank(2); 
    }   

    private void CreatePlayerTank(int index)
    {
        TankScriptable tankSO = tankList.tanks[index];        
        BulletScriptableObj bulletSO = BulletList.bullets[0];
        TankModel tankModel = new TankModel(tankSO, bulletSO);
        TankController tankController = new TankController(tankModel, tankSO.tankView);
    }
    private void CreateEnemyTank(int index)
    {
        TankScriptable enemytankSO = tankList.tanks[index];
        BulletScriptableObj bulletSO = BulletList.bullets[0];
        EnemyTankModel enemytankModel = new EnemyTankModel(enemytankSO, bulletSO);
        EnemyTankController enemytankController = new EnemyTankController(enemytankModel, enemytankSO.enemytankView);
    }
}
