using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamaged : MonoBehaviour, IDamaged
{
    private float _bossHp = 9f;

    public void Damaged(float damage)
    {
        _bossHp -= damage;
        if (_bossHp <= 0)
        {
            EnemyManager.Instance.EnemyDie(EnemyManager.Instance.enemyList[0]);
        }
    }
}
