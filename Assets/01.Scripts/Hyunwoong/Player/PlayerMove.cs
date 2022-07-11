using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// 플레이어 움직임 함수
    /// </summary>
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2 (h, 0) * speed;
    }
}
