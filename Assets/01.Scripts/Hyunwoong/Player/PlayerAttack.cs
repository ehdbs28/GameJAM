using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;
    private Rigidbody2D _rigid;

    Light2D _light;
    float _damage = 1f;
    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    float speed = 0.5f;

    public float Speed
    {
        get { return speed; }
        set { speed = Mathf.Clamp(speed, 0.01f, 0.5f); }
    }

    bool isDead = false;

    public bool IsDead
    {
        get => isDead;
        set => isDead = value;
    }
    bool isLeft = true;
    public bool IsLeft
    {
        get => isLeft;
        set => isLeft = value;
    }
    private bool _isDodge = false;
    public bool IsDodge
    {
        get => _isDodge;
        set => _isDodge = value;
    }

    bool isAttack = true;

    [SerializeField] private AudioClip _dashAudioClip;
    [SerializeField] private AudioClip _killAudioClip;

    public bool IsAttack
    {
        get { return isAttack; }
        set { isAttack = value; }
    }

    [SerializeField] private GameObject _afterEffect;

    [SerializeField] private GameObject blockPanel;

    [SerializeField] private GameObject _blink;
    [SerializeField] private GameObject _hitSpace;
    [SerializeField] private GameObject _hitBossSpace;

    public AudioClip clip;

    [SerializeField] private RectTransform _numberLine;

    [SerializeField] private float _distance = 3f;

    [SerializeField] private LayerMask layerMask;

    NumberLine number;   

    private BoxCollider2D _collider;
    private Vector2 _mousePos;

    float rotate = 180f;
    public float Rotate
    {
        get { return rotate; }
        set { rotate = value; }
    }

    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _rigid = GetComponent<Rigidbody2D>();

        _light = GameObject.Find("Flash").GetComponent<Light2D>();

        number = FindObjectOfType<NumberLine>();
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOMoveX(-8.21f, 1.5f));
        seq.OnComplete(() =>
        {
            isAttack = false;
        });

        transform.position = new Vector2(-10, -2.16f);


        anim = GetComponent<Animator>();
        //_enemyList = GameObject.Find("GameManager").GetComponent<EnemyList>();
    }

    public void StageClear()
    {
        Sequence sq = DOTween.Sequence();

        StageManager.Instance.IsStageUp = isDead ? true : false;
        StageManager.Instance.CurrentStageNum += 1;
        StageManager.Instance.StageUp(StageManager.Instance.CurrentStageNum);

        sq.Append(transform.localScale.x > 0 ? transform.DOMoveX(10, 1.5f) : transform.DOMoveX(-10, 1.5f));
        sq.OnComplete(() =>
        {
            isLeft = !isLeft;
            transform.localScale = new Vector2(transform.localScale.x * -1, 1);
            rotate = isLeft ? 180 : 360;
            transform.position = new Vector2(transform.position.x, transform.position.y + 7);
            StageManager.Instance.StageStart(StageManager.Instance.CurrentStageNum);

            transform.DOMoveX(transform.localScale.x > 0 ? -8.21f : 8.21f, 1.5f);

            transform.rotation = Quaternion.identity;

            StageManager.Instance.IsStageUp = false;

        });
    }

    void Update()
    {
        #region AttackSpace
        if (EnemyManager.Instance.enemyList.Count != 0)
        {
            _hitSpace.SetActive(true);
        }
        else
        {
            _hitSpace.SetActive(false);
        }

        if (EnemyManager.Instance.bossList.Count != 0)
        {
            _hitBossSpace.SetActive(true);
        }
        else
        {
            _hitBossSpace.SetActive(false);
        }
        #endregion
        if (isAttack == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetMouseButtonDown(0) && UIManager.Instance.IsClear == false)
        {
            UIManager.Instance.IsClear = EnemyManager.Instance.enemyList.Count == 0 && EnemyManager.Instance.bossList.Count == 0 && !isAttack ? true : false;

            if(EnemyManager.Instance.bossList.Count == 0 && StageManager.Instance.CurrentStageNum == 11)
            {
                SceneManager.LoadScene("Ending");
            }

            if (EnemyManager.Instance.enemyList.Count == 0 && EnemyManager.Instance.bossList.Count == 0 && !StageManager.Instance.IsStageUp && UIManager.Instance.IsClear == true)
            {
                StageClear();
            }

            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            RaycastHit2D hit;

            hit = Physics2D.Raycast(_mousePos, Vector3.forward, _distance);
            Debug.DrawRay(_mousePos, Vector3.forward, Color.yellow, 0.5f);

            if (hit && isDead == false)
            {
                FlashManager.Instance.Flash(_isDodge ? Color.green : Color.white);
                if (hit.transform.gameObject != null)
                {
                    if (EnemyManager.Instance.enemyList.Count != 0 && UIManager.Instance.IsClear == false)
                    {
                        if (hit.transform.gameObject.tag == "HitSpace" && hit.transform.GetComponent<PoolableMono>() == true && !isAttack)
                        {
                            Sequence seq = DOTween.Sequence();
                            isAttack = true;
                            SoundManager.Instance.SFXPlay(_dashAudioClip);
                            anim.SetTrigger("IsAttack");
                            GameObject Blink = Instantiate(_blink);
                            StartCoroutine(AfterEffect());
                            Blink.transform.position = hit.transform.position;
                            Vector2 inputVec = _mousePos;
                            float angle = Mathf.Atan2(transform.position.y - inputVec.y, transform.position.x - inputVec.x) * Mathf.Rad2Deg + rotate;
                            transform.eulerAngles = new Vector3(0, 0, angle);


                            seq.Append(transform.DOMove(hit.transform.position, speed));

                            seq.OnComplete(() =>
                            {
                                StopCoroutine(AfterEffect());
                            });

                            if (EnemyManager.Instance.enemyList[0].transform.CompareTag("Enemy"))
                            {
                                if (EnemyManager.Instance.enemyList[0].name == "Enemy_3")
                                {
                                    EnemyManager.Instance.enemyList[0].GetComponent<Animator>().Play("Enemy3");
                                }

                                isAttack = false;
                                SoundManager.Instance.SFXPlay(_killAudioClip);
                                EnemyManager.Instance.EnemyDie(EnemyManager.Instance.enemyList[0]);
                            }
                        }
                    }
                    if (EnemyManager.Instance.bossList.Count != 0)
                    {
                        if (hit.transform.CompareTag("HitBossSpace") && hit.transform.GetComponent<PoolableMono>() == true && !isAttack)
                        {
                            Sequence seq = DOTween.Sequence();
                            isAttack = true; 
                            SoundManager.Instance.SFXPlay(_dashAudioClip);
                            anim.SetTrigger("IsAttack");
                            GameObject Blink = Instantiate(_blink);
                            StartCoroutine(AfterEffect());
                            Blink.transform.position = hit.transform.position;
                            Vector2 inputVec = _mousePos;
                            float angle = Mathf.Atan2(transform.position.y - inputVec.y, transform.position.x - inputVec.x) * Mathf.Rad2Deg + rotate;
                            transform.eulerAngles = new Vector3(0, 0, angle);


                            seq.Append(transform.DOMove(hit.transform.position, speed));

                            seq.OnComplete(() =>
                            {
                                StopCoroutine(AfterEffect());
                            });

                            if (EnemyManager.Instance.bossList[0].transform.CompareTag("Boss"))
                            {
                                isAttack = false;
                                SoundManager.Instance.SFXPlay(_killAudioClip);
                                EnemyManager.Instance.bossList[0].transform.GetComponent<IDamaged>().Damaged(1);
                            }
                        }
                    }
                }
            }
            else
            {
                PlayerDie();
            }
        }
        if (Input.GetMouseButtonUp(1) && !_isDodge)
        {
            _isDodge = true;
            Smoke smoke = PoolManager.Instance.Pop("Smoke") as Smoke;
            smoke.transform.position = transform.position;
            anim.SetTrigger("IsDodge");
            StartCoroutine(DodgeCoroutine());
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _numberLine.DOAnchorPosX(100, 1f);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            _numberLine.DOAnchorPosX(-140, 1f);
        }
    }

    IEnumerator DodgeCoroutine()
    {
        _rigid.AddForce(transform.localScale.x > 0 ? new Vector2(-7, -7) : new Vector2(7, 7), ForceMode2D.Impulse);
        Time.timeScale = 0.8f;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        DashFx dashFx = PoolManager.Instance.Pop("DashFx") as DashFx;
        dashFx.transform.position = transform.localScale.x > 0 ? new Vector2(transform.position.x - 1, transform.position.y) : new Vector2(transform.position.x + 1, transform.position.y);
        dashFx.transform.localScale = transform.localScale.x > 0 ? new Vector3(2, 2, 2) : new Vector3(-2, 2, 2);
        Time.timeScale = 1;
    }

    public void OnDodge() //Animation Event
    {
        _isDodge = false;
        DashFx dashFx = PoolManager.Instance.Pop("DashFx") as DashFx;
        dashFx.transform.position = transform.localScale.x > 0 ? new Vector2(transform.position.x - 1, transform.position.y) : new Vector2(transform.position.x + 1, transform.position.y);
        dashFx.transform.localScale = transform.localScale.x > 0 ? new Vector3(2, 2, 2) : new Vector3(-2, 2, 2);
        Time.timeScale = 1;
    }

    public void PlayerDie()
    {
        if (EnemyManager.Instance.enemyList.Count != 0 && isDead == false && isAttack == false)
        {
            PlayerDamaged player = FindObjectOfType<PlayerDamaged>();
            player.Damaged(1);

            FlashManager.Instance.Flash(Color.red);
        }
    }

    IEnumerator AfterEffect()
    {
        while (isAttack)
        {
            GameObject Effect = Instantiate(_afterEffect);
            Effect.transform.position = transform.position;
            Vector2 inputVec = _mousePos;
            float angle = Mathf.Atan2(transform.position.y - inputVec.y, transform.position.x - inputVec.x) * Mathf.Rad2Deg + rotate;
            Effect.transform.eulerAngles = new Vector3(0, 0, angle);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
