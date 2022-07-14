using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CutSceneManager1 : MonoBehaviour
{
    public static CutSceneManager1 Instance;
    [SerializeField] private GameObject player;

    [SerializeField] private RectTransform curtain;
    [SerializeField] private RectTransform curtain_1;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    void Start()
    {
        
    }

    [ContextMenu("Ŀư")]
    public void Curtain()
    {
        Sequence seq = DOTween.Sequence();

        player.transform.position = new Vector3(0,0,0);
        player.transform.DOMoveY(10, 1f);

        seq.AppendInterval(1f);

        seq.AppendCallback(() =>
        {
            curtain.DOAnchorPosY(900, 0.5f);
            curtain_1.DOAnchorPosY(-900,0.5f);

            textMeshProUGUI.DOFade(1, 10);
        });
    }
}
