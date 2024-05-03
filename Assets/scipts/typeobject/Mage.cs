using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Boss
{
    public GameObject projectilePrefab; 
    private Transform player; 

    void Start()
    {
        bossName = "El Magio";
        health = 200;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(LaunchProjectiles());

    }

    IEnumerator LaunchProjectiles()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f); 

            Vector2 direction = (player.position - transform.position).normalized;

            
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectile.GetComponent<MageSpell>().speed;
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public override void Attack()
    {
        Debug.Log($"{bossName} ataca");
    }
}
