using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{
    Button button;
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Time.timeScale = 1f;
        SceneController.Instance.StartSpecificSound(1);
        StartCoroutine(StartScene());

    }

    IEnumerator StartScene()
    {
        yield return new WaitForSeconds(1);
        SceneController.Instance.StopAllSounds();
        SceneController.Instance.LoadRespectiveScene(0);
    }
}
