using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIService : MonoBehaviour
{
    public TextMeshProUGUI BulletCountText;
    public TextMeshProUGUI EnemiesKilledText;

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
                Debug.Log("Bullet Achievement 1 Completed, 10 bullets successfully fired");
                break;
            case 25:
                Debug.Log("Bullet Achievement 2 Completed, 25 bullets successfully fired");
                break;
            case 50:
                Debug.Log("Bullet Achievement 3 Completed, 50 bullets successfully fired");
                break;
        }
    }

    void ShowEnemiesKilled(int value)
    {
        EnemiesKilledText.text = "Enemies Killed: " + value;
    }
}
