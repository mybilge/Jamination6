using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControlMainMenu : MonoBehaviour
{
    [SerializeField] Texture2D normalCursor;

    Texture2D normalCursorCopy;
    private void Start()
    {
        normalCursorCopy = normalCursor;

        Cursor.SetCursor(normalCursorCopy, Vector2.zero, CursorMode.ForceSoftware);
    }
}
