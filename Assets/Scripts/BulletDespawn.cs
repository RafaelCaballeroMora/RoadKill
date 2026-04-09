using UnityEngine;

public class BulletDespawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float maxDistance = 50f; // Distance from spawn before destruction

    private Vector3 spawnPosition;  // Remember where it started

    void Start()
    {
        spawnPosition = transform.position; // Record starting point
    }

    void Update()
    {
        // Check distance from spawn
        if (Vector3.Distance(spawnPosition, transform.position) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
