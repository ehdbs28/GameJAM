using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBossSpace : PoolableMono
{
    private void Update()
    {
        if(EnemyManager.Instance.bossList.Count != 0)
        {
            transform.position = EnemyManager.Instance.bossList[0].transform.position;
        }
    }

    public override void Reset()
    {
        
    }
}
