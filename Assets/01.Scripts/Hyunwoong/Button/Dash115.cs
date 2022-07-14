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
        Sequence seq = DOTween.Sequence();

        if(StageManager.Instance.CurrentStageNum == 5)
        {
            _player.Speed -= 0.1f;
            seq.AppendInterval(0.5f);

            seq.AppendCallback(() =>
            {
                UIManager.Instance.IsClear = false;
                CutSceneManager.Instance.Theme1CutScene();
            });

        }
        else if (StageManager.Instance.CurrentStageNum == 10)
        {
            _player.Speed -= 0.1f;
            seq.AppendInterval(0.5f);

            seq.AppendCallback(() =>
            {
                UIManager.Instance.IsClear = false;
                CutSceneManager.Instance.Theme2CutScene();
            });

        }
        else if(StageManager.Instance.CurrentStageNum == 11)
        {
            _player.Speed -= 0.1f;
            seq.AppendInterval(0.5f);

            seq.AppendCallback(() =>
            {
                UIManager.Instance.IsClear = false;
                CutSceneManager.Instance.BossStartCutScene();
            });

        }
        else
        {
            _player.Speed -= 0.1f;

            seq.AppendInterval(0.5f);

            seq.AppendCallback(() =>
            {
                UIManager.Instance.IsClear = false;
                _player.IsAttack = false;
            });
        }
    }
}
