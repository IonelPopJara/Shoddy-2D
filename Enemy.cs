using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyDestroyParticles;
    public GameObject Reloj;

    public void EnemyExplosion()
    {
        //Points for the player
        Destroy(gameObject);
        GameObject enemy = Instantiate(EnemyDestroyParticles, transform.position, Quaternion.identity);
        Destroy(enemy, 5f);
        StartCoroutine(FindObjectOfType<CameraShake>().Shake(0.05f, 2f, 2f));
        FindObjectOfType<TimeManager>().slowdownEnergy += 2;

        FindObjectOfType<AudioManager>().Play("Explosion");
        FindObjectOfType<AudioManager>().Play("EnemyDestroyed");

        GameObject reloj = Instantiate(Reloj, GameObject.Find("Player").transform.position, Quaternion.identity);
        Destroy(reloj, 1f);
        //Instantiate Particles and Sound
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null)
        {
            if (collision.collider.CompareTag("Player"))
            {
                collision.collider.GetComponent<PlayerHealth>().Explosion();
                EnemyExplosion();
            }
        }
    }
}
