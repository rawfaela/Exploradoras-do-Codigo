using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rigd;
    public Animator anim;
    private bool isground;
    private bool hasJumped = false;

    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        rigd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
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
        float teclas = Input.GetAxis("Horizontal");

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


        if (teclas == 0 && isground == true) // o idle tem que saber se ataca ou colide! 
        {
            anim.SetInteger("transitions", 0);
        }
    }

    void Jump()
    {
        // Checa se está no chão e se a tecla de pulo foi pressionada
        if (isground && Input.GetButtonDown("Jump") && !hasJumped)
        {
            rigd.velocity = new Vector2(rigd.velocity.x, jumpForce);
            isground = false;
            hasJumped = true;
            anim.SetInteger("transitions", 2); // Define a animação de salto
        }
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.name == "Tilemap")
        {
            isground = true;
            Debug.Log("tocando o chão!"); 
        }

        if (colisao.gameObject.tag == "caixa")
        {
            isground = true;
            Debug.Log("!");
        }
    }

    void Fall()
    {
        // Checa se o personagem está caindo
        if (rigd.velocity.y < 0 && !isground)
        {
            anim.SetInteger("transitions", 3); // Define a animação de queda
        }
    }


} // NINGUÉM MERECE PROGRAMAR EM C#😁😁😁😁
