using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIService : MonoBehaviour
{
    public TextMeshProUGUI BulletCountText;
    public TextMeshProUGUI EnemiesKilledText;

    private void Update()
    {
        BulletCountText.text = "Bullets Fired: " + 12;
        EnemiesKilledText.text = "Enemies Killed: " + 10;
        
    }
}
