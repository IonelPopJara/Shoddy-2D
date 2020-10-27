using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public Transform glassSpawn;
    public GameObject glassParticlesPrefab;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Instantiate(glassParticlesPrefab, glassSpawn.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Glass");
        }
        else if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(glassParticlesPrefab, glassSpawn.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Glass");
        }

    }
}
