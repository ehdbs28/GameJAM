using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance = null;

    [SerializeField] private int _currentStageNum = 0;
    [SerializeField] private UnityEvent OnActive;
    [SerializeField] private UnityEvent OnActive2;

    [SerializeField] private List<GameObject> _backGrounds = new List<GameObject>();

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

    private GameObject _thema1Boss;
    private GameObject _thema2Boss;
    [SerializeField] private GameObject _finalBoss;
    private bool _isBoss = false;
    public bool IsBoss
    {
        get => _isBoss;
        set => _isBoss = value;
    }
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

    float _deltaTime;

    public float DeltaTime
    {
        get => _deltaTime;
        set => _deltaTime = value;
    }

    PlayerAttack player;

    private void Start()
    {
        _thema1Boss = GameObject.Find("Theme1Boss");
        _thema2Boss = GameObject.Find("Theme2Boss");
        _thema1Boss.SetActive(false);
        _thema2Boss.SetActive(false);
        SoundManager.Instance.BGMPlay(1);
        StageStart(_currentStageNum);

        player = FindObjectOfType<PlayerAttack>();
    }

    private void Update()
    {
        if (_currentStageNum == 5 && _isBoss == false)
        {
            Debug.Log("d");
            _isBoss = true;
            EnemyManager.Instance.bossList.Add(_thema1Boss.GetComponent<Enemy>());
            _thema1Boss.SetActive(true);
            //OnActive.Invoke();
        }
        if (_currentStageNum == 10 && _isBoss == false)
        {
            _isBoss = true;
            EnemyManager.Instance.bossList.Add(_thema2Boss.GetComponent<Enemy>());
            _thema2Boss.SetActive(true);
            //OnActive2.Invoke();
        }
        if (_currentStageNum == 11 && _isBoss == false)
        {
            _isBoss = true;
            EnemyManager.Instance.bossList.Add(_finalBoss.GetComponent<Enemy>());
        }
    }

    public void BossEnemySpawn()
    {
        EnemyManager.Instance.SpawnEnemy(_stage11, "Enemy_1");
    }

    public void StageUp(int stageNum)
    {
        UIManager.Instance.IsClear = true;
        player.IsAttack = true;
        CameraManager.Instance.RigMove(stageNum, 2f);
        CameraManager.Instance.ShakeCam(6f, 2f);
        UIManager.Instance.Fade();
        UIManager.Instance.Ablity();
    }

    public void StageStart(int stageNum)
    {
        switch (stageNum)
        {
            case 0:
                TimingManager.Instance.DeleteTimer();
                EnemyManager.Instance.SpawnEnemy(_tutorial, "Enemy_3");
                TimingManager.Instance.StopTime();
                TimingManager.Instance.Timer(2);
                break;
            case 1:
                TimingManager.Instance.DeleteTimer();
                EnemyManager.Instance.SpawnEnemy(_stage1, "Enemy_1");
                TimingManager.Instance.StopTime();
                TimingManager.Instance.Timer(1.8f + _deltaTime);
                break;
            case 2:
                TimingManager.Instance.DeleteTimer();
                EnemyManager.Instance.SpawnEnemy(_stage2, "Enemy_2");
                TimingManager.Instance.StopTime();
                TimingManager.Instance.Timer(1.6f + _deltaTime);
                break;
            case 3:
                TimingManager.Instance.DeleteTimer();
                EnemyManager.Instance.SpawnEnemy(_stage3, "Enemy_1");
                TimingManager.Instance.StopTime();
                TimingManager.Instance.Timer(1.4f + _deltaTime);
                break;
            case 4:
                TimingManager.Instance.DeleteTimer();
                EnemyManager.Instance.SpawnEnemy(_stage4, "Enemy_3");
                TimingManager.Instance.StopTime();
                TimingManager.Instance.Timer(1.2f + _deltaTime);
                break;
            case 5:
                TimingManager.Instance.DeleteTimer();
                //EnemyManager.Instance.SpawnEnemy(_stage4, "Enemy_1");
                //TimingManager.Instance.StopTime();
                //TimingManager.Instance.Timer(5);
                break;
            case 6:
                TimingManager.Instance.DeleteTimer();
                EnemyManager.Instance.SpawnEnemy(_stage6, "Enemy_3");
                _isBoss = false;
                _backGrounds[0].SetActive(false);
                _backGrounds[1].SetActive(true);
                _backGrounds[2].SetActive(false);
                SoundManager.Instance.BGMPlay(2);
                TimingManager.Instance.StopTime();
                TimingManager.Instance.Timer(2);
                break;
            case 7:
                TimingManager.Instance.DeleteTimer();
                EnemyManager.Instance.SpawnEnemy(_stage7, "Enemy_2");
                TimingManager.Instance.StopTime();
                TimingManager.Instance.Timer(1.6f);
                break;
            case 8:
                TimingManager.Instance.DeleteTimer();
                EnemyManager.Instance.SpawnEnemy(_stage8, "Enemy_1");
                TimingManager.Instance.StopTime();
                TimingManager.Instance.Timer(1.2f);
                break;
            case 9:
                TimingManager.Instance.DeleteTimer();
                EnemyManager.Instance.SpawnEnemy(_stage9, "Enemy_3");
                TimingManager.Instance.StopTime();
                TimingManager.Instance.Timer(0.8f);
                break;
            case 10:
                TimingManager.Instance.DeleteTimer();
                //EnemyManager.Instance.SpawnEnemy(_stage4, "Enemy_1");
                //TimingManager.Instance.StopTime();
                //TimingManager.Instance.Timer(5);
                break;
            case 11:
                _isBoss = false;
                TimingManager.Instance.DeleteTimer();
                _backGrounds[0].SetActive(false);
                _backGrounds[1].SetActive(false);
                _backGrounds[2].SetActive(true);
                SoundManager.Instance.BGMPlay(4);
                EnemyManager.Instance.SpawnEnemy(_stage11, "Enemy_1");
                TimingManager.Instance.StopTime();
                CameraManager.Instance.SetToBossVCam();
                break;

            default:
                return;
        }
    }
}
