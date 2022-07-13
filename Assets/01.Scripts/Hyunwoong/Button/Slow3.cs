using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Slow3 : StatUp
{
    Button button;
    private PlayerAttack _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerAttack>();
        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            Stat();
        });
    }

    public override void Stat()
    {
        EnemyManager.Instance.Sec += 0.05f;

        UIManager.Instance.IsClear = false;
        _player.IsAttack = false;
    }
}