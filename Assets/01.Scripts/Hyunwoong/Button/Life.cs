using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Life : StatUp
{
    Button button;
    PlayerAttack _player;

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
            _player.Damage += 0.5f;
            seq.AppendInterval(0.5f);
            seq.AppendCallback(() =>
            {
                UIManager.Instance.IsClear = false;
                CutSceneManager.Instance.Theme1CutScene();
            });
            
        }
        else if (StageManager.Instance.CurrentStageNum == 10)
        {
            _player.Damage += 0.5f;
            seq.AppendInterval(0.5f);
            seq.AppendCallback(() =>
            {
                UIManager.Instance.IsClear = false;
                CutSceneManager.Instance.Theme2CutScene();
            });
        }
        else if(StageManager.Instance.CurrentStageNum == 11)
        {
            _player.Damage += 0.5f;
            seq.AppendInterval(0.5f);
            seq.AppendCallback(() =>
            {
                UIManager.Instance.IsClear = false;
                CutSceneManager.Instance.BossStartCutScene();
            });
        }
        else
        {
            _player.Damage += 0.5f;
            seq.AppendInterval(0.5f);
            seq.AppendCallback(() =>
            {
                UIManager.Instance.IsClear = false;
                _player.IsAttack = false;
            });
        }
    }
}
