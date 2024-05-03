using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageSpell : MonoBehaviour
{
    public float speed = 3f; 
    private Transform player; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    void Update()
    {
       
        Vector2 direction = (player.position - transform.position).normalized;

        
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           
            Vector2 pushDirection = (transform.position - player.position).normalized;

            
            other.GetComponent<Rigidbody2D>().AddForce(pushDirection * 5f, ForceMode2D.Impulse);

            
            Destroy(gameObject);
        }
    }
}
