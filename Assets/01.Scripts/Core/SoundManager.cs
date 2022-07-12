using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance = null;

    [SerializeField] private List<AudioClip> _bgmList = new List<AudioClip>();

    private AudioSource _audioSource;
    private AudioSource _bgmSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _bgmSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    public void SFXPlay(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }

    public void BGMPlay(int stageNum)
    {
        switch (stageNum)
        {
            case 1:
                _bgmSource.Stop();
                _bgmSource.clip = _bgmList[0];
                _bgmSource.Play();
                break;
            case 2:
                _bgmSource.Stop();
                _bgmSource.clip = _bgmList[1];
                _bgmSource.Play();
                break;
            case 3:
                _bgmSource.Stop();
                _bgmSource.clip = _bgmList[2];
                _bgmSource.Play();
                break;
            case 4:
                _bgmSource.Stop();
                _bgmSource.clip = _bgmList[3];
                _bgmSource.Play();
                break;
            default:
                return;
        }

    }
}
