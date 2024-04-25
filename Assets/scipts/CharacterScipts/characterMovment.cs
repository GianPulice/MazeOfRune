using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterMovment : MonoBehaviour
{
    public float speed = 5f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }



    public void IncreaseSpeed()
    {
        speed += 2f; 
    }


    void Update()
    {
        
        

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");


        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * speed * Time.deltaTime;

        transform.Translate(movement);

        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); 
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); 
        }

        if (movement.magnitude > 0)
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
    }
    
}

