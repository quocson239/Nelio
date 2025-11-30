using UnityEngine;

public class MinionProjectile : MonoBehaviour
{
    public float speed = 5f;          
    public int damageAmount = 1;     
    public float lifeTime = 5f;       

    private Vector3 targetDirection; 

    public void Initialize(Vector3 direction)
    {
        targetDirection = direction.normalized;
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += targetDirection * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {

            P_Life playerHealth = other.GetComponent<P_Life>();
            if (playerHealth != null)
            {
                playerHealth.hp--;
            }

            Debug.Log($"Đạn Quỷ con va chạm với Player, gây {damageAmount} sát thương.");
            Destroy(gameObject);
        }

    }
}