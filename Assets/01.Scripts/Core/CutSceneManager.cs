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
    [SerializeField] UnityEvent OnActive3;

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

    public void BossStartCutScene()
    {
        StartCoroutine(CutSceneCoroutine("BossStart"));
    }

    IEnumerator CutSceneCoroutine(string name)
    {
        switch (name)
        {
            case "Theme1":
                _player.IsAttack = true;
                CameraManager.Instance.SetToTheme1();
                _bossName.text = "-쇼크 스위퍼-";
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
                _bossName.text = "-트리플 세이버-";
                _bossName.DOColor(new Color(255, 255, 255, 1), 5);
                yield return new WaitForSeconds(3f);
                CameraManager.Instance.SetToMainVCam();
                _player.IsAttack = false;
                _bossName.DOColor(new Color(255, 255, 255, 0), 5);
                OnActive2.Invoke();
                break;
            case "BossStart":
                _player.IsAttack = true;
                CameraManager.Instance.SetToBossZoomin();
                _bossName.text = "-블러드 킹-";
                _bossName.DOColor(new Color(255, 0, 0, 1), 5);
                yield return new WaitForSeconds(5f);
                CameraManager.Instance.SetToBossVCam();
                _bossName.DOColor(new Color(255, 0, 0, 0), 5);
                yield return new WaitForSeconds(2f);
                _player.IsAttack = false;
                OnActive3.Invoke();
                break;
        }
    }
}
