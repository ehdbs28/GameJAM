using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance = null;

    private GameObject _escMenu;
    private GameObject _settingMenu;

    private Image fade;

    private bool _isEsc = false;

    PlayerAttack player;
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

    private bool isMain = false;

    public bool IsMain
    {
        get => isMain;
        set => isMain = value;
    }

    private void Awake()
    {
        _escMenu = GameObject.Find("Canvas/ESCMenu/ESCPanel");
        _settingMenu = GameObject.Find("Canvas/ESCMenu/SettingMenu");

        fade = GameObject.Find("Canvas/FadeImage").GetComponent<Image>();

        player = FindObjectOfType<PlayerAttack>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isSetting)
            {
                _isEsc = !_isEsc;
            }

            StartCoroutine(Pause());
        }

        _escMenu.SetActive(_isEsc ? true : false);
        _settingMenu.SetActive(_isSetting ? true : false);
    }

    IEnumerator Pause()
    {

        while (true)
        {
            if (_isEsc)
            {
                _escMenu.GetComponent<Image>().DOFade(0.4f, 0.5f);

                yield return new WaitForSecondsRealtime(0.5f);
                Time.timeScale = _isEsc || _isSetting ? 0 : 1;
            }
            else
            {
                Time.timeScale = _isEsc || _isSetting ? 0 : 1;
                _escMenu.GetComponent<Image>().DOFade(0, 0.5f);

                yield return new WaitForSecondsRealtime(0.5f);
            }

            if (IsMain)
            {
                SoundManager.Instance.SFXPlay(player.clip);
                yield return new WaitForSecondsRealtime(0.5F);
                Time.timeScale = 1;

                SceneManager.LoadScene("StartScene");

            }
        }
    }
}
