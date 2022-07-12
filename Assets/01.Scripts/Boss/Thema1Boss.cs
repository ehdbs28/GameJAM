using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;
using DG.Tweening;

public class Thema1Boss : Boss
{
    private void OnEnable()
    {
        transform.DOMoveX(0, 7f);
        _fsm.ChangeState(State.Init);
    }

    private void OnDisable()
    {
        //StopAllCoroutines();
        DOTween.KillAll();
        transform.position = _initPos;
    }

    public void OnActive()
    {
        _isActive = true;
    }

    private void Init_Enter()
    {
        Debug.Log("Fsm�غ��");
    }

    private void Pattern1_Enter()
    {
        Debug.Log("���� ��");
    }

    private void Pattern2_Enter()
    {
        Debug.Log("���� ��");
    }

    private void Pattern3_Enter()
    {
        Debug.Log("���� ����");
    }
}
