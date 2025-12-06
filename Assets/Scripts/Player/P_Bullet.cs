using UnityEngine;

public class P_Bullet : MonoBehaviour
{
    [SerializeField] GameObject hitGhost;

    Rigidbody2D rb;

    GameObject nelio;
    float c2;
    float c4;


    [Header("----Sound----")]    
    [SerializeField] AudioSource HitSound;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nelio = GameObject.Find("Nelio");
    }
    
    void Update()
    {
                
    }
    private void OnTriggerEnter2D(Collider2D c)
    {                
        if (c.CompareTag("Enemy"))
        {
            HitSound.Play();
            StartCoroutine(c.GetComponent<EnemyHurt>().Hurt());
            GameObject h = Instantiate(hitGhost, new Vector3(c.transform.position.x, nelio.transform.position.y, 0),
                    Quaternion.Euler(0, 0, Random.Range(60f, 270f)));
            Destroy(h, 1 / 3f);
            transform.localScale = Vector3.zero;
            rb.linearVelocity = Vector2.zero;
            Destroy(this.gameObject, 0.5f);
        }
        if (c.CompareTag("Dummy1"))
        {
            if (nelio != null)
            {
                nelio.GetComponent<P_Attack>().c2 += 1;
            }
            if (transform.position.x < c.transform.position.x) c.GetComponent<Animator>().SetTrigger("HitL");
            else c.GetComponent<Animator>().SetTrigger("HitR");
            HitSound.Play();            
            GameObject h = Instantiate(hitGhost,
                c.transform.position + (transform.position - c.transform.position).normalized * 0.25f + new Vector3(0, 0.5f, 0),
                Quaternion.Euler(0, 0, Random.Range(60f, 270f)));
            Destroy(h, 1 / 3f);            
            transform.localScale = Vector3.zero;
            rb.linearVelocity = Vector2.zero;
            Destroy(this.gameObject, 0.5f);
        }
        if (c.CompareTag("Dummy2"))
        {
            if (nelio != null)
            {
                nelio.GetComponent<P_Attack>().c4 += 1;
            }
            if (transform.position.x < c.transform.position.x) c.GetComponent<SpriteRenderer>().flipX = false;
            else c.GetComponent<SpriteRenderer>().flipX = true;
            c.GetComponent<Animator>().SetTrigger("Hit");
            HitSound.Play();            
            GameObject h = Instantiate(hitGhost,
                c.transform.position + (transform.position - c.transform.position).normalized * 0.25f + new Vector3(0, 0, 0),
                Quaternion.Euler(0, 0, Random.Range(60f, 270f)));
            Destroy(h, 1 / 3f);
            transform.localScale = Vector3.zero;
            rb.linearVelocity = Vector2.zero;
            Destroy(this.gameObject, 0.5f);
        }        
    }
}
