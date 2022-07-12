using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;
using DG.Tweening;

public class Boss : Enemy
{
    public enum State
    {
        Init,
        Idle,
        Pattern1,
        Pattern2,
        Pattern3,
        Death
    }

    private Dictionary<string, int> diction = new Dictionary<string, int>();
    private int num, randomNum;

    protected StateMachine<State> _fsm;
    protected Transform _playerTrm;
    protected Vector2 _initPos;

    private void Awake()
    {
        _fsm = new StateMachine<State>(this);
        _playerTrm = GameObject.Find("Player").transform;
        _initPos = transform.position;
    }

    protected void StateChange()
    {
        num = Random.Range(1, 4);
        //Invoke("StateChange", 2f);

        if (diction.ContainsKey("1") && diction.ContainsKey("2") && diction.ContainsKey("3"))
        {
            diction.Clear();
        }
        if (!diction.ContainsKey(num.ToString()))
        {
            randomNum = num;
            diction.Add(num.ToString(), num);
        }
        else
        {
            Invoke("StateChange", 2f);
            return;
        }

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
        Invoke("StateChange", 2f);
    }
}
