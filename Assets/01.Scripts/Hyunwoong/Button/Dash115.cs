using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dash115 : StatUp
{


    public override void Stat()
    {
        UIManager.Instance._ablityPanelTrm.DOAnchorPosY(-1200, 1f);
    }
}
