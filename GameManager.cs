using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject LevelCompletedPanel;
    private bool gameHasEnded = false;

    private void Start()
    {
        if (LevelCompletedPanel != null)
            LevelCompletedPanel.SetActive(false);
    }
    public void PlayerCrash()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("U Ded");
            Invoke("Restart", 1f);
        }
    }

    public void LevelCompleted()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
        }

        Invoke("SetLevelCompletedPanelActive", 2f);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SetLevelCompletedPanelActive()
    {
        LevelCompletedPanel.SetActive(true);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void LoadLevel0()
    {
        SceneManager.LoadScene("Level 0");
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level 4");
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    public void LoadLevel5()
    {
        SceneManager.LoadScene("Level 5");
        FindObjectOfType<AudioManager>().Play("Theme");
    }
}
