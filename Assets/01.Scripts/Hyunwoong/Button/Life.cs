using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        if(StageManager.Instance.CurrentStageNum == 5)
        {
            _player.Damage += 0.5f;
            UIManager.Instance.IsClear = false;

            CutSceneManager.Instance.Theme1CutScene();
        }
        else if (StageManager.Instance.CurrentStageNum == 10)
        {
            _player.Damage += 0.5f;
            UIManager.Instance.IsClear = false;

            CutSceneManager.Instance.Theme2CutScene();
        }
        else
        {
            _player.Damage += 0.5f;
            UIManager.Instance.IsClear = false;
            _player.IsAttack = false;
        }
    }
}
