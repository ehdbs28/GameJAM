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

        _flash.intensity = 0;
    }

    public void Flash(Color color)
    {
        _flash.color = color;
        StopAllCoroutines();
        StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        _flash.intensity = 30;

        yield return new WaitForSecondsRealtime(0.2f);

        _flash.intensity = 0;
    }
}
