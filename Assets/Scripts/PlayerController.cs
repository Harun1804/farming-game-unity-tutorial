using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement Components
    private CharacterController characterController;
    private Animator animator;
    private float moveSpeed = 4f;
    [Header("Movement System")]
    [SerializeField] public float walkSpeed = 4f;
    [SerializeField] public float runSpeed = 8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move() 
    {
        // Get horizontal and vertical input values as a number
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        // Direction in a normalized vector
        Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 velocity = dir * Time.deltaTime * moveSpeed;

        // Is the sprint key pressed?
        if (Input.GetButton("Sprint")) {
            moveSpeed = runSpeed;
            animator.SetBool("Running", true);
        } else {
            moveSpeed = walkSpeed;
            animator.SetBool("Running", false);
        }

        // Check if the player is moving
        if (dir.magnitude >= 0.1f) {
            // Loook at the direction of movement
            transform.rotation = Quaternion.LookRotation(dir);

            // Move
            characterController.Move(velocity);
        }

        animator.SetFloat("Speed", velocity.magnitude);
    }
}
