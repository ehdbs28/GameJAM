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
    private float _rotate = 90f;

    private void OnEnable()
    {
        Debug.Log("start");

        _anim = GetComponent<Animator>();
        StartCoroutine(PatternCoroutine());
    }

    IEnumerator PatternCoroutine()
    {
        while (!_isBossDie)
        {
            _attackPos = _playerTrm.position;
            WarningMark warning = PoolManager.Instance.Pop("WarningMark") as WarningMark;
            warning.transform.position = _attackPos;
            warning.transform.rotation = Quaternion.identity;
            yield return new WaitForSecondsRealtime(0.5f);
            PoolManager.Instance.Push(warning.GetComponent<PoolableMono>());
            _anim.SetTrigger("IsDash");
            float angle = Mathf.Atan2(transform.position.y - _attackPos.y, transform.position.x - _attackPos.x) * Mathf.Rad2Deg + _rotate;
            transform.eulerAngles = new Vector3(0, 0, angle);
            transform.DOMove(_attackPos, 0.5f);
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
