using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour, IDamaged
{
    private float _tryCount = 3;
    private PlayerAttack _playerAttack;

    float _playerHp = 1;

    Animator anim;
    private int index = 3;

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

            if (_playerHp <= 0 && _playerAttack.IsDead == false)
            {
                anim.Play("PlayerDeath");
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

        if (index > 0)
        {
            StageManager.Instance.StageUp(StageManager.Instance.CurrentStageNum);
            StageManager.Instance.StageStart(StageManager.Instance.CurrentStageNum);
            index--;
        }
        else
        {
            print("게임오버");
        }

        yield return new WaitForSecondsRealtime(5);
    }
}
