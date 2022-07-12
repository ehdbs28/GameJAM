using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;
using DG.Tweening;

public class Boss : MonoBehaviour
{
    public enum State
    {
        Idle,
        Pattern1,
        Pattern2,
        Pattern3,
        Death
    }

    protected StateMachine<State> _fsm;
    protected Transform _playerTrm;
    protected Vector2 _initPos;

    private void Start()
    {
        _fsm = new StateMachine<State>(this);
        _playerTrm = GameObject.Find("Player").transform;
        _initPos = transform.position;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        DOTween.KillAll();
        transform.position = _initPos;
    }

    protected void StateChange()
    {
        StartCoroutine(StateChangeCoroutine());
    }

    IEnumerator StateChangeCoroutine()
    {
        Dictionary<string, int> diction = new Dictionary<string, int>();
        int num, randomNum;
        yield return new WaitForSeconds(2f);
        while (true)
        {
            num = Random.Range(1, 4);

            if (diction.ContainsKey("1") && diction.ContainsKey("2") && diction.ContainsKey("3"))
            {
                diction.Clear();
            }
            if (diction.ContainsKey(num.ToString()))
            {
                randomNum = num;
                diction.Add(num.ToString(), num);
            }
            else continue;

            if (randomNum == 1)
            {
                _fsm.ChangeState(State.Pattern1);
            }
            if (randomNum == 2)
            {
                _fsm.ChangeState(State.Pattern2);
            }
            if (randomNum == 3)
            {
                _fsm.ChangeState(State.Pattern3);
            }
        }
    }
}
