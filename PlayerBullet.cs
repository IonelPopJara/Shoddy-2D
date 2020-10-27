using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject bulletParticles;
    public int ricochet;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Bullet");
        Invoke("DestroyBullet", 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null)
        {
            if (collision.collider.CompareTag("Enemy"))
            {
                collision.collider.GetComponent<Enemy>().EnemyExplosion();
                DestroyBullet();
            }
            else if (collision.collider.CompareTag("Player"))
            {
                collision.collider.GetComponent<PlayerHealth>().Explosion();
                DestroyBullet();
            }
            else if (collision.collider.CompareTag("Bullet"))
            {
                DestroyBullet();
            }
            else if (collision.collider.CompareTag("Obstacle"))
            {
                DestroyBullet();
            }
            else if (collision.collider.CompareTag("Glass"))
            {
                DestroyBullet();
            }

            if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ship"))
            {
                if (ricochet == 0)
                {
                    DestroyBullet();
                }
                else
                {
                    ricochet -= 1;
                }
            }            
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);

        GameObject bullet = Instantiate(bulletParticles, transform.position, Quaternion.identity);
        Destroy(bullet, 3f);

        FindObjectOfType<AudioManager>().Play("Bullet Explosion");

        //SFXs and Particles
    }
}
