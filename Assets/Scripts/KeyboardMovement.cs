using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KeyboardMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = 0;//Input.GetAxis("Vertical");

        // Keep current vertical velocity (gravity)
        Vector3 velocity = new Vector3(moveX * speed, rb.linearVelocity.y, moveZ * speed);

        rb.linearVelocity = velocity;
    }
}