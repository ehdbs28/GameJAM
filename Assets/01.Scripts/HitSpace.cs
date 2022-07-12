using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSpace : PoolableMono
{
    private void Update()
    {
        if(EnemyManager.Instance.enemyList.Count != 0)
        {
            transform.position = EnemyManager.Instance.enemyList[0].transform.position;
        }
    }

    public override void Reset()
    {
        
    }
}
