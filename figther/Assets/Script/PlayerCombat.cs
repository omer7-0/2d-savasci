using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;


    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public void DamageEnemy()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
           //  Debug.Log("Zarar" + enemy.name);

            enemy.GetComponent<Enemy>().TakeDamege(attackDamage);
            FindFirstObjectByType<AudioManager>().Play("swordsound2");
            FindFirstObjectByType<AudioManager>().Play("enemyhurt");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint==null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
