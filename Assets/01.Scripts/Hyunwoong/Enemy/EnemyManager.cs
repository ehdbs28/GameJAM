using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance = null;

    public List<Enemy> enemyList = new List<Enemy>();

    public void EnemyDie(PoolableMono enemy)
    {
        GravityController.Instance.ModityGravityScale(0.3f, 0.3f);
        CameraManager.Instance.ShakeCam(4f, 0.3f);
        TimeControlManager.Instance.ModifyTimeScale(0.1f, 0.01f, () =>
        {
            TimeControlManager.Instance.ModifyTimeScale(1f, 5f);
        });
        Debug.Log("´ÙÀÌ");

        PoolManager.Instance.Push(enemy);
        enemyList.RemoveAt(0);
    }

    public void SpawnEnemy(List<Vector2> transforms)
    {
        StartCoroutine(SpawnEnemyCoroutine(transforms));
    }

    IEnumerator SpawnEnemyCoroutine(List<Vector2> transforms)
    {
        foreach(Vector2 enemyPos in transforms)
        {
            Enemy enemy = PoolManager.Instance.Pop("Enemy_1") as Enemy;
            enemyList.Add(enemy);   
            enemy.transform.position = enemyPos;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
