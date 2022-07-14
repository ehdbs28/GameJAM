using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NumberLine : MonoBehaviour
{
    [SerializeField] private List<Transform> rTransform = new List<Transform>();

    private Transform player;

    private void Start()
    {
        player = GetComponent<Transform>();
    }

    public void ViewStage()
    {
        player.DOMove(rTransform[StageManager.Instance.CurrentStageNum].transform.position, 1f);
    }
}
