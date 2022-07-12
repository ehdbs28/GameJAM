using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;
    private Button startButton;

    [SerializeField] private Image fadeImage;

    private void Awake()
    {
        
    }
    private void Start()
    {
        
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

    public void Ablity()
    {

    }

    IEnumerator IEFade()
    {
        FadeIn();

        yield return new WaitForSeconds(2f);

        FadeOut();
    }
}
