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
        if(StageManager.Instance.CurrentStageNum == 5)
        {
            EnemyManager.Instance.Intensity += 0.5f;
            UIManager.Instance.IsClear = false;

            CutSceneManager.Instance.Theme1CutScene();
        }
        else if (StageManager.Instance.CurrentStageNum == 10)
        {
            EnemyManager.Instance.Intensity += 0.5f;
            UIManager.Instance.IsClear = false;

            CutSceneManager.Instance.Theme2CutScene();
        }
        else
        {

            EnemyManager.Instance.Intensity += 0.5f;
            UIManager.Instance.IsClear = false;
            _player.IsAttack = false;
        }

    }
}
