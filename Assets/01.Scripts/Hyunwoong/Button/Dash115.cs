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
        _player.Speed -= 0.1f;
        UIManager.Instance.IsClear = false;
        print($"{UIManager.Instance.IsClear}");
        _player.IsAttack = false;
    }
}
