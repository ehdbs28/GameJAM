using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashFx : PoolableMono
{
    public void OnDieFx()
    {
        PoolManager.Instance.Push(this);
    }

    public override void Reset()
    {
        
    }
}
