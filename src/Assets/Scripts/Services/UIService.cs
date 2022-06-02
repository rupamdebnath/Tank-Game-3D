using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    public TextMeshProUGUI BulletCountText;
    public TextMeshProUGUI EnemiesKilledText;
    public Toggle achievementToggle;
    private void OnEnable()
    {
        ServiceEvents.Instance.OnFire += GetBulletsFired;
        ServiceEvents.Instance.OnEnemyDeath += ShowEnemiesKilled;
    }
    private void OnDisable()
    {
        ServiceEvents.Instance.OnFire -= GetBulletsFired;
        ServiceEvents.Instance.OnEnemyDeath -= ShowEnemiesKilled;
    }

    void GetBulletsFired(int value)
    {
        BulletCountText.text = "Bullets Fired: " + value;
        switch(value)
        {
            case 10:
                StartCoroutine(ToggleAction("Achievement Unlocked : Fire 10 bullets"));
                break;
            case 25:
                StartCoroutine(ToggleAction("Achievement Unlocked : Fire 25 bullets"));
                break;
            case 50:
                StartCoroutine(ToggleAction("Achievement Unlocked : Fire 50 bullets"));
                break;
        }
    }

    void ShowEnemiesKilled(int value)
    {
        EnemiesKilledText.text = "Enemies Killed: " + value;
    }

    IEnumerator ToggleAction(string achievementText)
    {
        achievementToggle.gameObject.SetActive(true);
        achievementToggle.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = achievementText;
        yield return new WaitForSeconds(1);
        achievementToggle.isOn = true;
        achievementToggle.gameObject.GetComponentInChildren<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
        yield return new WaitForSeconds(2);
        achievementToggle.gameObject.SetActive(false);
        achievementToggle.isOn = false;
        achievementToggle.gameObject.GetComponentInChildren<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
    }
}
