using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour, IDamaged
{
    [SerializeField] private float _playerHp = 3;

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
        //���ϸ��̼� ����

        //Die Panel �ö���� �ڵ�

        //��ư ������ �Ѿ�� TimeScale ����

        //��ŸƮ ȭ������ �̵�

        yield return new WaitForSecondsRealtime(5);
    }
}
