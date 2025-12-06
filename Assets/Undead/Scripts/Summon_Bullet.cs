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

    void OnTriggerEnter2D(Collider2D c) 
    {
        if (c.CompareTag("Player") && !c.GetComponent<P_Dash>().isImmute)
        {

            StartCoroutine(c.GetComponent<P_Hurt>().Hurt());
            
        }

    }
}