using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class BossDamaged : MonoBehaviour, IDamaged
{
    private Boss boss;
    private float _bossHp = 9f;

    private void Start()
    {
        boss = GetComponent<Boss>();
    }

    public void Damaged(float damage)
    {
        _bossHp -= damage;

        if (_bossHp <= 0)
        {
            CameraManager.Instance.SetToTheme1();

            boss._fsm.ChangeState(Boss.State.Death);
        }
    }
}
