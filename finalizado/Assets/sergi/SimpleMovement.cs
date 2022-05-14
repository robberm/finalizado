using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public bool isGrounded = false;
    public Vector2 groundCheckSize = new Vector2(.5f, .15f);
    public Vector2 groundCheckOffset = new Vector2(0, -.5f);

    private Vector2 input;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private void Start()
    {
        TryGetComponent(out rb);
        TryGetComponent(out sr);
        TryGetComponent(out anim);
    }

    private void Update()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            anim.SetTrigger("Jump");
        }

        if(input != Vector2.zero)
        {
            transform.eulerAngles = input.x > .1f ? Vector3.zero : new Vector3(0, 180, 0);
        }

        GroundChecker();

        if(isGrounded == false && rb.velocity.y < 0f)
        {
            anim.SetBool("IsFalling", true);
        }

        anim.SetBool("IsRunning", input.sqrMagnitude > 0.1f);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(input.normalized.x * speed, rb.velocity.y);
    }

    void GroundChecker()
    {
        Collider2D _coll = Physics2D.OverlapBox(transform.position + (Vector3)groundCheckOffset, (Vector3)groundCheckSize, 0f);
        if (_coll == true)
        {
            if(isGrounded == false)
            {
                isGrounded = true;
                anim.SetBool("IsFalling", false);
            }
        }
        else if(isGrounded == true)
        {
            isGrounded = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + (Vector3)groundCheckOffset, (Vector3)groundCheckSize);
    }
}
