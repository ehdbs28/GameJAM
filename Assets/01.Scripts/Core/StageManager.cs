using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance = null;

    [SerializeField] private int _currentStageNum = 0;

    [SerializeField] private List<Vector2> _tutorial = new List<Vector2>();
    [SerializeField] private List<Vector2> _stage1 = new List<Vector2>();
    [SerializeField] private List<Vector2> _stage2 = new List<Vector2>();
    [SerializeField] private List<Vector2> _stage3 = new List<Vector2>();
    [SerializeField] private List<Vector2> _stage4 = new List<Vector2>();

    public int CurrentStageNum
    {
        get => _currentStageNum;
        set => _currentStageNum = value;
    }

    private void Start()
    {
        StageStart(_currentStageNum);
    }

    public void StageStart(int stageNum)
    {
        switch (stageNum)
        {
            case 0:
                EnemyManager.Instance.SpawnEnemy(_tutorial);
                break;
            case 1:
                EnemyManager.Instance.SpawnEnemy(_stage1);
                break;
            case 2:
                EnemyManager.Instance.SpawnEnemy(_stage2);
                break;
            case 3:
                EnemyManager.Instance.SpawnEnemy(_stage3);
                break;
            case 4:
                EnemyManager.Instance.SpawnEnemy(_stage4);
                break;

            default:
                return;
        }
    }
}
