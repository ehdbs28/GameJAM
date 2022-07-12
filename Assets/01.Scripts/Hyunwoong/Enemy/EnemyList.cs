using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyList : MonoBehaviour
{
    public List<Enemy> enemyList = new List<Enemy>();

    int posX = -2;
    
    void Start()
    {
        StartCoroutine(AddEnemy(5));
    }

    public void EnemyDie()
    {
        PoolManager.Instance.Push(enemyList[0].GetComponent<PoolableMono>());

    }

    IEnumerator AddEnemy(int k)
    {
        for (int i = 0; i < k; i++)
        {
            posX += 2;
            Enemy enemy = PoolManager.Instance.Pop("Enemy_1") as Enemy;
            enemyList.Add(enemy);
            //print(enemyList[]);
            enemy.transform.position = new Vector2(posX, 0);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
