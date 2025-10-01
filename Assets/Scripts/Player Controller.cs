using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;
    private Vector3 moveInput;
    public float sensitivity = 1f;
    public Transform playerCamera;

    private Vector2 lookInput;
    private float xRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log("Move input: " + moveInput);
    }


    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log($"Jumping {context.performed} - Is Grounded: {controller.isGrounded}");
        if (context.performed && controller.isGrounded)
        {
            Debug.Log(" we are supposed to jump");
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }
    public void Look(InputAction.CallbackContext context)
    {
    
        lookInput = context.ReadValue<Vector2>();

        Debug.Log("Look input: " );
    }
    void Update()
    {

    
            // ---------- LOOK ----------
        float mouseX = lookInput.x * sensitivity;   // don’t multiply by deltaTime here
        float mouseY = lookInput.y * sensitivity;

        // rotate player left/right
        transform.Rotate(Vector3.up * mouseX);

        // vertical look (camera only)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        Debug.Log($"Look Input: {lookInput}");

      Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
      controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
