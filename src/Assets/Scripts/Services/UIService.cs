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
    }

    void ShowEnemiesKilled(int value)
    {
        EnemiesKilledText.text = "Enemies Killed: " + value;
    }
}
