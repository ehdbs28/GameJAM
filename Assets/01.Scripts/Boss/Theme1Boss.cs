using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;
using DG.Tweening;

public class Theme1Boss : Boss
{
    [SerializeField] private List<Vector2> _breakTileVec = new List<Vector2>();

    private Animator _bossAnim;

    private void OnEnable()
    {
        transform.DOMoveX(0, 2f);
        _fsm.ChangeState(State.Init);
    }

    private void OnDisable()
    {
        //StopAllCoroutines();
        DOTween.KillAll();
        transform.position = _initPos;
    }

    public void OnActive()
    {
        Invoke("StateChange", 2f);
    }

    private void Init_Enter()
    {
        Debug.Log("Fsm준비됨");
        _bossAnim = GetComponent<Animator>();
    }

    private void Pattern1_Enter()
    {
        Debug.Log("패턴 원");
        _bossAnim.SetTrigger("SweepAttack");
    }

    private void Pattern2_Enter()
    {
        Debug.Log("패턴 투");
        _bossAnim.SetTrigger("SpinSlamAttack");
    }

    private void Pattern3_Enter()
    {
        Debug.Log("패턴 쓰리");
        _bossAnim.SetTrigger("SlamAttack");
    }

    IEnumerator SweepAttack()
    {
        yield return new WaitForSeconds(0.5f);
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(1, 1), 0, Vector2.right, 5);

        if (hit)
        {
            if(hit.transform.gameObject != null)
            {

            }
        }
    }
}
