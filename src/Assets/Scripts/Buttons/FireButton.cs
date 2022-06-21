using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireButton : MonoBehaviour
{
    Button button;
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {   if (GameObject.FindWithTag("Player") != null)
        {
            GameObject.FindWithTag("Player").GetComponent<TankView>().getTankController().SetClickedFireButton(true);
        }
    }
}
