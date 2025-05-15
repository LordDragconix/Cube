using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float launchForce = 10f; // Adjust in Inspector

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Zero out vertical velocity first, then add upward force
                Vector3 velocity = rb.linearVelocity;
                velocity.y = 0;
                rb.linearVelocity = velocity;

                rb.AddForce(Vector3.up * launchForce, ForceMode.VelocityChange);
            }
        }
    }
}
