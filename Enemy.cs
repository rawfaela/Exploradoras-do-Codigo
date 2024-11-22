using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float rollSpeed = 200f;
    public Transform pointA;
    public Transform pointB;
    private bool movingToB = true;

 
    void Update()
    {
        Move();
        Roll();
    }
    void Move()
    {
        Transform target = movingToB ? pointB : pointA;
        
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
      
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            movingToB = !movingToB;
        
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;

        }
    }

    void Roll()
    {
        float movimento = !movingToB ? -1 : 1;
        if (movimento != 0)
        {
            float rotacaoDirecao = movimento > 0 ? -1 : 1;
            transform.Rotate(0, 0, rotacaoDirecao * rollSpeed * Time.deltaTime);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
