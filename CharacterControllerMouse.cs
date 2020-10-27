using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterControllerMouse : MonoBehaviour
{
    public GameObject mouseCursor;
    public Camera cam;
    private Rigidbody2D rb;

    private Vector2 movement;
    private Vector2 mousePos;

    private void Start()
    {
        mouseCursor.SetActive(true);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        rb.rotation = angle;
    }
}
