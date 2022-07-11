using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance = null;

    [SerializeField] private CinemachineVirtualCamera _mainVcam;

    [SerializeField] private List<Transform> _stageTrm = new List<Transform>();

    int i = 1;

    private void Start()
    {
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
        _mainVcam.Follow = _stageTrm[stageNum - 1];
    }
}
