using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    Button button;
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        GameManager.Instance.ClickToPlay();
        GameManager.Instance.StartSpecificSound(0);
        GameManager.Instance.DisableScreen();
    }
}
