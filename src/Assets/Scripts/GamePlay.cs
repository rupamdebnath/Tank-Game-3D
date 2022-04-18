using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        PlayerTank.Instance.PlayerMovement();
        EnemyTank.Instance.EnemyMovement();
    }
    private void Start()
    {

    }

}
