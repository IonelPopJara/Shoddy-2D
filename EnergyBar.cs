using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    private Slider energySlider;
    private TimeManager timeManager;

    private void Start()
    {
        energySlider = gameObject.GetComponent<Slider>();
        timeManager = GameObject.FindObjectOfType<TimeManager>();
    }

    private void Update()
    {
        energySlider.maxValue = timeManager.maxEnergy;
        energySlider.value = timeManager.slowdownEnergy;
    }
}
