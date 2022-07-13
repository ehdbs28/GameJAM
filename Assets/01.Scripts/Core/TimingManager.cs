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
        StopAllCoroutines();
    }

    public void Timer(float sec)
    {
        StartCoroutine(TimeCoroutine(sec));
    }

    int i = 0;

    IEnumerator TimeCoroutine(float sec)
    {
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        while (_playerAttack.IsDead == false && UIManager.Instance.IsClear == false)
        {
            if(EnemyManager.Instance.enemyList.Count == 0)
            {
                break;
            }

            sec -= 0.1f;
            _timerTxt.text = $"{(int)sec}";
            i++;

            _timerTxt.color = new Color(255, 255 - i, 255 - i);

            if(sec <= 0)
            {
                sec = 0;
                _player.Damaged(1);
            }
            yield return new WaitForSeconds(0.1f);
            _timerTxt.text = $"{(int)sec}";

        }
    }
}
