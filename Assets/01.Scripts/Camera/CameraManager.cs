using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance = null;

    [SerializeField] private List<Transform> _stageTrm = new List<Transform>();

    private CinemachineVirtualCamera _mainVcam;
    private CinemachineBasicMultiChannelPerlin _mainPerlin;

    int i = 1;

    private void Start()
    {
        _mainVcam = GameObject.Find("MainVcam").GetComponent<CinemachineVirtualCamera>();
        _mainPerlin = _mainVcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        CameraMove(1);
    }

    private void Update()
    {
        //test
        if (Input.GetKeyDown(KeyCode.C))
        {
            i++;
            CameraMove(i);
        }
    }

    public void CameraMove(int stageNum)
    {
        if (_stageTrm.Count < stageNum) return;
        _mainVcam.Follow = _stageTrm[stageNum - 1];
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
