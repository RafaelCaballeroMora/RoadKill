using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float bulletSpeed = 5f;   // default speed
    public float coneAngleX = 15f;      // max deviation angle from forward in degrees
    public float coneAngleY = 15f;      // max deviation angle from forward in degrees
    public float coneDuration = 0.2f;
    private Vector3 startingMoveDirection;     // current movement direction
    private Vector3 straightDirection; // final straight direction
    private float elapsedTime=0f;

    public float bulletDamage = 1f;

    void Start()
    {

        float angleX = Random.Range(-coneAngleX, coneAngleX);
        float angleY = Random.Range(-coneAngleY, coneAngleY); // optional for Y axis

        Quaternion randomRotation = Quaternion.Euler(angleY, angleX, 0);
        startingMoveDirection = randomRotation * transform.forward;
        straightDirection=transform.forward;

        Rigidbody rb = GetComponent<Rigidbody>();
        //start moving in a cone
        if (rb != null)
        {
            rb.useGravity = false;
            rb.linearVelocity = startingMoveDirection * bulletSpeed;
        }
    }

    void Update()
    {

        elapsedTime += Time.deltaTime;
        //Start moving straight after a bit of time
        if (elapsedTime >= coneDuration)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = straightDirection * bulletSpeed;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Only react to enemies
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {   
            EnemyBehaviour enemy = other.gameObject.GetComponent<EnemyBehaviour>();
            enemy.TakeDamage(bulletDamage);  // Damage enemy
            Destroy(gameObject);        // Destroy bullet
        }
    }
}
