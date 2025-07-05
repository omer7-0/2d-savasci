using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public bool enemyattack;

    public float enemytimer;

    public Animator anim;
    void Start()
    {
        currentHealth = maxHealth;
        enemytimer = 1.5f;
        healthBar.SetMaxHealth(maxHealth);

        anim = GetComponent<Animator>();

    }

    void EnemyAttackSpacing()
    {
        if (enemyattack==false)
        {
            enemytimer -= Time.deltaTime;
        }
        if (enemytimer<0)
        {
            enemytimer = 0f;

        }
        if (enemytimer==0f)
        {
            enemyattack = true;
            enemytimer = 1.5f;
        }
    }

    void CharacterDamage()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            enemyattack = false;
        }
    }
    public void TakeDamage(int damage)
    {
        if (enemyattack)
        {
            currentHealth -= 20;
            enemyattack = false;
            anim.SetTrigger("isHurt");
        }
        healthBar.SetHealth(currentHealth);

        if(currentHealth<=0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void Die()
    {
        anim.SetBool("isDead",true);
        GetComponent<CharacterMove>().enabled = false;
        Destroy(gameObject, 2f);
    }
   void Update()
    {
        EnemyAttackSpacing();
        CharacterDamage();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamage(20);
        }
    }

}
