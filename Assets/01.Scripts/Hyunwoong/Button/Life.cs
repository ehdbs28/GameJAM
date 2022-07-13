using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : StatUp
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
