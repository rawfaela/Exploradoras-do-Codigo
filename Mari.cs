using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mari : MonoBehaviour
{
    public float speed = 5.5f;
    public float jumpForce = 5f;
    private Rigidbody2D rigd;
    public Animator anim;
    public bool isground;
    private bool hasJumped = false;
    public Transform otherPlayer;
    public Cris cris;
    public bool fim = false;
    
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
        float teclas = Input.GetAxis("Horizontal");

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


        if (teclas == 0 && isground) 
        {
            anim.SetInteger("transitions", 0);
        }
    }

    void Jump()
    {
        if (isground && Input.GetButtonDown("Jump") && !hasJumped)
        {
            rigd.velocity = new Vector2(rigd.velocity.x, jumpForce);
            isground = false;
            hasJumped = true;
            anim.SetInteger("transitions", 2); 
        }
    }

    void Fall()
    {
        if (rigd.velocity.y < 0 && !isground)
        {
            anim.SetInteger("transitions", 2);
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
        Destroy(gameObject, 1f);

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
            if (cris != null && cris.fim == true)
            {
                SceneManager.LoadScene("Win");
            }
        }
    }
}
