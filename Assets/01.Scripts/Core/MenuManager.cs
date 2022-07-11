using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance = null;

    private GameObject _escMenu;
    private GameObject _settingMenu;

    private bool _isEsc = false;
    public bool IsEsc
    {
        set => _isEsc = value;

        get => _isEsc;
    }

    private bool _isSetting = false;
    public bool IsSetting
    {
        set => _isSetting = value;

        get => _isSetting;
    }

    private void Awake()
    {
        _escMenu = GameObject.Find("Canvas/ESCMenu/ESCPanel");
        _settingMenu = GameObject.Find("Canvas/ESCMenu/SettingMenu");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isEsc = !_isEsc;

            StartCoroutine(¹ú¸´());
        }

        _escMenu.SetActive(_isEsc ? true : false);
        _settingMenu.SetActive(_isSetting ? true : false);

    }

    IEnumerator ¹ú¸´()
    {
        if (_isEsc)
        {
            _escMenu.GetComponent<Image>().DOFade(0.8f, 0.5f);

            yield return new WaitForSecondsRealtime(0.5f);
            Time.timeScale = _isEsc || _isSetting ? 0 : 1;
        }
        else
        {
            Time.timeScale = _isEsc || _isSetting ? 0 : 1;
            _escMenu.GetComponent<Image>().DOFade(0, 0.5f);

            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
