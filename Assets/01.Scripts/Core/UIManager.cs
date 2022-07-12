using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;
    [SerializeField] private Button startButton;

    [SerializeField] private Image fadeImage;

    public RectTransform _ablityPanelTrm;

    bool isClear = false;

    public bool IsClear
    {
        get
        {
            return isClear;
        }
        set
        {
            isClear = value;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            isClear=true;
            Ablity();
        }
    }

    public void Fade()
    {
        StartCoroutine(IEFade());
    }

    public void FadeIn()
    {
        fadeImage.DOFade(1, 1.3f);
    }

    public void FadeOut()
    {
        fadeImage.DOFade(0, 0.7f);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Ablity()
    {
        StartCoroutine(AblityPanelUp());
    }

    IEnumerator AblityPanelUp()
    {
        while (true)
        {
            if (isClear == true)
            {
                _ablityPanelTrm.transform.DOMoveY(0, 1f);
            }
            else
            {
                _ablityPanelTrm.transform.DOMoveY(-1200, 1f);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator IEFade()
    {
        FadeIn();

        yield return new WaitForSeconds(2f);

        FadeOut();
    }
}
