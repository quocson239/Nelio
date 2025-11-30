using UnityEngine;

public class ShockwaveProjectile : MonoBehaviour
{
    public float moveSpeed = 8f; 
    public float lifetime = 3f;  
    private Vector3 direction;  

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
    }

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            P_Life player = other.GetComponent<P_Life>();
            player.hp--;
        }
    }
}