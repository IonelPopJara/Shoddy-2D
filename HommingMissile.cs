using UnityEngine;

public class HommingMissile : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;

    private Transform target;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        FindObjectOfType<AudioManager>().Play("Homming");

        if (GameObject.FindGameObjectWithTag("Player").transform != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update()
    {
        speed += 0.5f * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if(target != null)
        {
            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;
        }
    }
}
