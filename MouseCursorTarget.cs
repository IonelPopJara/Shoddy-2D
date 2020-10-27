using UnityEngine;

public class MouseCursorTarget : MonoBehaviour
{
    public Camera cam;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector2 cursorPos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }
}
