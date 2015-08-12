using UnityEngine;
using System.Collections;
 
public class PlayerController : MonoBehaviour {
    public float moveSpeed;
    public float jumpForce;
    public LayerMask groundMask;
    public bool grounded;
    public bool airControl;
    bool facingRight = true;
    Rigidbody2D rigidbody;
    public Transform foot;
        // Use this for initialization
        void Awake () {
        rigidbody = GetComponent<Rigidbody2D>();
        }
       
        void FixedUpdate () {
        if (grounded || airControl)
        {
            rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rigidbody.velocity.y);
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (facingRight && Input.GetAxis("Horizontal") < 0)
            {
                flip();
            }
            else if (!facingRight && Input.GetAxis("Horizontal") > 0)
            {
                flip();
            }
        }
    }
 
    void Update()
    {
        if (Physics2D.OverlapCircle(foot.position, GetComponent<CircleCollider2D>().radius, groundMask))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        if (grounded && Input.GetButtonDown("Jump"))
        {
            rigidbody.AddForce(transform.up * jumpForce);
        }
    }
 
    void flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
    }
}