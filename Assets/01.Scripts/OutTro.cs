using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class OutTro : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _summerTxt;

    private void Start()
    {
        StartCoroutine(Outtro());
    }

    IEnumerator Outtro()
    {
        _summerTxt.DOText("�ᱹ ž�� ������ ��� �㱸����.", 2f);
        yield return new WaitForSeconds(3f);
        _summerTxt.text = "";
        _summerTxt.DOText("�����̾���...", 3.5f);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("StartScene");
    }
}
