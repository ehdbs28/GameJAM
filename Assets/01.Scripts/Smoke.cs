using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : PoolableMono
{
    public void OnDieFx()
    {
        PoolManager.Instance.Push(this);
    }

    public override void Reset()
    {
        
    }
}
