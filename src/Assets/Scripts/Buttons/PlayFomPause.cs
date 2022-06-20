using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayFomPause : MonoBehaviour
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
        GameManager.Instance.PlayFromPause();
    }
}
