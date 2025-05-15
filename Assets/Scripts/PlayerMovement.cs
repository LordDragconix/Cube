using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintMultiplier = 1.5f;
    public float rotationSpeed = 720f;

    private Quaternion targetRotation;

    void Start()
    {
        targetRotation = transform.rotation;
    }

    void Update()
    {
        HandleRotationInput();
        HandleMovementInput();
        SmoothRotate();
    }

    void HandleRotationInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            targetRotation *= Quaternion.Euler(0, -90, 0);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            targetRotation *= Quaternion.Euler(0, 90, 0);
        }
    }

    void HandleMovementInput()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            moveDirection += transform.forward;
        if (Input.GetKey(KeyCode.A))
            moveDirection -= transform.right;
        if (Input.GetKey(KeyCode.D))
            moveDirection += transform.right;

        float currentSpeed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            currentSpeed *= sprintMultiplier;

        transform.position += moveDirection.normalized * currentSpeed * Time.deltaTime;
    }

    void SmoothRotate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
