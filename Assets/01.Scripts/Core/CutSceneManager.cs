using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.Events;

public class CutSceneManager : MonoBehaviour
{
    public static CutSceneManager Instance = null;

    [SerializeField] TextMeshProUGUI _bossName;
    [SerializeField] PlayerAttack _player;
    [SerializeField] UnityEvent OnActive;
    [SerializeField] UnityEvent OnActive2;

    public void Intro()
    {
        StartCoroutine(CutSceneCoroutine("Intro"));
    }

    public void Theme1CutScene()
    {
        StartCoroutine(CutSceneCoroutine("Theme1"));
    }

    public void Theme2CutScene()
    {
        StartCoroutine(CutSceneCoroutine("Theme2"));
    }

    IEnumerator CutSceneCoroutine(string name)
    {
        switch (name)
        {
            case "Theme1":
                _player.IsAttack = true;
                CameraManager.Instance.SetToTheme1();
                _bossName.text = "'쇼크 스위퍼'";
                _bossName.DOColor(new Color(255, 255, 255, 1), 5);
                yield return new WaitForSeconds(3f);
                CameraManager.Instance.SetToMainVCam();
                _player.IsAttack = false;
                _bossName.DOColor(new Color(255, 255, 255, 0), 5);
                OnActive.Invoke();
                break;
            case "Theme2":
                _player.IsAttack = true;
                CameraManager.Instance.SetToTheme2();
                _bossName.text = "'트리플 세이버'";
                _bossName.DOColor(new Color(255, 255, 255, 1), 5);
                yield return new WaitForSeconds(3f);
                CameraManager.Instance.SetToMainVCam();
                _player.IsAttack = false;
                _bossName.DOColor(new Color(255, 255, 255, 0), 5);
                OnActive2.Invoke();
                break;
        }
    }
}
