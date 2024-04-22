using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    public float speed = 5f;
    public float moveDuration = 5f;

    private Vector2 currentDirection;
    private bool isMoving = false;

    void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    IEnumerator MoveCoroutine()
    {
        while (true)
        {
            
            currentDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            isMoving = true;

            yield return new WaitForSeconds(moveDuration);

           
            isMoving = false;

            yield return null;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            
            transform.Translate(currentDirection * speed * Time.deltaTime);

           
        }
    }
}

