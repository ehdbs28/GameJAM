using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : StatUp
{
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            Stat();
        });
    }

    public override void Stat()
    {
        StageManager.Instance.DeltaTime += 0.2f;
        UIManager.Instance.IsClear = false;
    }
}
