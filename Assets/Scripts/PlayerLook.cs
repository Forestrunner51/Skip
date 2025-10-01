using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [Header("References")]
    public Transform playerBody; // your character's body (the part that rotates left/right)

    [Header("Settings")]
    public float mouseSensitivity = 100f;
    public InputActionReference lookAction; // drag your Look action here

    private float xRotation = 0f;

    private void OnEnable()
    {
        lookAction.action.Enable();
    }

    private void OnDisable()
    {
        lookAction.action.Disable();
    }

    void Update()
    {
        // Read the mouse movement from Input System
        Vector2 lookInput = lookAction.action.ReadValue<Vector2>();

        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        // Vertical rotation (clamped so camera doesn’t flip)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Horizontal rotation (turns the body)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
