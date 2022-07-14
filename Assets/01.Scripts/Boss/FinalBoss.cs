using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinalBoss : Enemy
{
    [SerializeField] private Transform _playerTrm;

    private Animator _anim;
    private bool _isBossDie = false;
    private Vector2 _attackPos = Vector2.zero;
    private float _rotate = 90f;

    private void OnEnable()
    {
        Debug.Log("start");

        _anim = GetComponent<Animator>();
    }

    public void OnActive()
    {
        StartCoroutine(PatternCoroutine());
        StartCoroutine(CircleTarget());
    }

    IEnumerator CircleTarget()
    {
        while (!_isBossDie)
        {
            yield return new WaitUntil(() => EnemyManager.Instance.enemyList.Count == 0);
            StageManager.Instance.BossEnemySpawn();
        }
    }

    IEnumerator PatternCoroutine()
    {
        while (!_isBossDie)
        {
            _attackPos = _playerTrm.position;
            WarningMark warning = PoolManager.Instance.Pop("WarningMark") as WarningMark;
            warning.transform.position = _attackPos;
            warning.transform.rotation = Quaternion.identity;
            yield return new WaitForSecondsRealtime(1f);
            PoolManager.Instance.Push(warning.GetComponent<PoolableMono>());
            _anim.SetTrigger("IsDash");
            float angle = Mathf.Atan2(transform.position.y - _attackPos.y, transform.position.x - _attackPos.x) * Mathf.Rad2Deg + _rotate;
            transform.eulerAngles = new Vector3(0, 0, angle);
            transform.DOMove(_attackPos, 0.5f);
            yield return new WaitForSecondsRealtime(1f);
            Collider2D hit = Physics2D.OverlapCircle(_attackPos, 1);
            if (hit)
            {
                if (hit.transform.gameObject != null)
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        hit.transform.GetComponent<IDamaged>().Damaged(1);
                    }
                }
            }
        }
    }
}
