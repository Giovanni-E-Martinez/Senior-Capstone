using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    [SerializeField]
    private Texture2D crosshair;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(crosshair, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
