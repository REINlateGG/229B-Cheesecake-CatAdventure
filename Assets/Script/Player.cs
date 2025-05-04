using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    //float move;
    Vector2 moveInput;
    public float JumpForce;
    public bool IsJumping;

    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        moveInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.AddForce (moveInput*Speed);

        //move = Input.GetAxis("Horizontal");
        //rb2d.linearVelocity = new Vector2(move * Speed, rb2d.linearVelocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, JumpForce));
            Debug.Log("Jump");
        }
    }

    private void OCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }

    }

    private void OnCollisionExit2D(Collision2D other)  
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = true;
        }
    }
}
