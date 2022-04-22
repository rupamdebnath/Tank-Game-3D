using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    public TankView tankView;

    void Start()
    {
        Instantiate(tankView.gameObject, transform.position, Quaternion.identity);
    }

    private void CreateTank()
    {

    }

}
