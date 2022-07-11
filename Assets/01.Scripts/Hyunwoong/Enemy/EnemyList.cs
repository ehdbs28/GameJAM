using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    public List<Enemy> enemyList = new List<Enemy>();

    int posX = -2;
    
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            posX += 2;
            Enemy enemy = PoolManager.Instance.Pop("Enemy_1") as Enemy;
            enemyList.Add(enemy);
            enemy.transform.position = new Vector2(posX, 0);

            print(enemy.name);
        }
    }

    /*public void EnemyDie()
    {
        enemyList.RemoveAt(0);
        PoolManager.Instance.Push(enemyList[0].GetComponent<PoolableMono>());
    }*/
}
