using System.Collections;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float enemySpeed = 10f;
    public float fadeDuration = 0.5f;
    private Renderer rend;
    private Color originalColor;

    public float enemyHealth = 1f;
    

    void Awake()
    {
        
        rend = GetComponent<Renderer>();
        if (rend != null)
        {
            originalColor = rend.material.color; // <-- store the enemy's starting color
        }
    }   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        // Move along the chosen direction
        transform.position += Vector3.back.normalized * enemySpeed * Time.deltaTime;
    }

    public virtual void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        if(enemyHealth <= 0f) Die();
    }

    public virtual void Die()
    {
        enemySpeed=0;
        StartCoroutine(FlashAndDestroy());
    }

    private IEnumerator FlashAndDestroy()
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;

            // Lerp from original color to white over time
            rend.material.color = Color.Lerp(originalColor, Color.white, elapsed / fadeDuration);

            yield return null; // wait for next frame
        }

        // optional: restore color (not needed if destroying)
        // rend.material.color = originalColor;

        // destroy the enemy
        Destroy(gameObject);
    }
}
