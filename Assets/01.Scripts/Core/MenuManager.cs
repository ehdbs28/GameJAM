using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }

        _escMenu.SetActive(_isEsc ? true : false);
        _settingMenu.SetActive(_isSetting ? true : false);

        Time.timeScale = _isEsc || _isSetting ? 0 : 1;
    }
}
