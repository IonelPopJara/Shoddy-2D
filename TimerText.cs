using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    private TextMeshProUGUI timer;
    private LevelTimer levelTimer;

    private void Start()
    {
        timer = gameObject.GetComponent<TextMeshProUGUI>();
        levelTimer = GameObject.FindObjectOfType<LevelTimer>();
    }

    private void Update()
    {
        timer.text = "Time: " + levelTimer.currentTime.ToString();
    }
}
