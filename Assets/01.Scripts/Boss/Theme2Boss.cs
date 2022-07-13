using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Theme2Boss : Boss
{
    [SerializeField] private GameObject _warningPrefab_1;

    private Animator _theme2BossAnim;

    private void OnEnable()
    {
        transform.DOMoveX(0, 2f);
        _fsm.ChangeState(State.Init);
    }

    private void OnDisable()
    {
        DOTween.KillAll();
        transform.position = _initPos;
    }

    public void OnActive()
    {
        Invoke("StateChange", 2f);
    }

    private void Init_Enter()
    {
        Debug.Log("2BossFsm준비됨");
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
        RaycastHit2D hit = Physics2D.BoxCast(new Vector3(transform.position.x + 1.5f, transform.position.y - 1.5f, 0), new Vector2(4, 3), 0, Vector2.right, 20);

        if (hit)
        {
            if (hit.transform.gameObject != null)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    Debug.Log("1");
                    hit.transform.GetComponent<IDamaged>().Damaged(1);
                }
            }
        }
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
        RaycastHit2D hit = Physics2D.BoxCast(new Vector3(transform.position.x + 1.5f, transform.position.y - 1.5f, 0), new Vector2(2, 4), 0, Vector2.right, 20) ;

        if (hit)
        {
            if (hit.transform.gameObject != null)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    Debug.Log("1");
                    hit.transform.GetComponent<IDamaged>().Damaged(1);
                }
            }
        }
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

    private void Death_Enter()
    {
        CancelInvoke();

        Time.timeScale = 1;

        GravityController.Instance.ModityGravityScale(0.3f, 0.3f);
        CameraManager.Instance.ShakeCam(2f, 0.3f);
        TimeControlManager.Instance.ModifyTimeScale(0.1f, 0.01f, () =>
        {
            TimeControlManager.Instance.ModifyTimeScale(1f, 0.1f);
        });

        _theme2BossAnim.SetTrigger("IsDie");
        EnemyManager.Instance.enemyList.RemoveAt(0);
    }

    void WhipAttack()
    {
        StartCoroutine(WhipCo());
    }

    IEnumerator WhipCo()
    {
        RaycastHit2D hit = Physics2D.BoxCast(new Vector3(transform.position.x -1f, transform.position.y - 2.5f, 0), new Vector2(10, 2), 0, Vector2.right, 20);

        if (hit)
        {
            if (hit.transform.gameObject != null)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    Debug.Log("1");
                    hit.transform.GetComponent<IDamaged>().Damaged(1);
                }
            }
        }
        GameObject warning = Instantiate(_warningPrefab_1);
        warning.transform.localScale = new Vector3(10, 2);
        warning.transform.position = new Vector3(transform.position.x - 1f, transform.position.y - 2.5f, 0);
        yield return new WaitForSeconds(1f);
        Destroy(warning);
    }
}
