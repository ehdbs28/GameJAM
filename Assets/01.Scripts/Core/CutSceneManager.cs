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

    public void Theme1CutScene()
    {
        StartCoroutine(CutSceneCoroutine("Theme1"));
    }

    IEnumerator CutSceneCoroutine(string name)
    {
        switch (name)
        {
            case "Theme1":
                _player.IsAttack = true;
                CameraManager.Instance.SetToTheme1();
                _bossName.DOColor(new Color(255, 255, 255, 1), 5);
                yield return new WaitForSeconds(4f);
                CameraManager.Instance.SetToMainVCam();
                UIManager.Instance.IsClear = false;
                _player.IsAttack = false;
                OnActive.Invoke();
                break;
        }
    }
}
