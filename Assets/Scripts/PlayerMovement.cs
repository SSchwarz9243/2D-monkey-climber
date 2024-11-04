using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool facingRight = true;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;
    public float distanceToBottomOfPlayer = 0.9f;
    private Rigidbody2D rb;
    private const float defaultGravityScale = 7f;
    private Animator animator;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Get the Animator component
        rb.gravityScale = defaultGravityScale;
    }

    void Update() {
        if (GameOverManager.isGameOver) {
            rb.velocity = Vector2.zero;
            return;
        }

        PlayerMove();
        playerRaycast();
    }

    void PlayerMove() {
        moveX = Input.GetAxis("Horizontal");

        // Update the Speed parameter for animation
        animator.SetFloat("Speed", Mathf.Abs(moveX));

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded) {
            Jump();
        }

        // Flip the player sprite based on direction
        if (moveX > 0 && !facingRight) {
            FlipPlayer();
        } else if (moveX < 0 && facingRight) {
            FlipPlayer();
        }

        // Move the player
        rb.velocity = new Vector2(moveX * playerSpeed, rb.velocity.y);
    }

    void Jump() {
        rb.AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
        animator.SetBool("IsJumping", true); // Set the IsJumping parameter for animation
    }

    void FlipPlayer() {
        facingRight = !facingRight;
        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "grass") {
            isGrounded = true;
            animator.SetBool("IsJumping", false); // Reset the IsJumping parameter
        }
    }

    void playerRaycast() {
        // Ray UP
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (rayUp.collider != null && rayUp.distance < distanceToBottomOfPlayer && rayUp.collider.name == "item") {
            Destroy(rayUp.collider.gameObject);
        }

        // Ray Down for enemy interaction
        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        if (rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag == "Enemy") {
            rb.AddForce(Vector2.up * 50); // Adjust this value as needed
            Rigidbody2D enemyRb = rayDown.collider.gameObject.GetComponent<Rigidbody2D>();
            enemyRb.AddForce(Vector2.right * 200);
            enemyRb.gravityScale = 20;
            enemyRb.freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<EnemyMove>().enabled = false;
        }

        if (rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag == "Enemy") {
            isGrounded = true;
        }
    }
}

