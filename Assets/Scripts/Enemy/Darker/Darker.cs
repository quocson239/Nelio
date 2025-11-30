using System.Collections;
using UnityEngine;

public class Darker : MonoBehaviour
{
    [SerializeField] GameObject nelio;    

    [Header("Darker Settings")]
    [SerializeField] float dashForce;
    [SerializeField] float jumpForce;
    [SerializeField] GameObject hitboxA1;
    [SerializeField] GameObject hitboxA2;


    Vector2 direct;

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;

    [Header("Darker Condition")]


    [Header("Darker Sounds")]
    [SerializeField] AudioSource walkSound;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        StartCoroutine(Test());
    }

    void Update()
    {
        direct = (transform.localScale.x > 0) ? Vector2.right : Vector2.left;        
    }

    IEnumerator Test()
    {
        transform.localScale = new Vector3(-1, 1, 1);
        rb.gravityScale = 0;
        rb.linearVelocity = new Vector2(-1f, 0f);
        animator.SetBool("isRun", true);
        yield return new WaitForSeconds(2f);
        rb.linearVelocity = Vector2.zero;
        animator.SetBool("isRun", false);
        StartCoroutine(A1());
        yield return new WaitForSeconds(2f);
        StartCoroutine(A2());
    }

    IEnumerator A1()
    {
        animator.SetTrigger("A1");
        yield return new WaitForSeconds(5f / 6f);
        rb.AddForce(direct * dashForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1 / 6f);
        HitA1();
        rb.gravityScale = 1f;
        rb.linearVelocity = Vector2.zero;
    }


    IEnumerator A2()
    {
        animator.SetTrigger("A2");
        yield return new WaitForSeconds(5f / 6f);
        rb.AddForce(direct * dashForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1 / 6f);
        HitA1();
        rb.gravityScale = 1f;
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
        HitA2();
    }

    public IEnumerator Jump()
    {        
        animator.SetTrigger("Jump");
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        yield return new WaitForSeconds(0.02f);        
    }

    void HitA1()
    {
        Collider2D[] enemies = Physics2D.OverlapCapsuleAll(hitboxA1.transform.position, new Vector2(8, 1), CapsuleDirection2D.Horizontal, 0,
            LayerMask.GetMask("Player"));

        foreach (Collider2D c in enemies)
        {
            if (c.CompareTag("Player") && !c.GetComponent<P_Dash>().isImmute)
            {
                StartCoroutine(c.GetComponent<P_Hurt>().Hurt());
            }

        }
    }
    void HitA2()
    {
        Collider2D[] enemies = Physics2D.OverlapCapsuleAll(hitboxA2.transform.position, new Vector2(4.5f, 2f), CapsuleDirection2D.Horizontal, 0,
            LayerMask.GetMask("Player"));

        foreach (Collider2D c in enemies)
        {
            if (c.CompareTag("Player") && !c.GetComponent<P_Dash>().isImmute)
            {
                StartCoroutine(c.GetComponent<P_Hurt>().Hurt());
            }

        }
    }    

    private void OnDrawGizmos()
    {
        
    }
}
