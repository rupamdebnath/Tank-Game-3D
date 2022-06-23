using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    Button button;

    GameObject PlayButton;
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {        
        SceneController.Instance.StartSpecificSound(1);
        GameManager.Instance.Pause();
    }
}
