using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Slow3 : StatUp
{
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            Stat();
        });
    }

    public override void Stat()
    {
        EnemyManager.Instance.Sec += 0.3f;

        UIManager.Instance.IsClear = false;
    }
}