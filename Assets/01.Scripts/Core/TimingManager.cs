using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class TimingManager : MonoBehaviour
{
    public static TimingManager Instance;

    [SerializeField]
    TextMeshProUGUI _timerTxt;
    PlayerDamaged _player;
    PlayerAttack _playerAttack;

    private void Start()
    {
        _player = FindObjectOfType<PlayerDamaged>();
        _playerAttack = FindObjectOfType<PlayerAttack>();
    }

    public void StopTime()
    {

        StopCoroutine(TimeCoroutine(3));
        print("타이머 멈춤");

    }

    public void Timer(float sec)
    {
        StartCoroutine(TimeCoroutine(sec));
        print($"타이머 시작{sec}");
    }

    int i = 0;

    IEnumerator TimeCoroutine(float sec)
    {
        _timerTxt.text = string.Format("{0:N2}", sec);
        _timerTxt.color = Color.white;
        _timerTxt.transform.DOScale(new Vector3(1, 1, 1), 0);


        yield return new WaitUntil(() => UIManager.Instance.IsClear == false);
        print(UIManager.Instance.IsClear);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        _timerTxt.DOColor(new Color(255, 0, 0, 0.5f), sec);
        _timerTxt.transform.DOScale(new Vector3(2, 2, 2), sec);

        //_timerTxt.DOFade(0.5f, 0);
        print("타이머 들어감");
        yield return new WaitForSeconds(0.2f);
        //UIManager.Instance.IsClear = false;
        while (_playerAttack.IsDead == false)
        {
            sec -= Time.deltaTime;
            _timerTxt.text = string.Format("{0:N2}", sec);

            if (sec <= 0)
            {
                sec = 0;
                _player.Damaged(1);
            }

            yield return new WaitForSecondsRealtime(Time.deltaTime);
            if (EnemyManager.Instance.enemyList.Count == 0)
            {
                print("타이머 나가기");
                break;
            }


        }
    }
}
