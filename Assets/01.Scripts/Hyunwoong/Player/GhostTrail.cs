using UnityEngine;
using DG.Tweening;

public class GhostTrail : MonoBehaviour
{
    SpriteRenderer sprite;
    PlayerAttack anim;
    PlayerAttack playerMovement;
    public Transform ghostsParent;
    public Color trailColor;
    public Color fadeColor;
    public float trailInterval;
    public float fadeTime;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        playerMovement = FindObjectOfType<PlayerAttack>();
        anim = FindObjectOfType<PlayerAttack>();
    }

    public void ShowGhost()
    {
        Sequence s = DOTween.Sequence();
        for (int i = 0; i < ghostsParent.childCount; i++)
        {
            Transform currentGhost = ghostsParent.GetChild(i);
            s.AppendCallback(() => currentGhost.position = playerMovement.transform.position);
            s.Append(currentGhost.GetComponent<SpriteRenderer>().material.DOColor(trailColor, 0));
            s.AppendCallback(() => FadeSprite(currentGhost));
            s.AppendInterval(trailInterval);
        }
    }
    // 효과 페이드 아웃
    public void FadeSprite(Transform current)
    {
        current.GetComponent<SpriteRenderer>().material.DOKill();
        current.GetComponent<SpriteRenderer>().material.DOColor(fadeColor, fadeTime);
    }


}
