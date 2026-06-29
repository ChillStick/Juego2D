using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed=5f;
    [SerializeField] float jumpForce=7f;
    [SerializeField] LayerMask groundLayer; 
    public bool isGrounded = false;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput > 0)
        {
            sprite.flipX = false;
        }
        if (horizontalInput < 0)
        {
            sprite.flipX = true;
        }
        anim.SetBool("Run", horizontalInput != 0);
        // Controles de personaje
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        // Almacenando el colisionador en una variable separada para facilitar su uso
        Collider2D col = GetComponent<Collider2D>();
        // Creando un área circular debajo de los pies del personaje
        isGrounded = Physics2D.OverlapCircle(transform.position - transform.up * ((col.bounds.extents.y / transform.localScale.y - col.offset.y) * transform.localScale.y), 0.01f, groundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        anim.SetFloat("Y", rb.velocity.y);
        if (isGrounded) 
            anim.SetFloat("Y", 0);
    }
}
