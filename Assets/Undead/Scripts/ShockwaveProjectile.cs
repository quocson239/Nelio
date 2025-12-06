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

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player") && !c.GetComponent<P_Dash>().isImmute)
        {
            StartCoroutine(c.GetComponent<P_Hurt>().Hurt());
        }
    }
}