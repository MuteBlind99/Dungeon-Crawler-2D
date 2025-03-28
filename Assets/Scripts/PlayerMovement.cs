using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed = 3f;

    public Rigidbody2D rigidbody;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    private Vector2 movement;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
    }

    void FixedUpdate()
    {
        rigidbody.linearVelocity = movement * speed;
    }

    void OnMove()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        movement = movement.normalized;
        
        animator.SetFloat("Speed", movement.sqrMagnitude);
        
        if (movement.x != 0)
        {
            spriteRenderer.flipX = movement.x < 0;
        }
    }
}