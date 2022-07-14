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
        _storyTxt.text = "��, ��, ��\n�� ������ ��� ���� �տ� ���� ����";
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 1), 1.5f));
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 0), 1.5f));
    }

    private void Story2()
    {
        Sequence sq = DOTween.Sequence();

        _storyTxt.text = "ž�� �� ī����.";
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 1), 1.5f));
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 0), 1.5f));
    }

    private void Story3()
    {
        Sequence sq = DOTween.Sequence();
        
        _storyTxt.text = "�װ� �ױ� ���� �� �Ѹ����\n������� ž���� ���ϰ� �ߴ�.";
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 1), 1.5f));
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 0), 1.5f));
    }

    private void Story4()
    {
        Sequence sq = DOTween.Sequence();

        _sky.SetActive(false);
        _castle.SetActive(true);
        _storyTxt.text = "'�� ������ ���̳�..? ���Ѵٸ� �ְڴ�. ã�ƺ��� !\n�� ���� ������ �ű⿡ �ΰ� �Դ� !'";
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 1), 1.5f));
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 0), 1.5f));
    }

    private void Story5()
    {
        Sequence sq = DOTween.Sequence();

        _storyTxt.text = "�糪�̵��� ������ ž�� ã�Ƽ�\n���� ���ư���!";
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 1), 1.5f));
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 0), 1.5f));
    }

    private void Story6()
    {
        Sequence sq = DOTween.Sequence();

        _storyTxt.text = "������ ��Ž���� �ô� !";
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 1), 1.5f));
        _castle.GetComponent<Image>().DOFade(0, 1);
        sq.Append(_storyTxt.DOColor(new Color(255, 255, 255, 0), 1.5f));
    }
}
