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

    private PlayerAttack player;

    public RectTransform _ablityPanelTrm;

    bool isHowTo = false;

    [SerializeField]
    GameObject _howToPlayPanel;

    NumberLine numberLine;

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
    private PlayerAttack _player;

    private void Start()
    {
        player = FindObjectOfType<PlayerAttack>();

        theme1 = FindObjectOfType<Theme1Boss>();

        numberLine = FindObjectOfType<NumberLine>();

        _player = FindObjectOfType<PlayerAttack>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isHowTo)
        {
            HowTo();
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

        PlayerPrefs.SetInt("Hard", 0);
        FadeIn();
        seq.AppendInterval(1.5f);

        seq.AppendCallback(() =>
        {
            SceneManager.LoadScene(1);
        });
    }

    public void HardMode()
    {
        Sequence seq = DOTween.Sequence();

        PlayerPrefs.SetInt("Hard", 1);
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

    public void HowTo()
    {
        isHowTo = !isHowTo;

        _howToPlayPanel.SetActive(isHowTo ? true : false);
    }

    IEnumerator IEFade()
    {
        FadeIn();

        yield return new WaitForSeconds(2f);

        FadeOut();

        yield return new WaitForSeconds(0.7f);

        isClear = false;
        _player.IsAttack = false;

        if (StageManager.Instance.CurrentStageNum == 5)
        {
            CutSceneManager.Instance.Theme1CutScene();
        }
        else if (StageManager.Instance.CurrentStageNum == 10)
        {
            CutSceneManager.Instance.Theme2CutScene();
        }
        else if (StageManager.Instance.CurrentStageNum == 11)
        {
            CutSceneManager.Instance.BossStartCutScene();
        }
    }
}
