using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCamera : MonoBehaviour
{
    [Header("Parámetros")]
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private float xRotation = 0f;

    PlayerInput input;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        input = GetComponentInParent<PlayerInput>();
    }
    void Update()
    {
        Vector2 mouseMovement = input.actions["Look"].ReadValue<Vector2>() * sensitivity;

        xRotation -= mouseMovement.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.parent.Rotate(Vector3.up * mouseMovement.x);
    }
}
