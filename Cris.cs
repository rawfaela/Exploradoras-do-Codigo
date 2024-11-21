using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cris : MonoBehaviour
{
    public float speed = 5.5f;
    public float jumpForce = 5f;
    private Rigidbody2D rigd;
    public Animator anim;
    public bool isground;
    private bool hasJumped = false;
    public Transform otherPlayer;
    public bool fim = false;
    public Mari mari;

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
            if (isground)
            {
                anim.SetInteger("transitions", 1);
            }
        }

        if (teclas < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
            if (isground)
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
        // Checa se está no chão e se a tecla de pulo foi pressionada
        if (isground && Input.GetButtonDown("Jump2") && !hasJumped)
        {
            rigd.velocity = new Vector2(rigd.velocity.x, jumpForce);
            isground = false;
            hasJumped = true;
            anim.SetInteger("transitions", 2); // Define a animação de salto
        }
    }

    void Fall()
    {
        // Checa se o personagem está caindo
        if (rigd.velocity.y < 0 && !isground)
        {
            anim.SetInteger("transitions", 2); // Define a animação de queda
        }
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Enemy"))
        {
            Vector2 normal = colisao.contacts[0].normal;

            if (normal.x != 0)
            {
                Debug.Log("!");
                anim.SetTrigger("die");
                Death();
            }
        
            else
            {
                colisao.gameObject.GetComponent<Enemy>().Die();
            }
        }

        if (colisao.gameObject.CompareTag("Platform"))
        {
            Death();
        }
    }

    async void Death()
    {
        Destroy(gameObject, 1f);  //se encosta de lado nao pega a animcao, de cima pega 

        if (otherPlayer == null)
        {
            await Task.Delay(1000);
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerStay2D(Collider2D colisao)
    {
        if (colisao.CompareTag("End"))
        {
            fim = true;
            if (mari != null && mari.fim == true)
            {
                SceneManager.LoadScene("Win");
            }
        }
    }
}
