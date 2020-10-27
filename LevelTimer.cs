using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    public float currentTime;
    public bool start;

    private void Start()
    {
        currentTime = 0;
    }
    private void Update()
    {
        if(start)
        {
            currentTime += Time.unscaledDeltaTime;
        }
    }
}
