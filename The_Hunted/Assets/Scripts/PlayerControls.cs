using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting; 

public class PlayerControls : MonoBehaviour
{
    public Transform cameraTransform;
    private CharacterController controller;
    public LayerMask groundLayer;
    public float speed = 10f;
    public float rotationSpeed = 7f;
    private float pitch = 0f;
    public float pitchSpeed = 7f;
    public float pitchRange = 45f;
    private bool isGrounded;
    public int healthValue = 1;
    public float groundCheckDist = 1.0f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    public float gravityScale = 3f;
    public GameManager gameManager;
    
    private Vector3 velocity;

    public float moveSpeed = 7;
    private Vector3 moveDirections = Vector3.zero;
    public int health;

   

    float jumpCooldown = 0.1f;
    float jumpCooldownTimer = 0f;

    private EnemyFollow enemy;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        enemy = FindObjectOfType<EnemyFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        LookAround();

        ApplyGravity();

        jumpCooldownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && jumpCooldownTimer <= 0)
        {
            Jump();
            jumpCooldownTimer = jumpCooldown;
            
            
        }

        
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y =0f;

        forward.Normalize();
        right.Normalize();

        Vector3 movement = forward * moveVertical + right * moveHorizontal;
        
        controller.Move(movement * moveSpeed * Time.deltaTime);
    }

    void LookAround()
    {
        float rotateVertical = Input.GetAxis("Mouse Y");
        float rotateHorizontal = Input.GetAxis("Mouse X");

        Debug.Log("Pitch value: " + Input.GetAxis("Mouse Y"));

        transform.Rotate(Vector3.up * rotateHorizontal * rotationSpeed);

        pitch -= rotateVertical * pitchSpeed;
        pitch = Mathf.Clamp(pitch, -pitchRange, pitchRange);

        cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity * gravityScale);
    }

    void ApplyGravity()
    {
        isGrounded = controller.isGrounded || IsGrounded();

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        velocity.y += gravity * gravityScale * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector2.down, groundCheckDist, groundLayer);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            health -= enemy.damage;
           
            if(health <= 0)
            {
                gameManager.GameOver();
                Destroy(gameObject);
            }
        }
    }

}
