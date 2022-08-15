using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;
using DG.Tweening;

public class Theme1Boss : Boss
{
    [SerializeField] private List<Vector2> _breakTileVec = new List<Vector2>();
    [SerializeField] private GameObject _warning;
    [SerializeField] private GameObject _circleWarning;

    [SerializeField] private AudioClip _sweepClip;
    [SerializeField] private AudioClip _slamClip;
    [SerializeField] private AudioClip _electroClip;

    private Animator _bossAnim;

    private float sec = 2f;

    public float Sec
    {
        get => sec;
        set => sec = value;
    }

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
        Invoke("StateChange", sec);
    }

    private void Init_Enter()
    {
        Debug.Log("Fsm준비됨");
        _bossAnim = GetComponent<Animator>();
    }

    private void Pattern1_Enter()
    {
        Debug.Log("패턴 원");
        StartCoroutine(SweepAttack());
        _bossAnim.SetTrigger("SweepAttack");
        SoundManager.Instance.SFXPlay(_sweepClip);
        SoundManager.Instance.SFXPlay(_slamClip);
    }

    private void Pattern2_Enter()
    {
        Debug.Log("패턴 투");
        StartCoroutine(SlamAttack());
        _bossAnim.SetTrigger("SpinSlamAttack");
        SoundManager.Instance.SFXPlay(_electroClip);
    }

    private void Pattern3_Enter()
    {
        Debug.Log("패턴 쓰리");
        StartCoroutine(SlamAttack());
        _bossAnim.SetTrigger("SlamAttack");
        SoundManager.Instance.SFXPlay(_electroClip);
    }

    private void Death_Enter()
    {
        CancelInvoke();

        Time.timeScale = 1;

        GravityController.Instance.ModityGravityScale(0.3f, 0.3f);
        CameraManager.Instance.ShakeCam(2f, 0.3f);
        TimeControlManager.Instance.ModifyTimeScale(0.1f, 0.01f, () =>
        {
            TimeControlManager.Instance.ModifyTimeScale(1f, 2f);
        });

        _bossAnim.SetTrigger("IsDie");
        EnemyManager.Instance.bossList.RemoveAt(0);
    }

    public void Death()
    {
        CameraManager.Instance.SetToMainVCam();
    }

    IEnumerator SweepAttack()
    {
        GameObject warning = Instantiate(_warning, transform);
        warning.transform.localScale = new Vector2(12, 1);
        yield return new WaitForSeconds(0.7f);
        Destroy(warning);

        RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(12, 1), 0, Vector2.right, 20);

        if (hit)
        {
            if(hit.transform.gameObject != null)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    Debug.Log("1");
                    hit.transform.GetComponent<IDamaged>().Damaged(1);
                }
            }
        }
    }

    IEnumerator SlamAttack()
    {
        GameObject circleWarning = Instantiate(_circleWarning);
        circleWarning.transform.position = new Vector2(transform.position.x, transform.position.y);
        circleWarning.transform.localScale = new Vector2(3, 3);
        yield return new WaitForSeconds(0.7f);
        Destroy(circleWarning);
        Collider2D hit = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 0.5f);
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
