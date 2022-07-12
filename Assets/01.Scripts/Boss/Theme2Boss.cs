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

    private void Pattern1_Enter()
    {
        Debug.Log("패턴 원");
        _theme2BossAnim.SetTrigger("Theme2BossAttack1");
        DartAttack();
    }

    void DartAttack()
    {
        StartCoroutine(DartCo());
    }

    IEnumerator DartCo()
    {
        GameObject warning = Instantiate(_warningPrefab_1);
        warning.transform.localScale = new Vector3(4, 1);
        warning.transform.position = new Vector3(transform.position.x + 1, 0, 0);
        yield return new WaitForSeconds(0.3f);
        Destroy(warning);
    }

    private void Pattern2_Enter()
    {
        Debug.Log("패턴 투");
        _theme2BossAnim.SetTrigger("Theme2BossAttack2");
        TurnAttack();
    }

    void TurnAttack()
    {
        StartCoroutine(TurnCo());
    }

    IEnumerator TurnCo()
    {
        GameObject warning = Instantiate(_warningPrefab_1);
        warning.transform.position = transform.position;
        yield return new WaitForSeconds(0.3f);
        Destroy(warning);
    }

    private void Pattern3_Enter()
    {
        Debug.Log("패턴 쓰리");
        _theme2BossAnim.SetTrigger("Theme2BossAttack3");
        WhipAttack();
    }

    void WhipAttack()
    {
        StartCoroutine(WhipCo());
    }

    IEnumerator WhipCo()
    {
        GameObject warning = Instantiate(_warningPrefab_1);
        warning.transform.position = transform.position;
        yield return new WaitForSeconds(0.3f);
        Destroy(warning);
    }
}
