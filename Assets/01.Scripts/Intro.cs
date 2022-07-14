using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _storyTxt;
    [SerializeField] private GameObject _sky;
    [SerializeField] private GameObject _castle;

    private void Start()
    {
        StartCoroutine(StoryCoroutine());
    }

    IEnumerator StoryCoroutine()
    {
        Story1();
        yield return new WaitForSeconds(3f);
        Story2();
        yield return new WaitForSeconds(3f);
        Story3();
        yield return new WaitForSeconds(3f);
        Story4();
        yield return new WaitForSeconds(3f);
        Story5();
        yield return new WaitForSeconds(3f);
        Story6();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Main");
    }

    private void Story1()
    {
        Sequence sq = DOTween.Sequence();

        _sky.SetActive(true);
        _castle.SetActive(false);
        _storyTxt.text = "부, 명성, 힘\n이 세상의 모든 것을 손에 넣은 남자";
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 1), 1.5f));
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 0), 1.5f));
    }

    private void Story2()
    {
        Sequence sq = DOTween.Sequence();

        _storyTxt.text = "탑의 왕 카리브.";
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 1), 1.5f));
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 0), 1.5f));
    }

    private void Story3()
    {
        Sequence sq = DOTween.Sequence();
        
        _storyTxt.text = "그가 죽기 전에 한 한마디는\n사람들을 탑으로 향하게 했다.";
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 1), 1.5f));
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 0), 1.5f));
    }

    private void Story4()
    {
        Sequence sq = DOTween.Sequence();

        _sky.SetActive(false);
        _castle.SetActive(true);
        _storyTxt.text = "'내 보물들 말이냐..? 원한다면 주겠다. 찾아봐라 !\n이 세상 모든것을 거기에 두고 왔다 !'";
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 1), 1.5f));
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 0), 1.5f));
    }

    private void Story5()
    {
        Sequence sq = DOTween.Sequence();

        _storyTxt.text = "사나이들은 위대한 탑을 찾아서\n꿈을 좇아간다!";
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 1), 1.5f));
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 0), 1.5f));
    }

    private void Story6()
    {
        Sequence sq = DOTween.Sequence();

        _storyTxt.text = "세상은 대탐험의 시대 !";
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 1), 1.5f));
        _castle.GetComponent<Image>().DOFade(0, 1);
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 0), 1.5f));
    }
}
