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
        //Time.timeScale = 1f;
        
        StartCoroutine(StartScene());
        
    }

    IEnumerator StartScene()
    {
        SceneController.Instance.ClickToPlay();
        yield return new WaitForSeconds(2);
        SceneController.Instance.LoadRespectiveScene(1);
    }
}
