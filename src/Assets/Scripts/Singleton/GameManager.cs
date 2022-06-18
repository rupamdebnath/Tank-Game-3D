using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoSingletonGeneric<GameManager>
{
    
    public void PlayerDeath()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<TankView>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyTankView>().enabled = false;
        StartCoroutine(CameraAnime());        
    }

    IEnumerator CameraAnime()
    {
        yield return new WaitForSeconds(2f);       
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(-80.5f, 58.3f, -68.4f);
        GameObject.FindGameObjectWithTag("MainCamera").transform.rotation = Quaternion.Euler(21.609f, 52.41f, 0);
        StartCoroutine(EnemyAnime());
    }

    IEnumerator EnemyAnime()
    {
        yield return new WaitForSeconds(1f);
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            StartCoroutine(EnemyAnime());
        }
        StartCoroutine(OtherObjectsAnime());
    }

    IEnumerator OtherObjectsAnime()
    {
        yield return new WaitForSeconds(1f);
        if (GameObject.FindGameObjectWithTag("LevelArt") != null)
        {            
            Destroy(GameObject.FindGameObjectWithTag("LevelArt"));
            StartCoroutine(OtherObjectsAnime());
        }
        else
        {
            Debug.Log("Exiting applciation, Game is over");
            EditorApplication.ExitPlaymode();
        }
    }
}
