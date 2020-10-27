using UnityEngine;

public class NormalTurretShooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform firePoint;

    public float bulletForce;

    public float timeBtwShoots;
    private float currentTime;

    private bool isPlayerOnSight;

    private void Start()
    {
        currentTime = 0;
        isPlayerOnSight = false;
    }

    private void Update()
    {
        if(isPlayerOnSight)
        {
            ShootingTimer();
        }
    }

    void Shoot()
    {
        if(firePoint != null)
        {
            GameObject bullet = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

            //Play Sound Fx
        }
    }

    void ShootingTimer()
    {
        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else if (currentTime <= 0)
        {
            Shoot();
            currentTime = timeBtwShoots;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isPlayerOnSight = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isPlayerOnSight = false;
    }
}
