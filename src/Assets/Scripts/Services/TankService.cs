using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    public TankScriptableObjList tankList;
    public BulletScriptableObjList BulletList;
    private ServicePoolBullet servicePoolBullet;
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        CreatePlayerTank(0);
        for (int i=1; i<=(tankList.getLength() - 1); i++)
        {
            CreateEnemyTank(i);
        }
    }   

    private void CreatePlayerTank(int index)
    {
        TankScriptable tankSO = tankList.tanks[index];
        BulletSO bulletSO = BulletList.bullets[0];        
        TankModel tankModel = new TankModel(tankSO, bulletSO);
        TankController tankController = new TankController(tankModel, tankSO.tankView);
    }
    private void CreateEnemyTank(int index)
    {
        TankScriptable enemytankSO = tankList.tanks[index];
        BulletSO bulletSO = BulletList.bullets[0];
        EnemyTankModel enemytankModel = new EnemyTankModel(enemytankSO, bulletSO);
        EnemyTankController enemytankController = new EnemyTankController(enemytankModel, enemytankSO.enemytankView);
    }

}
