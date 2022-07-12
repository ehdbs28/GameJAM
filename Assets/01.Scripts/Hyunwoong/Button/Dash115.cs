using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Dash115 : StatUp
{
    private PlayerAttack _player;

    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        _player = FindObjectOfType<PlayerAttack>();

        button.onClick.AddListener(() =>
        {
            Stat();
        });
    }

    public override void Stat()
    {
        _player.Speed *= 1.15f;
        UIManager.Instance.IsClear = false;
        _player.IsAttack = false;
    }
}
