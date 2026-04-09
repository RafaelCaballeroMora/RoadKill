using UnityEngine;

public abstract class PowerupBehaviour : MonoBehaviour
{
    public float powerupSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        
    }
    
    public virtual void Update()
    {
        // Move along the chosen direction
        transform.position += Vector3.back.normalized * powerupSpeed * Time.deltaTime;
    }

    public abstract void BeConsumed(PlayerShoot playerHit);

    public abstract void BeHit();

    public void OnTriggerEnter(Collider other)
    {
        // Only react to bullets
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullets"))
        {   
            BeHit();
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("MainCharacter"))
        {
            PlayerShoot playerHit = other.gameObject.GetComponent<PlayerShoot>();
            BeConsumed(playerHit);
        }
    }
}
