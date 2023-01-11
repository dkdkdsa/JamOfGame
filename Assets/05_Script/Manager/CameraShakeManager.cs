using Cinemachine;
using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeManager : MonoBehaviour
{

    private CinemachineVirtualCamera cvcam;
    private CinemachineBasicMultiChannelPerlin cbmcp;

    private void Awake()
    {
        
        cvcam = GetComponent<CinemachineVirtualCamera>();

        cbmcp = cvcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

    }

    public void Shake(float value, float num, float duration)
    {

        FAED.InvokeDelay(() =>
        {

            cbmcp.m_AmplitudeGain -= value;
            cbmcp.m_FrequencyGain -= num;

        }, duration);

        cbmcp.m_AmplitudeGain += value;
        cbmcp.m_FrequencyGain += num;

    }

}
