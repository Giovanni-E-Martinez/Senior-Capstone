using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class used to define the look and hot-spot of the cursor when using mouse and keyboard.
/// </summary>
public class MousePointer : MonoBehaviour
{
    [SerializeField]
    private Texture2D crosshair;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(crosshair, new Vector2(crosshair.width/2, crosshair.height/2), CursorMode.Auto);
    }
}
