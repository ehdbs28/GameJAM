using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance = null;

    [SerializeField] private int _currentStageNum = 0;
    [SerializeField] private UnityEvent OnActive;

    [SerializeField] private List<Vector2> _tutorial = new List<Vector2>();
    [SerializeField] private List<Vector2> _stage1 = new List<Vector2>();
    [SerializeField] private List<Vector2> _stage2 = new List<Vector2>();
    [SerializeField] private List<Vector2> _stage3 = new List<Vector2>();
    [SerializeField] private List<Vector2> _stage4 = new List<Vector2>();
    [SerializeField] private List<Vector2> _stage5 = new List<Vector2>();
    [SerializeField] private List<Vector2> _stage6 = new List<Vector2>();
    [SerializeField] private List<Vector2> _stage7 = new List<Vector2>();
    [SerializeField] private List<Vector2> _stage8 = new List<Vector2>();
    [SerializeField] private List<Vector2> _stage9 = new List<Vector2>();
    [SerializeField] private List<Vector2> _stage10 = new List<Vector2>();
    [SerializeField] private List<Vector2> _stage11 = new List<Vector2>();
    [SerializeField] private List<Vector2> _stage12 = new List<Vector2>();
    [SerializeField] private List<Vector2> _stage13 = new List<Vector2>();
    [SerializeField] private List<Vector2> _stage14 = new List<Vector2>();
    [SerializeField] private List<Vector2> _stage15 = new List<Vector2>();

    private GameObject _thema1Boss;
    private bool _isStageUp = false;
    public bool IsStageUp
    {
        get => _isStageUp;
        set => _isStageUp = value;
    }
    public int CurrentStageNum
    {
        get => _currentStageNum;
        set => _currentStageNum = value;
    }

    private void Start()
    {
        _thema1Boss = GameObject.Find("Thema1Boss");
        _thema1Boss.SetActive(false);
        StageStart(_currentStageNum);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _currentStageNum = 5;
        }

        if (_currentStageNum == 5)
        {
            _thema1Boss.SetActive(true);
            OnActive.Invoke();
        }
    }

    public void StageUp(int stageNum)
    {
        CameraManager.Instance.RigMove(stageNum, 2f);
        CameraManager.Instance.ShakeCam(6f, 2f);
        UIManager.Instance.Fade();

    }

    public void StageStart(int stageNum)
    {
        switch (stageNum)
        {
            case 0:
                EnemyManager.Instance.SpawnEnemy(_tutorial, "Enemy_1");
                break;
            case 1:
                EnemyManager.Instance.SpawnEnemy(_stage1, "Enemy_1");
                break;
            case 2:
                EnemyManager.Instance.SpawnEnemy(_stage2, "Enemy_1");
                break;
            case 3:
                EnemyManager.Instance.SpawnEnemy(_stage3, "Enemy_1");
                break;
            case 4:
                EnemyManager.Instance.SpawnEnemy(_stage4, "Enemy_1");
                break;

            default:
                return;
        }
    }
}
