using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cris : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rigd;
    public Animator anim;
    public bool isground;
    private bool hasJumped = false;

    void Start()
    {
        rigd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
        Fall();
        if (isground)
        {
            hasJumped = false;
        }
    }

    void Move()

    {
        float teclas = Input.GetAxis("Horizontal2");

        rigd.velocity = new Vector2(teclas * speed, rigd.velocity.y);

        if (teclas > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
            if (isground == true)
            {
                anim.SetInteger("transitions", 1);
            }
        }

        if (teclas < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
            if (isground == true)
            {
                anim.SetInteger("transitions", 1);
            }
        }


        if (teclas == 0 && isground) // o idle tem que saber se ataca ou colide! 
        {
            anim.SetInteger("transitions", 0);
        }
    }

    void Jump()
    {
        // Checa se est� no ch�o e se a tecla de pulo foi pressionada
        if (isground && Input.GetButtonDown("Jump2") && !hasJumped)
        {
            rigd.velocity = new Vector2(rigd.velocity.x, jumpForce);
            isground = false;
            hasJumped = true;
            anim.SetInteger("transitions", 2); // Define a anima��o de salto
        }
    }

    void Fall()
    {
        // Checa se o personagem est� caindo
        if (rigd.velocity.y < 0 && !isground)
        {
            anim.SetInteger("transitions", 3); // Define a anima��o de queda
        }
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.name == "Tilemap")
        {
            isground = true;
            Debug.Log("tocando o ch�o!");
        }
    }

}
