using UnityEngine;

public class SpringScript : MonoBehaviour
{
    public GameObject SpringParticles;
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("Jump");
        GameObject spring = Instantiate(SpringParticles, transform.position, Quaternion.identity);
        Destroy(spring, 2f);
        //Spring Particles (Dust)
    }
}
