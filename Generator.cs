using UnityEngine;
using UnityEngine.SceneManagement;

public class Generator : MonoBehaviour
{
    public GameObject GeneratorParticles;
    public GameObject ExplosionParticles;
    public GameObject GlassParticles;
    public GameObject CrashParticles;

    private void Start()
    {
        print("Mejor tiempo: " + PlayerPrefs.GetFloat("BestTime" + SceneManager.GetActiveScene().name));
        GameObject generatorParticles = Instantiate(GeneratorParticles, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Cursor.visible = true;
        print("Level Won");
        DestroyGenerator();
        BestTime();
        
        FindObjectOfType<GameManager>().LevelCompleted();
        //Instantiate Particles, sounds and bla bla
    }

    public void DestroyGenerator()
    {
        GameObject explosion = Instantiate(ExplosionParticles, transform.position, Quaternion.identity);
        GameObject glass = Instantiate(GlassParticles, transform.position, Quaternion.identity);
        GameObject crash = Instantiate(CrashParticles, transform.position, Quaternion.identity);

        StartCoroutine(FindObjectOfType<CameraShake>().Shake(1f, 5f, 3f));

        FindObjectOfType<AudioManager>().Play("Explosion");
        FindObjectOfType<AudioManager>().Play("Crash");
        FindObjectOfType<AudioManager>().Play("EnemyDestroyed");

        Destroy(gameObject, 0.5f);
    }

    private void BestTime()
    {
        LevelTimer levelTimer = GameObject.FindObjectOfType<LevelTimer>();
        levelTimer.start = false;

        float bestTime = PlayerPrefs.GetFloat("BestTime" + SceneManager.GetActiveScene().name);

        if(bestTime != 0)
        {
            if (levelTimer.currentTime < bestTime)
            {
                PlayerPrefs.SetFloat("BestTime" + SceneManager.GetActiveScene().name, levelTimer.currentTime);
            }
        }
        else if(bestTime == 0)
        {
            PlayerPrefs.SetFloat("BestTime" + SceneManager.GetActiveScene().name, levelTimer.currentTime);
        }
    }
}
