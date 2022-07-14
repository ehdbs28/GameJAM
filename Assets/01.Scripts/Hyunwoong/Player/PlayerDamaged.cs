using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerDamaged : MonoBehaviour, IDamaged
{
    private float _tryCount = 3;
    private PlayerAttack _playerAttack;

    float _playerHp = 1;

    Animator anim;
    private int index = 3;

    [SerializeField] private UnityEvent Stage;

    public float PlayerHp
    {
        get { return _playerHp; }
        set { _playerHp = value; }
    }

    private void Start()
    {
        _playerAttack = GetComponent<PlayerAttack>();
        anim = GetComponent<Animator>();
    }

    public void Damaged(float damage)
    {
        if (!_playerAttack.IsDodge)
        {
            _playerHp -= damage;

            if (_playerHp <= 0 && _playerAttack.IsDead == false)
            {
                anim.SetBool("IsDeath", true);
                _playerAttack.IsDead = true;

                StartCoroutine(SceneReLoad());
            }
        }
        else return;
    }

    IEnumerator SceneReLoad()
    {
        UIManager.Instance.FadeIn();

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(1);
    }
}
