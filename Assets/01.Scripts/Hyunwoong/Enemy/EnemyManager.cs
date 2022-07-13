using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Experimental.Rendering.Universal;

public class EnemyManager : MonoBehaviour
{

    Light2D _flash;
    float sec = 0.1f;

    public float Sec
    {
        get { return sec; }
        set { sec = value; }
    }

    public static EnemyManager Instance = null;

    public List<Enemy> enemyList = new List<Enemy>();
    public List<Enemy> bossList = new List<Enemy>();

    private void Start()
    {
        _flash = GameObject.Find("Flash").GetComponent<Light2D>();
    }
    public void EnemyDie(PoolableMono enemy)
    {
        Time.timeScale = 1;
        StartCoroutine(Flash());
        GravityController.Instance.ModityGravityScale(0.3f, 0.3f);
        CameraManager.Instance.ShakeCam(2f, 0.3f);
        TimeControlManager.Instance.ModifyTimeScale(0.1f, 0.01f, () =>
        {
            TimeControlManager.Instance.ModifyTimeScale(1f, sec);
        });
        Debug.Log("����");

        PoolManager.Instance.Push(enemy);
        enemyList.RemoveAt(0);
    }

    public void SpawnEnemy(List<Vector2> transforms, string name)
    {
        StartCoroutine(SpawnEnemyCoroutine(transforms, name));
    }

    IEnumerator SpawnEnemyCoroutine(List<Vector2> transforms, string name)
    {
        foreach(Vector2 enemyPos in transforms)
        {
            Enemy enemy = PoolManager.Instance.Pop(name) as Enemy;
            enemyList.Add(enemy);   
            enemy.transform.position = enemyPos;
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator Flash()
    {
        _flash.intensity = 16f;
        yield return new WaitForSeconds(0.07f);
        _flash.intensity = 0;
    }
}
