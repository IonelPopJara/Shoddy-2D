using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject CrashParticles;
    public GameObject ExplosionParticles;

    public void Explosion()
    {
        Destroy(gameObject);

        GameObject crash = Instantiate(CrashParticles, transform.position, Quaternion.identity);
        GameObject explosion = Instantiate(ExplosionParticles, transform.position, Quaternion.identity);

        Destroy(crash, 1f);
        Destroy(explosion, 1f);
        
        GameObject.FindObjectOfType<TimeManager>().slowTime = false;
        FindObjectOfType<GameManager>().PlayerCrash();
        StartCoroutine(FindObjectOfType<CameraShake>().Shake(1f, 5f, 3f));

        FindObjectOfType<AudioManager>().Play("Crash");
        FindObjectOfType<AudioManager>().Play("Explosion");
    }
}
