using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _damage = 5f;

    [SerializeField] private float _distance = 1f;

    [SerializeField] private LayerMask _enemyLayer;

    private BoxCollider2D _collider;
    private Vector2 _mousePos;

    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();

        transform.position = new Vector2(-10, -2.16f);
        transform.DOMoveX(-8.21f, 1.5f);
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
                    transform.localScale = new Vector2(transform.localScale.x * -1, 1);
                    transform.position = new Vector2(transform.position.x, transform.position.y + 7);
                    StageManager.Instance.CurrentStageNum += 1;

                    StageManager.Instance.StageUp(StageManager.Instance.CurrentStageNum);
                    StageManager.Instance.StageStart(StageManager.Instance.CurrentStageNum);

                    transform.DOMoveX(transform.localScale.x > 0 ? -8.21f : 8.21f, 1.5f);

                    StageManager.Instance.IsStageUp = false;
                });
            }

            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit;

            hit = Physics2D.Raycast(_mousePos, Vector3.forward, _distance);
            Debug.DrawRay(_mousePos, Vector3.forward, Color.yellow, 0.5f);

            if(hit)
            {
                if(hit.transform.gameObject != null)
                {
                    if (hit.transform.gameObject == EnemyManager.Instance.enemyList[0].gameObject)
                    {
                        transform.DOMove(hit.transform.position, 0.05f);
                        EnemyManager.Instance.EnemyDie(hit.transform.GetComponent<PoolableMono>());
                    }
                }
                else return;
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
        }
    }        
}
