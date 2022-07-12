using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public static GravityController Instance = null;

    private Rigidbody2D _playerRigid;

    private void Start()
    {
        _playerRigid = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    public void ModityGravityScale(float scale, float endTime)
    {
        StartCoroutine(GravityCoroutine(scale, endTime));
    }

    IEnumerator GravityCoroutine(float scale, float endTime)
    {
        _playerRigid.velocity = Vector2.zero;
        _playerRigid.gravityScale = scale;
        yield return new WaitForSecondsRealtime(endTime);
        _playerRigid.gravityScale = 1;
    }
}
