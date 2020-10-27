using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Rigidbody2D rbPlayer;

    [Header("Shooting Options")]
    public float bulletForce;
    public float knockBackForce;

    [Header("Cool Down Options")]
    public float timeBtwShoot;
    private float currentTime;
    private bool shootAvailable;

    private LevelTimer levelTimer;

    private Vector3 playerVelocity;

    private void Start()
    {
        shootAvailable = true;
        levelTimer = GameObject.FindObjectOfType<LevelTimer>();
    }

    private void Update()
    {
        playerVelocity = rbPlayer.velocity;

        float actualForce = bulletForce + (playerVelocity.magnitude) / 10;


        if (Input.GetMouseButtonDown(0))
        {
            if(!levelTimer.start)
            {
                levelTimer.start = true;
            }

            if(shootAvailable)
            {
                shootAvailable = false;
                Shoot();
            }
        }
        ShootAvailable();
    }

    void Shoot()
    {
        StartCoroutine(FindObjectOfType<CameraShake>().Shake(0.05f, 1f, 2f));
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * (bulletForce + (playerVelocity.magnitude)), ForceMode2D.Impulse);

        BackFire();
    }

    void BackFire()
    {
        rbPlayer.AddForce(-firePoint.up * knockBackForce, ForceMode2D.Impulse);
    }

    void ShootAvailable()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else if (currentTime <= 0)
        {
            currentTime = timeBtwShoot;
            shootAvailable = true;
        }
    }
}
