using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;
    float _damage = 1f;
    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    float speed = 0.05f;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    bool isDead = false;
    bool isLeft = true;
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
    [SerializeField] private GameObject _afterEffect1;
    [SerializeField] private GameObject _afterEffect2;

    [SerializeField] private GameObject _blink;
    [SerializeField] private GameObject _hitSpace;

    [SerializeField] private float _distance = 1f;

    [SerializeField] private LayerMask _enemyLayer;

    private BoxCollider2D _collider;
    private Vector2 _mousePos;

    float rotate = 180f;
    public float Rotate
    {
        get { return rotate; }
        set { rotate = value; }
    }


    private void Awake()
    {
    }
    void Start()
    {

        _collider = GetComponent<BoxCollider2D>();
        Sequence seq = DOTween.Sequence();
        
        seq.Append(transform.DOMoveX(-8.21f, 1.5f));
        seq.OnComplete(() =>
        {
            print("dlsdl");
            isAttack = false;
        });

        transform.position = new Vector2(-10, -2.16f);
        

        anim = GetComponent<Animator>();
       //_enemyList = GameObject.Find("GameManager").GetComponent<EnemyList>();
    }

    void Update()
    {
        #region AttackSpace
        if(EnemyManager.Instance.enemyList.Count != 0)
        {
            _hitSpace.SetActive(true);
        }
        else
        {
            _hitSpace.SetActive(false);
        }
        #endregion
        if (isAttack == false)
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }

        if (Input.GetMouseButtonDown(0) && UIManager.Instance.IsClear == false)
        {
            if(EnemyManager.Instance.enemyList.Count == 0 && !StageManager.Instance.IsStageUp)
            {
                Sequence sq = DOTween.Sequence();
                StageManager.Instance.IsStageUp = true;
                sq.Append(transform.localScale.x > 0 ? transform.DOMoveX(10, 1.5f) : transform.DOMoveX(-10, 1.5f));
                sq.OnComplete(()=>
                {
                    isLeft = !isLeft;
                    transform.localScale = new Vector2(transform.localScale.x * -1, 1);
                    rotate = isLeft ? 180 : 360;
                    transform.position = new Vector2(transform.position.x, transform.position.y + 7);
                    StageManager.Instance.CurrentStageNum += 1;

                    StageManager.Instance.StageUp(StageManager.Instance.CurrentStageNum);
                    StageManager.Instance.StageStart(StageManager.Instance.CurrentStageNum);

                    transform.DOMoveX(transform.localScale.x > 0 ? -8.21f : 8.21f, 1.5f);

                    StageManager.Instance.IsStageUp = false;
                });
            }

            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 


            RaycastHit2D hit;

            hit = Physics2D.Raycast(_mousePos, Vector3.forward, _distance);
            Debug.DrawRay(_mousePos, Vector3.forward, Color.yellow, 0.5f);

            if (hit && isDead == false)
            {
                if(hit.transform.gameObject != null)
                {
                    if (hit.transform.position == EnemyManager.Instance.enemyList[0].transform.position && hit.transform.GetComponent<PoolableMono>() == true && !isAttack)
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
                            isAttack = false;
                            StopCoroutine(AfterEffect());
                        });

                        if(EnemyManager.Instance.enemyList[0].transform.CompareTag("Enemy"))
                        {
                            SoundManager.Instance.SFXPlay(_killAudioClip);
                            EnemyManager.Instance.EnemyDie(EnemyManager.Instance.enemyList[0]);
                        }
                        if (EnemyManager.Instance.enemyList[0].transform.CompareTag("Boss"))
                        {
                            SoundManager.Instance.SFXPlay(_killAudioClip);
                            //hit.transform.GetComponent<IDamaged>().Damaged(1);
                        }
                    }
                }
                else
                {
                    return;
                };
            }
            else
            {
                PlayerDie();
                /*if(EnemyManager.Instance.enemyList.Count != 0 && isDead == false)
                {
                    PlayerDamaged player = FindObjectOfType<PlayerDamaged>();
                    print("asd");
                    player.Damaged(1);
                    isDead = true;
                }*/
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            _isDodge = true;
        }
    }
    
    public void PlayerDie()
    {
        if (EnemyManager.Instance.enemyList.Count != 0 && isDead == false  && isAttack == false)
        {
            PlayerDamaged player = FindObjectOfType<PlayerDamaged>();
            print("플레이어 죽음");
            player.Damaged(1);
            isDead = true;
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

            yield return new WaitForSeconds(0.01f);
        }
    }
}
