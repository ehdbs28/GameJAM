using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Setting : ButtonManager
{
    [SerializeField] private TextMeshProUGUI _selectText;
    [SerializeField]
    Button button;
    bool _isSetting = false;
    [SerializeField] private GameObject _settingMenu;
    public void SettingM()
    {
        _isSetting = !_isSetting;
    }
    void Update()
    {
        _settingMenu.SetActive(_isSetting ? true : false);
        button.interactable = !_isSetting ? true : false;

        BtnMove();
        if (_currentBtnNum == 2) { _selectText.text = ">                 <"; }
        if (_currentBtnNum == 1) { _selectText.text = ">         <"; }
        if (_currentBtnNum == 0) { _selectText.text = ">                      <"; }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (_currentBtnNum == 2)
            {
                MenuManager.Instance.IsEsc = false;
            }
            if (_currentBtnNum == 1)
            {
                MenuManager.Instance.IsEsc = false;
                MenuManager.Instance.IsSetting = true;
            }
            if (_currentBtnNum == 0)
            {
                _isSetting = !_isSetting;
            }
        }
    }
}
