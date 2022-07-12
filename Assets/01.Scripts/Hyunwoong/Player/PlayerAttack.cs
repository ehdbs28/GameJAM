using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAttack : MonoBehaviour
{
    float _damage = 1f;
    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }


    [SerializeField] private float _distance = 1f;

    [SerializeField] private LayerMask _enemyLayer;

    private BoxCollider2D _collider;
    private Vector2 _mousePos;

    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
       //_enemyList = GameObject.Find("GameManager").GetComponent<EnemyList>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
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
            else return;
        }
    }        
}
