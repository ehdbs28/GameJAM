using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashManager : MonoBehaviour
{
    public static FlashManager Instance;

    Light2D _flash;

    void Start()
    {
        _flash = GameObject.Find("MainVcam/Flash").GetComponent<Light2D>();
    }

    public void WhiteFlash()
    {
        StartCoroutine(White());
    }

    IEnumerator White()
    {
        _flash.intensity = 16;

        yield return new WaitForSecondsRealtime(0.2f);

        _flash.intensity = 0;
    }

    public void RedFlash()
    {
        StartCoroutine(Red());
    }

    IEnumerator Red()
    {
        _flash.color = Color.red;

        _flash.intensity = 20;

        yield return new WaitForSecondsRealtime(0.2f);

        _flash.intensity = 0;
    }
}
