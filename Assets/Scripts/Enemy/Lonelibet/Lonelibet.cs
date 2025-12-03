using System.Collections;
using UnityEngine;

public class Lonelibet : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    [SerializeField] GameObject hitboxA1;

    [Header("Audio")]
    [SerializeField] AudioSource barkingSound;
    [SerializeField] AudioSource attackSound;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public IEnumerator A1()
    {
        animator.SetTrigger("A1");
        attackSound.Play();
        yield return new WaitForSeconds(4/6f);
        HitA1();
        rb.linearVelocity = new Vector2(-transform.localScale.x * 3, 0);
        yield return new WaitForSeconds(1 / 6f);        
        yield return new WaitForSeconds(1 / 6f);


    }

    IEnumerator A2()
    {
        yield return null;
        
    }

    public void Bark()
    {
        barkingSound.Play();
    }

    void HitA1()
    {
        Collider2D[] enemies = Physics2D.OverlapCapsuleAll(hitboxA1.transform.position, new Vector2(2.9f, 1.85f), CapsuleDirection2D.Horizontal, 0,
            LayerMask.GetMask("Player"));

        foreach (Collider2D c in enemies)
        {
            if (c.CompareTag("Player") && !c.GetComponent<P_Dash>().isImmute)
            {
                StartCoroutine(c.GetComponent<P_Hurt>().Hurt());
            }
        }
    }
}
