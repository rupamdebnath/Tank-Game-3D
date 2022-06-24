using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingletonGeneric<GameManager>
{
    
    public GameObject deathText;

    public Button playButton;
    public Button pauseButton;
    public GameObject pauseMenu;
    public TankService tankService;

    public void PlayFromPause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
    }

    public void PlayerDeath()
    {
        DeathText();
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<TankView>().enabled = false;
        }
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyTankView>().enabled = false;
        }
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
            Pause();
            Time.timeScale = 1f;            
        }
    }

    public void DeathText()
    {
        deathText.gameObject.SetActive(true);
        //SceneController.Instance.StopSpecificSound(0);        
    }
    private void Update()
    {
        if (ServiceEvents.Instance.GetCountOfEnemiesDead() == 2)
        {
            Debug.Log(ServiceEvents.Instance.GetCountOfEnemiesDead());
           
            SceneController.Instance.StartSpecificSound(3);
            EnemyDeath();
        }
        else
            deathText.GetComponent<TextMeshProUGUI>().text = "Game Over You are Dead!";
    }

    private void EnemyDeath()
    {
        deathText.GetComponent<TextMeshProUGUI>().text = "Congratulations You won!";
        PlayerDeath();
    }
}
