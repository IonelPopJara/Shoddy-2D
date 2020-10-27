using Cinemachine;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    private TimeManager timeManager;

    public float zoomIncrement;
    public float zoomDecrement;

    public float maxOrtographicSize;
    public float minOrtographicSize;

    private bool isZoomed;

    private void Start()
    {
        timeManager = GameObject.FindObjectOfType<TimeManager>();

        maxOrtographicSize = 10;
        minOrtographicSize = 5;
    }

    private void Update()
    {
        isZoomed = timeManager.slowTime;

        if(isZoomed)
        {
            vcam.m_Lens.OrthographicSize = Mathf.Lerp(vcam.m_Lens.OrthographicSize, minOrtographicSize, zoomIncrement * Time.deltaTime);
        }

        else if(!isZoomed)
        {
            vcam.m_Lens.OrthographicSize = Mathf.Lerp(vcam.m_Lens.OrthographicSize, maxOrtographicSize, zoomDecrement * Time.deltaTime);
        }
    }
}
