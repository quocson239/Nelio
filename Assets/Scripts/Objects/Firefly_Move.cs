using UnityEngine;

public class Firefly_Move : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    Vector2 direct;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direct = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
    
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bottle")
        {
            rb.linearVelocity = direct * speed;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bottle")
        {      
            direct = -direct;
            rb.linearVelocity = direct * speed;
            direct = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }
    }
}
