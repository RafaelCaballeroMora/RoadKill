using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour_Boss : EnemyBehaviour
{
    public float maxHealth = 5f;
    public GameObject healthBarPrefab; // assign prefab in Inspector
    private HealthBarScript healthBar; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        if (healthBarPrefab == null)
            Debug.LogError("HealthBar prefab is null! Did you assign the prefab asset?");
        enemyHealth=5f;
        enemySpeed=5f;
        InstantiateHealthBar();
    }
    
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        if(enemyHealth < maxHealth) {
            healthBar.SetHealth(enemyHealth, maxHealth);
            healthBar.Show(true);
        }
    }

    public override void Die()
    {
        Destroy(healthBar.gameObject, fadeDuration);
        base.Die();
    }

    private void InstantiateHealthBar()
    {
        // Instantiate the health bar
        GameObject hbObj = Instantiate(healthBarPrefab);
        healthBar = hbObj.GetComponent<HealthBarScript>();

        // Make it follow this enemy
        healthBar.SetTarget(transform);
        healthBar.SetHealth(enemyHealth, maxHealth);
        healthBar.Show(false); // hide until damaged
    }
}
