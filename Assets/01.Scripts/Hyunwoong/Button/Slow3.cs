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
        if(StageManager.Instance.CurrentStageNum == 5)
        {
            EnemyManager.Instance.Sec += 0.05f;
            UIManager.Instance.IsClear = false;

            CutSceneManager.Instance.Theme1CutScene();
        }
        else if (StageManager.Instance.CurrentStageNum == 10)
        {
            EnemyManager.Instance.Sec += 0.05f;
            UIManager.Instance.IsClear = false;

            CutSceneManager.Instance.Theme2CutScene();
        }
        else
        {
            EnemyManager.Instance.Sec += 0.05f;

            UIManager.Instance.IsClear = false;
            _player.IsAttack = false;
        }

    }
}