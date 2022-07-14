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
        Sequence seq = DOTween.Sequence();
        if (StageManager.Instance.CurrentStageNum == 5)
        {
            EnemyManager.Instance.Sec += 0.05f;
            seq.AppendInterval(0.5f);
            seq.AppendCallback(() =>
            {
                UIManager.Instance.IsClear = false;
                CutSceneManager.Instance.Theme1CutScene();
            });
        }
        else if (StageManager.Instance.CurrentStageNum == 10)
        {
            EnemyManager.Instance.Sec += 0.05f;
            seq.AppendInterval(0.5f);
            seq.AppendCallback(() =>
            {
                UIManager.Instance.IsClear = false;
                CutSceneManager.Instance.Theme2CutScene();
            });
        }
        else if (StageManager.Instance.CurrentStageNum == 11)
        {
            EnemyManager.Instance.Sec += 0.05f;
            seq.AppendInterval(0.5f);
            seq.AppendCallback(() =>
            {
                UIManager.Instance.IsClear = false;
                CutSceneManager.Instance.BossStartCutScene();
            });
        }
        else
        {
            EnemyManager.Instance.Sec += 0.05f;
            seq.AppendInterval(0.5f);
            seq.AppendCallback(() =>
            {
                UIManager.Instance.IsClear = false;
                _player.IsAttack = false;
            });
        }

    }
}