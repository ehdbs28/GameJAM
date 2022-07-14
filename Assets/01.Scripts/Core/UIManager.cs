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

    Theme1Boss theme1;

    private void Start()
    {
        theme1 = FindObjectOfType<Theme1Boss>();
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
        Sequence seq = DOTween.Sequence();

        FadeIn();
        seq.AppendInterval(1.5f);

        seq.AppendCallback(() =>
        {
            SceneManager.LoadScene(1);
        });
    }

    public void QuitGame()
    {
        Sequence seq = DOTween.Sequence();

        FadeIn();
        seq.AppendInterval(1.5f);

        seq.AppendCallback(() =>
        {
            Application.Quit();
        });
    }

    public void Ablity()
    {
        StartCoroutine(AblityPanelUp());
    }
    int index = 0;
    IEnumerator AblityPanelUp()
    {
        Sequence seq = DOTween.Sequence();
        while (true)
        {
            if (isClear == true && index == 0)
            {
                index++;

                seq.Append(_ablityPanelTrm.transform.DOMoveY(0, 0.5f));

                seq.OnComplete(() =>
                {
                    SkillManager.Instance.SkillSelect();
                });
                
            }
            if(isClear == false && index == 1)
            {
                index--;
                seq.Append(_ablityPanelTrm.transform.DOMoveY(1200, 0.5f));

                seq.OnComplete(() =>
                {
                    SkillManager.Instance.SkillDel();
                });
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
