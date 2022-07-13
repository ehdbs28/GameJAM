using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour, IDamaged
{
    private float _tryCount = 3;
    private PlayerAttack _playerAttack;

    float _playerHp = 1;

    Animator anim;
    public float PlayerHp
    {
        get { return _playerHp; }
        set { _playerHp = value; }
    }

    private void Start()
    {
        _playerAttack = GetComponent<PlayerAttack>();
        anim = GetComponent<Animator>();
    }

    public void Damaged(float damage)
    {
        if (!_playerAttack.IsDodge)
        {
            _playerHp -= damage;

            if (_playerHp <= 0&&_playerAttack.IsDead == false)
            {
                _playerAttack.IsDead = true;
                OnDie();
            }
        }
        else return;
    }

    private void OnDie()
    {
        StartCoroutine(DieCo());
    }

    IEnumerator DieCo()
    {
        anim.SetTrigger("IsDeath");

        //Die Panel 올라오는 코드

        //버튼 누르면 넘어가고 TimeScale 조정

        //스타트 화면으로 이동

        yield return new WaitForSecondsRealtime(5);
    }
}
