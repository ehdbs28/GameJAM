using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _damage = 5f;

    [SerializeField] private float _distance = 1f;
    [SerializeField] private UnityEvent OnEnemyDie;

    private BoxCollider2D _collider;
    private Vector2 _mousePos;
    private EnemyList _enemyList;

    int i = 0;
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
       //_enemyList = GameObject.Find("GameManager").GetComponent<EnemyList>();
        _enemyList = FindObjectOfType<EnemyList>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit;

            hit = Physics2D.Raycast(_mousePos, Vector3.forward, _distance);
            Debug.DrawRay(_mousePos, hit.point, Color.yellow, 0.5f);

            if (hit.transform.gameObject == _enemyList.enemyList[0].gameObject) //�̷��� Ʈ������ �� �� �ȼ��� �޾ƿ��ٵ� ...
            { 
                transform.position = hit.transform.position;

                OnEnemyDie.Invoke();
                //PoolManager.Instance.Push(hit.transform.GetComponent<PoolableMono>());
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
