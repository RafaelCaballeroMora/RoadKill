using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Drag your Bullet prefab here
    public Transform shootPoint;    // Where bullets originate

    public float bulletsPerSecond = 10f; 
    public float bulletsPerSecondCap = 100f;

    private float shootTimer = 0f;

    void Update()
    {
        if (bulletPrefab == null || shootPoint == null)
            return;

        // Countdown timer
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            Shoot();
            shootTimer = CalculateDelay(); // reset timer
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || shootPoint == null)
            return;

        // Instantiate bullet at shootPoint position and rotation
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

    }

    private float CalculateDelay()
    {
        return 1/bulletsPerSecond;
    }

    internal void PowerUp(string v, float delta)
    {
        switch (v)
        {
            case "AttackSpeed": 
                bulletsPerSecond = Math.Min(bulletsPerSecond + delta, bulletsPerSecondCap);
                return;
            default:
                return;
        }
    }
}