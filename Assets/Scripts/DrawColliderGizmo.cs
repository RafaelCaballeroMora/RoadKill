using UnityEngine;

[ExecuteAlways]
public class DrawColliderGizmo : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Collider col = GetComponent<Collider>();
        if (col == null) return;

        // Draw wireframe around the collider bounds
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(col.bounds.center, col.bounds.size);
    }
}