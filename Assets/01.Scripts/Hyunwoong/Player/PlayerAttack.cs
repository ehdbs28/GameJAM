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

    bool isDead = false;
    bool isLeft = true;

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

    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();

        transform.position = new Vector2(-10, -2.16f);
        transform.DOMoveX(-8.21f, 1.5f);

        anim = GetComponent<Animator>();
       //_enemyList = GameObject.Find("GameManager").GetComponent<EnemyList>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
                    if (hit.transform.position == EnemyManager.Instance.enemyList[0].transform.position && hit.transform.GetComponent<PoolableMono>() == true)//EnemyManager.Instance.enemyList[0].gameObject)
                    {
                        anim.SetTrigger("IsAttack");
                        GameObject Blink = Instantiate(_blink);
                        Blink.transform.position = hit.transform.position;
                        Vector2 inputVec = _mousePos;
                        float angle = Mathf.Atan2(transform.position.y - inputVec.y, transform.position.x - inputVec.x) * Mathf.Rad2Deg + rotate;
                        transform.eulerAngles = new Vector3(0, 0, angle);

                        transform.DOMove(hit.transform.position, 0.05f);
                        EnemyManager.Instance.EnemyDie(EnemyManager.Instance.enemyList[0]);
                        //EnemyManager.Instance.EnemyDie(hit.transform.GetComponent<PoolableMono>());
                    }
                }
                else
                {
                    return;
                };
            }
            else
            {
                if(EnemyManager.Instance.enemyList.Count != 0 && isDead == false)
                {
                    PlayerDamaged player = FindObjectOfType<PlayerDamaged>();
                    print("asd");
                    player.Damaged(1);
                    isDead = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            Bounds bounds = _collider.bounds;
            //Vector2 attackPos = new Vector2(bounds.max.x, bounds.center.y);
            Vector2 attackPos = transform.localScale.x > 0 ? new Vector2(bounds.max.x, bounds.center.y) : new Vector2(bounds.min.x, bounds.center.y);

            Collider2D hit;

            hit = Physics2D.OverlapCircle(attackPos, _distance);

            if (hit)
            {
                hit.GetComponent<IDamaged>().Damaged(_damage);
            }
            else return;
        }
    }        
}
