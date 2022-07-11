using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [SerializeField] List<PoolableMono> _poolingList;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple GameManager Instance is running!");
        }
        Instance = this;

        PoolManager.Instance = new PoolManager(transform);
        foreach (PoolableMono p in _poolingList)
        {
            PoolManager.Instance.CreatePool(p, 10);
        }

        MenuManager.Instance = gameObject.AddComponent<MenuManager>();
        CameraManager.Instance = gameObject.GetComponent<CameraManager>();
        TimeControlManager.Instance = gameObject.AddComponent<TimeControlManager>();
        GravityController.Instance = gameObject.AddComponent<GravityController>();
        StageManager.Instance = gameObject.GetComponent<StageManager>();
        EnemyManager.Instance = gameObject.AddComponent<EnemyManager>();
    }
}
