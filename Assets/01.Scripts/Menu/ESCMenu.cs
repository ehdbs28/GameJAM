using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ESCMenu : ButtonManager
{
    [SerializeField] private TextMeshProUGUI _selectText;
    private void Update()
    {
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
            if(_currentBtnNum == 1)
            {
                MenuManager.Instance.IsEsc = false;
                MenuManager.Instance.IsSetting = true;
            }
            if (_currentBtnNum == 0)
            {
                //메뉴로이동
            }
        }
    }
}
