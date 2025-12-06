using System.Collections;
using UnityEngine;

public class Darker : MonoBehaviour
{
    [SerializeField] GameObject nelio;
    [SerializeField] GameObject d_teleport;
    [SerializeField] GameObject d_teleport2;
    [SerializeField] GameObject d_bullet;
    [SerializeField] GameObject firePos;
    [SerializeField] GameObject d_stand;

    [Header("Darker Settings")]
    [SerializeField] float dashForce;
    [SerializeField] float jumpForce;
    [SerializeField] GameObject hitboxA1;
    [SerializeField] GameObject hitboxA2;


    bool isAction;
    bool isInCombo;
    bool doneSpecial = true;
    Vector2 direct;
    float checkDis;
    bool isDead;
    float hp;

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;

    [Header("Darker Condition")]


    [Header("Darker Sounds")]
    [SerializeField] AudioSource lightningSound;
    [SerializeField] AudioSource darkerTeleSound;
    [SerializeField] AudioSource slashSound;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        StartCoroutine(StartSpecial());
    }

    void Update()
    {
        isDead = GetComponent<EnemyLife>().isDead;
        hp = GetComponent<EnemyLife>().hp;
        if (!isDead && nelio.GetComponent<P_Life>().hp > 0)
        {
            direct = (transform.localScale.x > 0) ? Vector2.right : Vector2.left;
            checkDis = Mathf.Abs(transform.position.x - nelio.transform.position.x);

            if (checkDis > 6 && !isAction && !isInCombo && doneSpecial)
            {
                if (hp > 15) StartCoroutine(Walk(6));
                if (hp <= 15) StartCoroutine(Teleport());
            }
            if (checkDis <= 6 && checkDis >= 3 && !isAction && !isInCombo && doneSpecial)
            {
                if (hp > 15) StartCoroutine(Combo1());
                if (hp <= 15) StartCoroutine(Combo3());
            }
            if (checkDis < 3 && !isAction && !isInCombo && doneSpecial)
            {
                StartCoroutine(Combo2());
            }
            
            if (!isAction)
            {
                Flip();
            }

            animator.SetBool("isFall", rb.linearVelocity.y < 0);
        }
        else
        {
            StartCoroutine(StopCo());
            rb.linearVelocity = Vector2.zero;
            animator.SetBool("isRun", false);
        }
    }

    IEnumerator StopCo()
    {
        yield return new WaitForSeconds(0.5f);
        StopAllCoroutines();
    }
    IEnumerator Combo1()
    {
        isInCombo = true;
        yield return new WaitForSeconds(0.25f);
        yield return StartCoroutine(A1());
        yield return new WaitForSeconds(0.25f);
        yield return StartCoroutine(A1());
        yield return new WaitForSeconds(0.25f);
        yield return StartCoroutine(A2());
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(RA1());
        yield return new WaitForSeconds(2f);
        isInCombo = false;
    }

    IEnumerator Combo2()
    {
        isInCombo = true;
        yield return StartCoroutine(A3());
        yield return new WaitForSeconds(0.25f);
        yield return StartCoroutine(A1());
        yield return new WaitForSeconds(0.25f);
        yield return StartCoroutine(RA1());
        yield return new WaitForSeconds(0.25f);
        yield return StartCoroutine(A2());
        yield return new WaitForSeconds(2f);
        isInCombo = false;
    }

    IEnumerator Combo3()
    {
        isInCombo = true;
        yield return StartCoroutine(Teleport());
        yield return new WaitForSeconds(0.25f);
        yield return StartCoroutine(A1());
        yield return new WaitForSeconds(0.25f);
        yield return StartCoroutine(RA1());
        yield return new WaitForSeconds(0.25f);
        yield return StartCoroutine(Teleport());
        yield return new WaitForSeconds(0.25f);
        yield return StartCoroutine(A2());
        yield return new WaitForSeconds(0.25f);
        yield return StartCoroutine(RA1());
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(A1());
        isInCombo = false;
    }

    IEnumerator StartSpecial()
    {
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => hp <= 15);
        doneSpecial = false;
        yield return new WaitUntil(() => hp <= 15 && !isInCombo && !isAction);
        yield return StartCoroutine(RA2());
        doneSpecial = true;
        yield return new WaitUntil(() => hp <= 10);
        doneSpecial = false;
        yield return new WaitUntil(() => hp <= 10 && !isInCombo && !isAction);
        yield return StartCoroutine(RA3());
        doneSpecial = true;
        yield return new WaitUntil(() => hp <= 5);
        doneSpecial = false;
        yield return new WaitUntil(() => hp <= 5 && !isInCombo && !isAction);
        yield return StartCoroutine(RA4());
        doneSpecial = true;
    }

    void Flip()
    {
        if (nelio == null) return;
        if (nelio.transform.position.x < transform.position.x) { transform.localScale = new Vector3(-1, 1, 1); }
        if (nelio.transform.position.x > transform.position.x) { transform.localScale = new Vector3(1, 1, 1); }
    }

    IEnumerator Walk(float dis)
    {
        yield return new WaitForSeconds(0.25f);
        isAction = true;
        rb.gravityScale = 0;
        rb.linearVelocity = direct;
        animator.SetBool("isRun", true);
        yield return new WaitUntil(() => checkDis <= dis);
        rb.linearVelocity = Vector2.zero;
        animator.SetBool("isRun", false);
        isAction = false;
    }

    IEnumerator A1()
    {
        isAction = true;
        animator.SetTrigger("A1");
        yield return new WaitForSeconds(5f / 6f);
        rb.AddForce(direct * dashForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1 / 6f);
        slashSound.Play();
        HitA1();
        rb.gravityScale = 1f;
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(0.5f);
        isAction = false;
    }


    IEnumerator A2()
    {
        isAction = true;
        animator.SetTrigger("A2");
        yield return new WaitForSeconds(5f / 6f);
        rb.AddForce(direct * dashForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1 / 6f);
        slashSound.Play();
        HitA1();
        rb.gravityScale = 1f;
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(2 / 3f);
        slashSound.Play();
        HitA2();
        yield return new WaitForSeconds(0.5f);
        isAction = false;
    }
    IEnumerator A3()
    {
        isAction = true;
        animator.SetTrigger("A3");
        yield return new WaitForSeconds(0.5f);
        slashSound.Play();
        HitA2();
        yield return new WaitForSeconds(0.5f);
        isAction = false;
    }

    IEnumerator RA1()
    {
        isAction = true;
        animator.SetTrigger("RA1");
        yield return new WaitForSeconds(2 / 3f);
        GameObject d = Instantiate(d_bullet, firePos.transform.position, Quaternion.Euler(0, 0, transform.localScale.x > 0 ? 206 : 27));
        yield return new WaitForSeconds(1 / 3f);
        d.GetComponent<PolygonCollider2D>().enabled = true;
        lightningSound.Play();
        yield return new WaitForSeconds(1 / 6f);
        Destroy(d, 0.5f);
        yield return new WaitForSeconds(0.5f);
        isAction = false;
    }

    IEnumerator RA2()
    {
        isAction = true;
        isInCombo = true;
        rb.gravityScale = 0f;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        transform.Find("Light").gameObject.SetActive(false);
        GameObject d = Instantiate(d_teleport, transform.position, Quaternion.identity);
        Destroy(d, 1 / 3f);
        GameObject d2 = Instantiate(d_teleport2, d_stand.transform.position, Quaternion.identity);
        Destroy(d2, 0.5f);
        yield return new WaitForSeconds(1 / 3f + 0.1f);
        d_stand.SetActive(true);
        yield return StartCoroutine(spawnLightning1());
        yield return StartCoroutine(spawnLightning1());
        yield return StartCoroutine(spawnLightning1());
        yield return StartCoroutine(spawnLightning1());
        yield return StartCoroutine(spawnLightning1());
        d_stand.SetActive(false);
        GameObject d3 = Instantiate(d_teleport, d_stand.transform.position, Quaternion.identity);
        Destroy(d3, 1 / 3f);
        GameObject d4 = Instantiate(d_teleport2, transform.position, Quaternion.identity);
        Destroy(d4, 0.5f);
        yield return new WaitForSeconds(1 / 3f + 0.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        transform.Find("Light").gameObject.SetActive(true);
        rb.gravityScale = 1f;
        yield return new WaitForSeconds(1f);
        isAction = false;
        isInCombo = false;
    }
    IEnumerator RA3()
    {
        isAction = true;
        isInCombo = true;
        rb.gravityScale = 0f;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        transform.Find("Light").gameObject.SetActive(false);
        GameObject d = Instantiate(d_teleport, transform.position, Quaternion.identity);
        Destroy(d, 1 / 3f);
        GameObject d2 = Instantiate(d_teleport2, d_stand.transform.position, Quaternion.identity);
        Destroy(d2, 0.5f);
        yield return new WaitForSeconds(1 / 3f + 0.1f);
        d_stand.SetActive(true);
        yield return StartCoroutine(spawnLightning3());
        yield return StartCoroutine(spawnLightning3());
        yield return StartCoroutine(spawnLightning3());
        yield return StartCoroutine(spawnLightning3());
        yield return StartCoroutine(spawnLightning3());
        d_stand.SetActive(false);
        GameObject d3 = Instantiate(d_teleport, d_stand.transform.position, Quaternion.identity);
        Destroy(d3, 1 / 3f);
        GameObject d4 = Instantiate(d_teleport2, transform.position, Quaternion.identity);
        Destroy(d4, 0.5f);
        yield return new WaitForSeconds(1 / 3f + 0.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        transform.Find("Light").gameObject.SetActive(true);
        rb.gravityScale = 1f;
        yield return new WaitForSeconds(1f);
        isAction = false;
        isInCombo = false;
    }
    IEnumerator RA4()
    {
        isAction = true;
        isInCombo = true;
        rb.gravityScale = 0f;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        transform.Find("Light").gameObject.SetActive(false);
        GameObject d = Instantiate(d_teleport, transform.position, Quaternion.identity);
        Destroy(d, 1 / 3f);
        GameObject d2 = Instantiate(d_teleport2, d_stand.transform.position, Quaternion.identity);
        Destroy(d2, 0.5f);
        yield return new WaitForSeconds(1 / 3f + 0.1f);
        d_stand.SetActive(true);
        yield return StartCoroutine(spawnLightning5());
        yield return StartCoroutine(spawnLightning5());
        yield return StartCoroutine(spawnLightning5());
        yield return StartCoroutine(spawnLightning5());
        yield return StartCoroutine(spawnLightning5());
        d_stand.SetActive(false);
        GameObject d3 = Instantiate(d_teleport, d_stand.transform.position, Quaternion.identity);
        Destroy(d3, 1 / 3f);
        GameObject d4 = Instantiate(d_teleport2, transform.position, Quaternion.identity);
        Destroy(d4, 0.5f);
        yield return new WaitForSeconds(1 / 3f + 0.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        transform.Find("Light").gameObject.SetActive(true);
        rb.gravityScale = 1f;
        yield return new WaitForSeconds(1f);
        isAction = false;
        isInCombo = false;
    }

    IEnumerator spawnLightning1()
    {
        yield return new WaitForSeconds(2 / 3f);
        GameObject d = Instantiate(d_bullet, new Vector3(nelio.transform.position.x, 2.5f, 0), Quaternion.Euler(0, 0, 115));
        yield return new WaitForSeconds(1 / 3f);
        d.GetComponent<PolygonCollider2D>().enabled = true;
        lightningSound.Play();
        yield return new WaitForSeconds(1 / 6f);
        Destroy(d, 0.5f);
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator spawnLightning3()
    {
        yield return new WaitForSeconds(2 / 3f);
        GameObject d = Instantiate(d_bullet, new Vector3(nelio.transform.position.x, 2.5f, 0), Quaternion.Euler(0, 0, 115));
        GameObject d1 = Instantiate(d_bullet, new Vector3(nelio.transform.position.x + 3f, 2.5f, 0), Quaternion.Euler(0, 0, 115));
        GameObject d2 = Instantiate(d_bullet, new Vector3(nelio.transform.position.x - 3f, 2.5f, 0), Quaternion.Euler(0, 0, 115));
        yield return new WaitForSeconds(1 / 3f);
        d.GetComponent<PolygonCollider2D>().enabled = true;
        lightningSound.Play();
        yield return new WaitForSeconds(1 / 6f);
        Destroy(d, 0.5f);
        Destroy(d1, 0.5f);
        Destroy(d2, 0.5f);
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator spawnLightning5()
    {
        yield return new WaitForSeconds(2 / 3f);
        GameObject d = Instantiate(d_bullet, new Vector3(nelio.transform.position.x, 2.5f, 0), Quaternion.Euler(0, 0, 115));
        GameObject d1 = Instantiate(d_bullet, new Vector3(nelio.transform.position.x + 2.5f, 2.5f, 0), Quaternion.Euler(0, 0, 115));
        GameObject d2 = Instantiate(d_bullet, new Vector3(nelio.transform.position.x - 2.5f, 2.5f, 0), Quaternion.Euler(0, 0, 115));
        GameObject d3 = Instantiate(d_bullet, new Vector3(nelio.transform.position.x + 5f, 2.5f, 0), Quaternion.Euler(0, 0, 115));
        GameObject d4 = Instantiate(d_bullet, new Vector3(nelio.transform.position.x - 5f, 2.5f, 0), Quaternion.Euler(0, 0, 115));
        yield return new WaitForSeconds(1 / 3f);
        d.GetComponent<PolygonCollider2D>().enabled = true;
        lightningSound.Play();
        yield return new WaitForSeconds(1 / 6f);
        Destroy(d, 0.5f);
        Destroy(d1, 0.5f);
        Destroy(d2, 0.5f);
        Destroy(d3, 0.5f);
        Destroy(d4, 0.5f);
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator Jump()
    {
        animator.SetTrigger("Jump");
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        yield return null;
    }

    IEnumerator Teleport()
    {
        isAction = true;
        animator.SetTrigger("Jump");
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        yield return new WaitForSeconds(0.5f);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<SpriteRenderer>().enabled = false;
        darkerTeleSound.Play();
        GameObject d = Instantiate(d_teleport, transform.position, Quaternion.identity);
        Destroy(d, 1 / 3f);
        transform.position = nelio.transform.position + new Vector3(0, 2f, 0);
        yield return new WaitForSeconds(1 / 3f);
        darkerTeleSound.Play();
        GameObject d2 = Instantiate(d_teleport2, transform.position, Quaternion.identity);
        Destroy(d2, 0.5f);
        yield return new WaitForSeconds(1 / 3f);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.linearVelocity = new Vector2(0, -2f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(1 / 3f);
        rb.gravityScale = 1f;
        Flip();
        yield return StartCoroutine(A3());
        isAction = false;
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
