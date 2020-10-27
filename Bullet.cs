using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletParticles;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Bullet");
        Destroy(gameObject, 20f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider != null)
        {
            if(collision.collider.CompareTag("Enemy"))
            {
                collision.collider.GetComponent<Enemy>().EnemyExplosion();
            }
            else if(collision.collider.CompareTag("Player"))
            {
                collision.collider.GetComponent<PlayerHealth>().Explosion();
            }

            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);

        GameObject bullet = Instantiate(bulletParticles, transform.position, Quaternion.identity);
        Destroy(bullet,3f);

        FindObjectOfType<AudioManager>().Play("Bullet Explosion");

        //SFXs and Particles
    }
}
