using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpSpeed = 3f;
    [SerializeField]
    private float direction = 0f;
    private Rigidbody2D player;

    [SerializeField]
    private float groundCheckRadius;
    [SerializeField]
    private float groundCheckOffset;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private bool isGrounded;

    [SerializeField]
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
            player.velocity = new Vector2(direction * speed, player.velocity.y);

        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            Debug.Log("JUMP DA BOB");
        }
    }

    private void GroundCheck()
    {
        Vector2 circlePos = new Vector2(transform.position.x, transform.position.y - groundCheckOffset);
        isGrounded = Physics2D.OverlapCircle(circlePos, groundCheckRadius, groundLayer);
    }

    private void OnDrawGizmos()
    {
        if(isGrounded) Gizmos.color = Color.green;
        else Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y - groundCheckOffset, 1), groundCheckRadius);
    }
}
