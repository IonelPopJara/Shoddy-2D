using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    private void Start()
    {
        if(virtualCamera != null)
        {
            virtualCameraNoise = virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        }
    }

    public IEnumerator Shake(float duration, float shakeAmplitude, float shakeFrequency)
    {
        float elapsed = 0.0f;

        if (virtualCamera != null && virtualCameraNoise != null)
        {
            while (elapsed < duration)
            {
                virtualCameraNoise.m_AmplitudeGain = shakeAmplitude;
                virtualCameraNoise.m_FrequencyGain = shakeFrequency;

                elapsed += Time.deltaTime;

                yield return null;
            }

            virtualCameraNoise.m_AmplitudeGain = 0f;
        }    
    }
}
