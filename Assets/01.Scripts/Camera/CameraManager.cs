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
    private CinemachineVirtualCamera _theme1Vcam;
    private CinemachineVirtualCamera _theme2Vcam;
    private CinemachineVirtualCamera _bossPhase1Vcam;

    private CinemachineBasicMultiChannelPerlin _mainPerlin;
    private CinemachineBasicMultiChannelPerlin _theme1Perlin;
    private CinemachineBasicMultiChannelPerlin _theme2Perlin;
    private CinemachineBasicMultiChannelPerlin _bossPhasePerlin;

    private const int _backPriority = 10;
    private const int _frontPriority = 15;

    private CinemachineVirtualCamera _activeVcam = null;
    private CinemachineBasicMultiChannelPerlin _activePerlin = null;

    private void Start()
    {
        _rigTrm = GameObject.Find("CamRig").transform;

        _mainVcam = GameObject.Find("MainVcam").GetComponent<CinemachineVirtualCamera>();
        _theme1Vcam = GameObject.Find("Theme1VCam").GetComponent<CinemachineVirtualCamera>();
        _theme2Vcam = GameObject.Find("Theme2VCam").GetComponent<CinemachineVirtualCamera>();
        _bossPhase1Vcam = GameObject.Find("BossPhase1VCam").GetComponent<CinemachineVirtualCamera>();

        _mainPerlin = _mainVcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _theme1Perlin = _theme1Vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _theme2Perlin = _theme1Vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _bossPhasePerlin = _bossPhase1Vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        _mainVcam.Follow = _rigTrm;
        _mainPerlin.m_AmplitudeGain = 0;

        SetToMainVCam();
    }

    public void SetToMainVCam()
    {
        _mainVcam.Priority = _frontPriority;
        _theme1Vcam.Priority = _backPriority;
        _theme2Vcam.Priority = _backPriority;
        _bossPhase1Vcam.Priority = _backPriority;

        _activeVcam = _mainVcam;
        _activePerlin = _mainPerlin;
    }

    public void SetToTheme1()
    {
        _mainVcam.Priority = _backPriority;
        _theme1Vcam.Priority = _frontPriority;
        _theme2Vcam.Priority = _backPriority;
        _bossPhase1Vcam.Priority = _backPriority;

        _activeVcam = _theme1Vcam;
        _activePerlin = _theme1Perlin;
    }

    public void SetToTheme2()
    {
        _mainVcam.Priority = _backPriority;
        _theme1Vcam.Priority = _backPriority;
        _theme2Vcam.Priority = _frontPriority;
        _bossPhase1Vcam.Priority = _backPriority;

        _activeVcam = _theme2Vcam;
        _activePerlin = _theme2Perlin;
    }

    public void SetToBossVCam()
    {
        _mainVcam.Priority = _backPriority;
        _theme1Vcam.Priority = _backPriority;
        _theme2Vcam.Priority = _backPriority;
        _bossPhase1Vcam.Priority = _frontPriority;

        _activeVcam = _bossPhase1Vcam;
        _activePerlin = _bossPhasePerlin;
    }

    public void RigMove(int stageNum, float time)
    {
        if (_stageTrm.Count < stageNum) return;
        _rigTrm.DOMoveY(_stageTrm[stageNum].position.y, time);
    }

    public void ShakeCam(float intensity, float time)
    {
        if (_activeVcam == null || _activePerlin == null) return;
        StopAllCoroutines();
        StartCoroutine(ShakeCamCoroutine(intensity, time));
    }

    IEnumerator ShakeCamCoroutine(float intensity, float endtime)
    {
        _activePerlin.m_AmplitudeGain = intensity;

        float currentTime = 0f;
        while(currentTime < endtime)
        {
            yield return new WaitForEndOfFrame();
            if (_activePerlin == null) break;

            _activePerlin.m_AmplitudeGain = Mathf.Lerp(intensity, 0, currentTime / endtime);
            currentTime += Time.deltaTime;
        }
        if(_activePerlin != null)
        {
            _activePerlin.m_AmplitudeGain = 0;
        }
    }
}
