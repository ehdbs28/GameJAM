using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance = null;

    [SerializeField] private List<Transform> _stageTrm = new List<Transform>();

    private Transform _rigTrm;
    private CinemachineVirtualCamera _mainVcam;
    private CinemachineBasicMultiChannelPerlin _mainPerlin;

    private void Start()
    {
        _rigTrm = GameObject.Find("CamRig").transform;
        _mainVcam = GameObject.Find("MainVcam").GetComponent<CinemachineVirtualCamera>();
        _mainPerlin = _mainVcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        _mainVcam.Follow = _rigTrm;
    }

    public void RigMove(int stageNum, float time)
    {
        if (_stageTrm.Count < stageNum) return;
        _rigTrm.DOMoveY(_stageTrm[stageNum].position.y, time);
    }

    public void ShakeCam(float intensity, float time)
    {
        if (_mainPerlin == null) return;
        StopAllCoroutines();
        StartCoroutine(ShakeCamCoroutine(intensity, time));
    }

    IEnumerator ShakeCamCoroutine(float intensity, float endtime)
    {
        _mainPerlin.m_AmplitudeGain = intensity;

        float currentTime = 0f;
        while(currentTime < endtime)
        {
            yield return new WaitForEndOfFrame();
            if (_mainPerlin == null) break;

            _mainPerlin.m_AmplitudeGain = Mathf.Lerp(intensity, 0, currentTime / endtime);
            currentTime += Time.deltaTime;
        }
        if(_mainPerlin != null)
        {
            _mainPerlin.m_AmplitudeGain = 0;
        }
    }
}
