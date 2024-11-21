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

    // Update is called once per frame
    void Update()
    {
        Move();
        Roll();
    }
    void Move()
    {
        Transform target = movingToB ? pointB : pointA;

        // Move o inimigo em direção ao alvo
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Verifica se o inimigo chegou ao alvo
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            // Inverte a direção
            movingToB = !movingToB;

            // Inverte a escala no eixo X para fazer o inimigo virar
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;

        }
    }

    void Roll()
    {
        // Girar o personagem ao longo do eixo Z para criar o efeito de rolagem
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