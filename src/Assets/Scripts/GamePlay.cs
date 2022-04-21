using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
   
    public void Awake()
    {
        Debug.Log("Awake called in GamePlay");
        Test();
    }

    public void Update()
    {
        //PlayerTank.Instance.PlayerMovement();
        //EnemyTank.Instance.EnemyMovement();
    }

    void Test()
    {
        Debug.Log("Inside Test");
        PlayerTank.Instance.PlayerMovement();
    }

}
