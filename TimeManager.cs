using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float slowdownFactor;
    private float slowdownLength;

    public float maxEnergy;
    public float slowdownEnergy;
    public bool slowTime;

    public float chargingTime;
    private float currentTime;

    public float decrement;
    public float increment;

    private void Start()
    {
        slowTime = false;
        slowdownFactor = 0.02f;
        slowdownLength = 2f;

        slowdownEnergy = maxEnergy;
    }

    private void Update()
    {
        TimeMonitor();
        timeEnergy();

        if(Input.GetKeyDown(KeyCode.X))
        {
            slowTime = true;

            if(slowTime)
            {
                FindObjectOfType<AudioManager>().Play("Time Slow");
            }
        }
        else if(Input.GetKeyUp(KeyCode.X))
        {
            slowTime = false;

            if (!slowTime)
            {
                FindObjectOfType<AudioManager>().Play("Time Speed");
            }
        }
    }

    public void DoSlowmotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    public void TimeSpeedUp()
    {
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    private void TimeMonitor()
    {
        if (slowTime)
        {
            DoSlowmotion();
        }
        else if (!slowTime)
        {
            TimeSpeedUp();
        }
    }

    private void timeEnergy()
    {
        slowdownEnergy = Mathf.Clamp(slowdownEnergy, 0f, maxEnergy);

        if (slowTime)
        {
            if(currentTime > 0f)
            {
                currentTime -= Time.deltaTime;
            }
            else
            {
                slowdownEnergy -= decrement;
                currentTime = chargingTime;
            }
        }
        else if (!slowTime)
        {
            if (currentTime > 0f)
            {
                currentTime -= Time.deltaTime;
            }
            else
            {
                slowdownEnergy += increment;
                currentTime = chargingTime;
            }
        }

        if(slowdownEnergy == 0)
        {
            slowTime = false;
        }
    }
}
