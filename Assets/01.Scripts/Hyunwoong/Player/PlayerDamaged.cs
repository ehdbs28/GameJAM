using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour, IDamaged
{
    private float _tryCount = 3;

    float _playerHp = 1;

    Animator anim;
    public float PlayerHp
    {
        get { return _playerHp; }
        set { _playerHp = value; }
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Damaged(float damage)
    {
        _playerHp -= damage;

        if(_playerHp <= 0)
        {
            OnDie();
        }
    }

    private void OnDie()
    {
        StartCoroutine(DieCo());
    }

    IEnumerator DieCo()
    {
        anim.SetTrigger("IsDeath");

        //Die Panel �ö���� �ڵ�

        //��ư ������ �Ѿ�� TimeScale ����

        //��ŸƮ ȭ������ �̵�

        yield return new WaitForSecondsRealtime(5);
    }
}
