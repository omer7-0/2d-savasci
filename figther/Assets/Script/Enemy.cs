using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public int maxHealth = 100;
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public   void TakeDamege(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hurt");

        if (currentHealth<=0)
        {
            Die();
        }
    }

    void Die()
    {
        anim.SetBool("isDead", true);

        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 2f);
    }

}
