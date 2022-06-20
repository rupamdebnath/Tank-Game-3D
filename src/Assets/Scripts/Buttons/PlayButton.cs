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
        SceneController.Instance.StartSpecificSound(1);
        StartCoroutine(StartScene());
        
    }

    IEnumerator StartScene()
    {        
        yield return new WaitForSeconds(2);
        SceneController.Instance.ClickToPlay();
        SceneController.Instance.LoadRespectiveScene(1);
    }
}
