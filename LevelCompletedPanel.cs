using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletedPanel : MonoBehaviour
{
    public TextMeshProUGUI levelCompleted;
    public TextMeshProUGUI yourTime;
    public TextMeshProUGUI bestTime;

    private void Start()
    {
        levelCompleted.text = SceneManager.GetActiveScene().name + " Completed";
        yourTime.text = "Your Time: " + GameObject.FindObjectOfType<LevelTimer>().currentTime.ToString();
        bestTime.text = "Best Time: " + PlayerPrefs.GetFloat("BestTime" + SceneManager.GetActiveScene().name).ToString();
    }

    public void MainMenu()
    {
        FindObjectOfType<GameManager>().Menu();
    }

    public void NextLevel()
    {
        FindObjectOfType<GameManager>().LoadNextLevel();
    }

    public void TryAgain()
    {
        FindObjectOfType<GameManager>().Restart();
    }
}
