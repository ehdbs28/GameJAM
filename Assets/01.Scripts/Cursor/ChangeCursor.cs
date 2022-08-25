using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField] private Texture2D _cursorImage;

    private void Awake()
    {
        Cursor.SetCursor(_cursorImage, new Vector3(_cursorImage.width / 2, _cursorImage.height / 2), CursorMode.Auto);
    }
}
