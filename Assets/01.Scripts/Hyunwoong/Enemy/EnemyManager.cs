using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance = null;

    public List<Enemy> enemyList = new List<Enemy>();

    private int _indexNum = 0;

    public void EnemyDie()
    {
        GravityController.Instance.ModityGravityScale(0.3f, 0.3f);
        CameraManager.Instance.ShakeCam(4f, 0.3f);
        TimeControlManager.Instance.ModifyTimeScale(0.1f, 0.01f, () =>
        {
            TimeControlManager.Instance.ModifyTimeScale(1f, 5f);
        });

        PoolManager.Instance.Push(enemyList[0].GetComponent<PoolableMono>());
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
            Debug.Log(enemyList.Count); //이거 안되요
            enemy.transform.position = enemyPos;
            _indexNum++;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
