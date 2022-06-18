using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    Button button;
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        StartCoroutine(WaitUntilPlayed(2));
    }

    IEnumerator WaitUntilPlayed(float _length)
    {
        SceneController.Instance.StartSpecificSound(1);
        yield return new WaitForSeconds(_length);
        SceneController.Instance.StopAllSounds();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
