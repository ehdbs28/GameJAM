using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theme2Boss : Boss
{
    [SerializeField] private GameObject _warningPrefab_1;

    private Animator _theme2BossAnim;

    private void Start()
    {
        _theme2BossAnim = GetComponent<Animator>();
    }

    [ContextMenu("pattern1")]
    private void Pattern1_Enter()
    {
        Debug.Log("패턴 원");
        _theme2BossAnim.SetTrigger("BossAttack1");
        DartAttack();
    }

    void DartAttack()
    {
        StartCoroutine(DartCo());
    }

    IEnumerator DartCo()
    {
        GameObject warning = Instantiate(_warningPrefab_1);
        warning.transform.localScale = new Vector3(4, 3);
        warning.transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y - 1.5f, 0);
        yield return new WaitForSeconds(1f);
        Destroy(warning);
    }

    [ContextMenu("pattern2")]
    private void Pattern2_Enter()
    {
        Debug.Log("패턴 투");
        _theme2BossAnim.SetTrigger("BossAttack2");
        TurnAttack();
    }

    void TurnAttack()
    {
        StartCoroutine(TurnCo());
    }

    IEnumerator TurnCo()
    {
        GameObject warning = Instantiate(_warningPrefab_1);
        warning.transform.localScale = new Vector3(2, 4);
        warning.transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y - 1.5f, 0);
        yield return new WaitForSeconds(1f);
        Destroy(warning);
    }

    [ContextMenu("pattern3")]
    private void Pattern3_Enter()
    {
        Debug.Log("패턴 쓰리");
        _theme2BossAnim.SetTrigger("BossAttack3");
        WhipAttack();
    }

    void WhipAttack()
    {
        StartCoroutine(WhipCo());
    }

    IEnumerator WhipCo()
    {
        GameObject warning = Instantiate(_warningPrefab_1);
        warning.transform.localScale = new Vector3(10, 2);
        warning.transform.position = new Vector3(transform.position.x - 1f, transform.position.y - 2.5f, 0);
        yield return new WaitForSeconds(1f);
        Destroy(warning);
    }
}
