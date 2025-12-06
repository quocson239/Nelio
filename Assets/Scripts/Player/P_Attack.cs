using System.Collections;
using UnityEngine;

public class P_Attack : MonoBehaviour
{
    [SerializeField] GameObject stoneBullet;
    [SerializeField] GameObject firePos;
    [SerializeField] float fireForce;
    [SerializeField] GameObject A1Hit;
    [SerializeField] GameObject A2Hit;
    [SerializeField] GameObject JAHit;
    [SerializeField] GameObject hitGhost;

    [Header("----Sound----")]
    [SerializeField] AudioSource A12Sound;
    [SerializeField] AudioSource A3Sound;
    [SerializeField] AudioSource HitSound;
    [SerializeField] AudioSource RASound;

    public bool isAttack;

    bool isJA;
    bool isJRA;
    float timer1;
    float timer2;
    Vector2 direct;

    //Mission Condition
    public float c1 = 0;
    public float c2 = 0;
    public float c3 = 0;
    public float c4 = 0;


    [Header("Block Condition")]
    bool isJump;
    bool isGround;
    bool isDash;
    bool isBlock;

    Rigidbody2D rb;
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        isBlock = GetComponent<P_Block>().isBlock;
        isJump = GetComponent<P_Jump>().isJump;
        isGround = GetComponent<P_Jump>().isGround();
        isDash = GetComponent<P_Dash>().isDash;
        direct = (transform.localScale.x > 0) ? Vector2.right : Vector2.left;
        
        if (!isBlock)
        {
            
            if (!isDash)
            {
                if (!isJump)
                {
                    GroundAttack();
                }
                else
                {
                    JumpAttack();
                }
            }


            if (isGround)
            {
                isJA = false;
                isJRA = false;
            }
        }

        //Limit Mission Condition
        if (c1 > 5) c1 = 5;
        if (c2 > 5) c2 = 5;
        if (c3 > 5) c3 = 5;
        if (c4 > 5) c4 = 5;

    }

    void GroundAttack()
    {
        if (Input.GetMouseButtonDown(0) && !isAttack && Time.time >= timer1 + 2 / 3f && Time.time >= timer2 + 0.5f)
        {
            StartCoroutine(A1());
        }
        if (Input.GetMouseButtonDown(0) && !isAttack && Time.time < timer1 + 2 / 3f)
        {
            StartCoroutine(A2());
        }
        if (Input.GetMouseButtonDown(0) && !isAttack && Time.time < timer2 + 0.5f)
        {
            StartCoroutine(A3());
        }
        if (Input.GetMouseButtonDown(1) && !isAttack)
        {
            StartCoroutine(RA());
        }
    }

    void JumpAttack()
    {
        if (Input.GetMouseButtonDown(0) && !isAttack && !isJA)
        {
            StartCoroutine(JA());
        }
        if (Input.GetMouseButtonDown(1) && !isAttack && !isJRA)
        {
            StartCoroutine(JRA());
        }
    }



    IEnumerator A1()
    {
        timer1 = Time.time;
        isAttack = true;
        animator.SetTrigger("A1");
        rb.linearVelocity = Vector2.zero;
        A12Sound.Play();
        yield return new WaitForSeconds(0.5f / 3f);
        HitA1();
        yield return new WaitForSeconds(0.5f / 3f);
        isAttack = false;
    }
    IEnumerator A2()
    {
        timer2 = Time.time;
        isAttack = true;
        animator.SetTrigger("A2");
        rb.linearVelocity = Vector2.zero;
        A12Sound.Play();
        yield return new WaitForSeconds(0.5f / 3f);
        HitA2();
        yield return new WaitForSeconds(0.5f / 3f);
        isAttack = false;
    }
    IEnumerator A3()
    {        
        isAttack = true;
        animator.SetTrigger("A3");
        rb.linearVelocity = Vector2.zero;
        A3Sound.Play();
        yield return new WaitForSeconds(0.2f);
        HitA1();
        yield return new WaitForSeconds(0.3f);
        isAttack = false;
    }

    public IEnumerator RA()
    {        
        isAttack = true;
        animator.SetTrigger("RA");
        rb.linearVelocity = Vector2.zero;
        RASound.Play();
        yield return new WaitForSeconds(5 / 6f);
        SpawnStone();
        yield return new WaitForSeconds(1 / 6f);
        isAttack = false;
    }

    IEnumerator JA()
    {
        isAttack = true;
        isJA = true;
        animator.SetTrigger("JA");
        A3Sound.Play();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        HitJA();
        yield return new WaitForSeconds(0.5f);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        isAttack = false;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y - 0.01f);
    }

    IEnumerator JRA()
    {
        isAttack = true;
        isJRA = true;
        animator.SetTrigger("JRA");
        RASound.Play();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(5 / 6f);
        SpawnStone();
        yield return new WaitForSeconds(1 / 6f);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        isAttack = false;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y - 0.01f);
    }

    void SpawnStone()
    {
        GameObject s = Instantiate(stoneBullet, firePos.transform.position, Quaternion.identity);
        s.transform.localScale = (transform.localScale.x > 0) ? transform.localScale : new Vector3(-1, 1, 1);
        s.GetComponent<Rigidbody2D>().linearVelocity = direct * fireForce; 
    }

    void HitA1()
    {
        Collider2D[] enemies = Physics2D.OverlapCapsuleAll(A1Hit.transform.position, new Vector2(2, 1), CapsuleDirection2D.Horizontal, 0, LayerMask.GetMask("Enemy"));

        foreach (Collider2D c in enemies)
        {
            if (c.CompareTag("Enemy"))
            {
                HitSound.Play();
                StartCoroutine(c.GetComponent<EnemyHurt>().Hurt());
                /*GameObject h = Instantiate(hitGhost,
                    c.transform.position + (transform.position - c.transform.position).normalized * 0.25f + new Vector3(0, -0.15f, 0),
                    Quaternion.Euler(0, 0, Random.Range(60f, 270f)));*/
                GameObject h = Instantiate(hitGhost, new Vector3(c.transform.position.x, transform.position.y, 0),
                    Quaternion.Euler(0, 0, Random.Range(60f, 270f)));
                Destroy(h, 1 / 3f);
            }
            if (c.CompareTag("Dummy1"))
            {
                c1 += 1;
                if (transform.position.x < c.transform.position.x) c.GetComponent<Animator>().SetTrigger("HitL");
                else c.GetComponent<Animator>().SetTrigger("HitR");
                HitSound.Play();
                GameObject h = Instantiate(hitGhost,
                    c.transform.position + (transform.position - c.transform.position).normalized * 0.25f + new Vector3(0, 0.5f, 0),
                    Quaternion.Euler(0, 0, Random.Range(60f, 270f)));
                Destroy(h, 1 / 3f);
            }
            if (c.CompareTag("Fire") && !c.transform.Find("Fire").gameObject.activeSelf)
            {
                c.transform.Find("Fire").gameObject.SetActive(true);
                HitSound.Play();
                GameObject h = Instantiate(hitGhost,
                    c.transform.position + new Vector3(0, -0.5f, 0),
                    Quaternion.Euler(0, 0, Random.Range(60f, 270f)));
                Destroy(h, 1 / 3f);
            }
        }
    }
    void HitA2()
    {
        Collider2D[] enemies = Physics2D.OverlapCapsuleAll(A2Hit.transform.position, new Vector2(2, 1), CapsuleDirection2D.Horizontal, 0, LayerMask.GetMask("Enemy"));

        foreach (Collider2D c in enemies)
        {
            if (c.CompareTag("Enemy"))
            {                
                HitSound.Play();
                StartCoroutine(c.GetComponent<EnemyHurt>().Hurt());                
                GameObject h = Instantiate(hitGhost, new Vector3(c.transform.position.x, transform.position.y, 0),
                    Quaternion.Euler(0, 0, Random.Range(60f, 270f)));
                Destroy(h, 1 / 3f);
            }
            if (c.CompareTag("Dummy1"))
            {
                c1 += 1;
                if (transform.position.x < c.transform.position.x) c.GetComponent<Animator>().SetTrigger("HitL");
                else c.GetComponent<Animator>().SetTrigger("HitR");
                HitSound.Play();
                GameObject h = Instantiate(hitGhost,
                    c.transform.position + (transform.position - c.transform.position).normalized * 0.25f + new Vector3(0, 0.5f, 0),
                    Quaternion.Euler(0, 0, Random.Range(60f, 270f)));
                Destroy(h, 1 / 3f);
            }            
        }
    }
    void HitJA()
    {
        Collider2D[] enemies = Physics2D.OverlapCapsuleAll(JAHit.transform.position, new Vector2(2, 1), CapsuleDirection2D.Horizontal, 0, LayerMask.GetMask("Enemy"));

        foreach (Collider2D c in enemies)
        {
            if (c.CompareTag("Enemy"))
            {                
                HitSound.Play();
                StartCoroutine(c.GetComponent<EnemyHurt>().Hurt());
                GameObject h = Instantiate(hitGhost, new Vector3(c.transform.position.x, transform.position.y, 0),
                    Quaternion.Euler(0, 0, Random.Range(60f, 270f)));
                Destroy(h,1/3f);
            }
            if (c.CompareTag("Dummy1"))
            {
                c1 += 1;
                if (transform.position.x < c.transform.position.x) c.GetComponent<Animator>().SetTrigger("HitL");
                else c.GetComponent<Animator>().SetTrigger("HitR");
                HitSound.Play();
                GameObject h = Instantiate(hitGhost,
                    c.transform.position + (transform.position - c.transform.position).normalized * 0.25f + new Vector3(0, 0.8f, 0),
                    Quaternion.Euler(0, 0, Random.Range(60f, 270f)));
                Destroy(h, 1 / 3f);
            }
            if (c.CompareTag("Dummy2"))
            {
                c3 += 1;
                if (transform.position.x < c.transform.position.x) c.GetComponent<SpriteRenderer>().flipX = false;
                else c.GetComponent<SpriteRenderer>().flipX = true;                
                c.GetComponent<Animator>().SetTrigger("Hit");
                HitSound.Play();
                GameObject h = Instantiate(hitGhost,
                    c.transform.position + (transform.position - c.transform.position).normalized * 0.25f + new Vector3(0, 0, 0),
                    Quaternion.Euler(0, 0, Random.Range(60f, 270f)));
                Destroy(h, 1 / 3f);
            }
            if (c.CompareTag("Fire") && !c.transform.Find("Fire").gameObject.activeSelf)
            {
                c.transform.Find("Fire").gameObject.SetActive(true);
                HitSound.Play();
                GameObject h = Instantiate(hitGhost,
                    c.transform.position + new Vector3(0,-0.5f,0),
                    Quaternion.Euler(0, 0, Random.Range(60f, 270f)));
                Destroy(h, 1 / 3f);
            }
        }
    }
    
}
