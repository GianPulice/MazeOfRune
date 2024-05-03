using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Boss
{

    private Transform player; 
    private bool isCharging = false;
    private float movementSpeed = 4f;
    private Rigidbody2D playerRigidbody;

    void Start()
    {
        bossName = "Il guerre";
        health = 300;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerRigidbody = player.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
        if (!isCharging && Time.timeSinceLevelLoad > Random.Range(1f, 3f))
        {
            isCharging = true;
            StartCoroutine(ChargeRepeatedly());
        }
    }


    IEnumerator ChargeRepeatedly()
    {
        while (true) 
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f)); 

            while (Vector3.Distance(transform.position, player.position) > 1f) 
            {
                
                transform.position = Vector3.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);
                yield return null;
            }

            PushPlayer();
            Attack();
            yield return new WaitForSeconds(1f);
        }
        
    }

    void PushPlayer()
    {
        if (playerRigidbody != null)
        {

            Vector3 pushDirection = (player.position - transform.position).normalized;

            
            float pushForce = 10f;

           
            playerRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
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
