using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public GameObject enemyPrefab;   // Enemy prefab to spawn
    [Header("Spawn Area")]
    public Vector3 spawnAreaSize = new Vector3(5f, 0f, 5f); // editable in Inspector
    public float spawnDelay = 1f;    // Time between spawns (seconds)

    private float timer = 0f;

    void Start()
    {
        GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (enemyPrefab == null) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnEnemy();
            timer = spawnDelay;  // reset timer
        }
    }

    void SpawnEnemy()
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            0,
            0
        );
        Vector3 spawnPosition = transform.position + randomOffset;
        Instantiate(enemyPrefab, spawnPosition, transform.rotation);
    }

    // Draw spawn area in the editor
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f); // semi-transparent green
        Gizmos.DrawCube(transform.position, spawnAreaSize);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
