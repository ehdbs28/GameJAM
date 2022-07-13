using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinalBoss : MonoBehaviour
{
    [SerializeField] private Transform _playerTrm;

    private Animator _anim;
    private bool _isBossDie = false;
    private Vector2 _attackPos = Vector2.zero;

    private void OnEnable()
    {
        _anim = GetComponent<Animator>();
        StartCoroutine(PatternCoroutine());
    }

    IEnumerator PatternCoroutine()
    {
        while (_isBossDie)
        {
            _attackPos = _playerTrm.position;
            WarningMark warning = PoolManager.Instance.Pop("WarningMark") as WarningMark;
            warning.transform.position = _attackPos;
            warning.transform.rotation = Quaternion.identity;
            yield return new WaitForSecondsRealtime(1f);
            PoolManager.Instance.Push(warning);
            transform.DOMove(_attackPos, 0.5f);
        }
    }
}
