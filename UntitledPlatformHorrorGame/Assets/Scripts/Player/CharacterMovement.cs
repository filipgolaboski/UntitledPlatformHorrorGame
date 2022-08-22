using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rbPlayer;
    private CapsuleCollider2D capsuleCollider;
    [SerializeField] private LayerMask platformLayerMask;

    public float movSpeed = 7f;
    private float horizontal;
    public float jumpForce = 14f;
    public bool jump;

    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        rbPlayer = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        jump = Input.GetButtonDown("Jump");
    }

    void FixedUpdate()
    {
        rbPlayer.velocity = new Vector2(horizontal * movSpeed, rbPlayer.velocity.y);

        if (jump && IsGrounded()) 
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, jumpForce);
        }
    }

    public bool IsGrounded()
    {
        Vector2 right = new Vector2(capsuleCollider.bounds.center.x + capsuleCollider.bounds.size.x / 2, capsuleCollider.bounds.min.y);
        Vector2 left = new Vector2(capsuleCollider.bounds.center.x - capsuleCollider.bounds.size.x / 2, capsuleCollider.bounds.min.y);
        RaycastHit2D raycastHitright = Physics2D.Raycast(right, Vector2.down, 0.2f, platformLayerMask);
        RaycastHit2D raycastHitleft = Physics2D.Raycast(left, Vector2.down, 0.2f, platformLayerMask);
        return raycastHitleft.collider != null || raycastHitright.collider != null;
    }
}
