using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Plus5 : StatUp
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
        _player.Damage += 0.5f;
        UIManager.Instance.IsClear = false;
        print($"{UIManager.Instance.IsClear}");
        _player.IsAttack = false;
    }
}
