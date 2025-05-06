using System;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded = false;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    public AudioClip jumpSound;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();  // ต้องมี Animator ติดไว้
        sr = GetComponent<SpriteRenderer>();

        audioSource = GetComponent<AudioSource>();
        
        // ป้องกันการหมุนเอียงตอนกระโดด
        rb.freezeRotation = true;
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        // เดินด้วยการตั้ง velocity ตรง ๆ จะควบคุมได้ดีกว่า AddForce
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // พลิกตัวตามทิศทาง
        if (move > 0) sr.flipX = false;
        else if (move < 0) sr.flipX = true;

        // กระโดด
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            anim.SetBool("isJumping", !isGrounded);
            audioSource.PlayOneShot(jumpSound);
        }

    }

    void FixedUpdate()
    {
        anim.SetFloat("xVelocity", Math.Abs(rb.linearVelocity.x));
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("isJumping", !isGrounded);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
