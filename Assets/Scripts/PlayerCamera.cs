using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;        // assign the Player GameObject
    public Vector3 offset = new Vector3(0, 8, -10); // camera behind player
    public Vector3 lookAtOffset = new Vector3(0, 2f, 0); // look slightly above player
    public float smoothSpeed = 5f;  // smoothing for movement

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPos = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);

        transform.LookAt(player.position + lookAtOffset); // makes camera look at player
    }
}