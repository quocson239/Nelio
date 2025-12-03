using System.Collections;
using UnityEngine;

public class Scarlet_Attack : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject firePos;
    [SerializeField] float arrowSpeed;
    [SerializeField] GameObject hitboxA1;
    [SerializeField] GameObject hitboxA2;
    [SerializeField] GameObject hitboxA3;
    [SerializeField] GameObject nelio;
    [SerializeField] GameObject willon;
    Rigidbody2D rb;
    Animator anim;

    [SerializeField] float jumpForce;
    [SerializeField] float jumpRange;

    bool isAction;
    bool isInCombo;
    Vector2 direct;
    float checkDis;
    bool isDead;
    bool isTriggerDead;
    float hp;
    float numAction;

    public bool isBattle;
    Vector2 direct2;

    float willonCD;
    float walkCD;

    [Header("Sounds")]
    [SerializeField] AudioSource BowSound;
    [SerializeField] AudioSource SlashSound;
    [SerializeField] AudioSource HitGroundSound;
    [SerializeField] AudioSource WhistleSound;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        InvokeRepeating("RollAction", 0f, 1f);
    }

    void Update()
    {
        direct = (transform.localScale.x > 0) ? Vector2.left : Vector2.right;
        if (GetComponent<EnemyLife>() != null) isDead = GetComponent<EnemyLife>().isDead;
        if (GetComponent<EnemyLife>() != null) hp = GetComponent<EnemyLife>().hp;
        if (!isDead && nelio.GetComponent<P_Life>().hp > 0 && isBattle)
        {
            direct = (transform.localScale.x > 0) ? Vector2.left : Vector2.right;
            checkDis = Mathf.Abs(transform.position.x - nelio.transform.position.x);
            Debug.Log("Distance to Nelio: " + checkDis);

            if (checkDis > 5 && !isAction && !isInCombo)
            {
                if (numAction <= 1f) StartCoroutine(Walk(5));
                if (numAction > 1.5f)
                {
                    if (Time.time >= willonCD + 10) StartCoroutine(SummonWillon());
                    else StartCoroutine(RA());
                }
            }
            if (checkDis <= 5 && checkDis > 2.5 && !isAction && !isInCombo)
            {
                if (numAction <= 1.5f) StartCoroutine(A5());
                if (numAction > 1.5f)
                {
                    if (Time.time >= willonCD + 10) StartCoroutine(SummonWillon());
                    else StartCoroutine(Walk(2.5f));
                }

            }
            if (checkDis <= 2.5 && !isAction && !isInCombo)
            {
                if (numAction <= 1.5f)
                {
                    if (hp > 10) StartCoroutine(Combo1());
                    else if (hp <= 10) StartCoroutine(Combo3());
                }
                if (numAction > 1.5f) StartCoroutine(Combo2());
            }
        }
        else if (isBattle)
        {
            StartCoroutine(StopCo());
            rb.linearVelocity = Vector2.zero;
            anim.SetBool("isRun", false);
        }
        if (!isTriggerDead && hp <= 0 && isBattle)
        {
            isTriggerDead = true;
            anim.SetBool("isLying", true);
            transform.localScale = new Vector3((transform.position.x > nelio.transform.position.x) ? 1 : -1, 1, 1);
        }

        //Test
        if (!isInCombo && Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(Combo1());
        }
        if (!isInCombo && Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(Combo2());
        }
        if (!isInCombo && Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(Combo3());
        }
        if (!isInCombo && Input.GetKeyDown(KeyCode.Alpha4) && !isAction)
        {
            StartCoroutine(SummonWillon());
        }


        if (!isAction && isBattle)
        {
            Flip();
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
        yield return StartCoroutine(A1());
        yield return StartCoroutine(A2());
        yield return new WaitForSeconds(1f);
        isInCombo = false;
    }
    IEnumerator Combo2()
    {
        isInCombo = true;
        yield return StartCoroutine(A3());
        yield return StartCoroutine(A4());
        yield return StartCoroutine(A5());
        yield return new WaitForSeconds(1f);
        isInCombo = false;
    }
    IEnumerator Combo3()
    {
        isInCombo = true;
        yield return StartCoroutine(A2());
        yield return StartCoroutine(A2());
        yield return StartCoroutine(A2());
        yield return StartCoroutine(A1());
        yield return StartCoroutine(A5());
        yield return new WaitForSeconds(1f);
        isInCombo = false;
    }

    void RollAction()
    {
        numAction = Random.Range(0f, 3f);
    }


    IEnumerator Walk(float dis)
    {
        isAction = true;
        walkCD = Time.time;
        rb.gravityScale = 0;
        rb.linearVelocity = direct * 2;
        anim.SetBool("isRun", true);
        yield return new WaitUntil(() => checkDis <= dis || Time.time >= walkCD + 3f);
        rb.linearVelocity = Vector2.zero;
        anim.SetBool("isRun", false);
        isAction = false;
        yield return new WaitForSeconds(0.2f);
    }


    IEnumerator SummonWillon()
    {
        isAction = true;
        willonCD = Time.time;
        direct2 = (willon.transform.localScale.x > 0) ? Vector2.left : Vector2.right;
        WhistleSound.Play();
        yield return new WaitForSeconds(0.2f);
        willon.GetComponent<Lonelibet>().Bark();
        yield return new WaitForSeconds(0.2f);
        willon.GetComponent<Lonelibet>().Bark();
        yield return StartCoroutine(WillonAttack());
        if (willon.transform.localScale.x > 0)
        {
            willon.GetComponent<Rigidbody2D>().gravityScale = 0;
            willon.GetComponent<Rigidbody2D>().linearVelocity = Vector2.left * 3;
            willon.GetComponent<Animator>().SetBool("isRun", true);
            yield return new WaitUntil(() => willon.transform.position.x <= 84.5f);
            willon.GetComponent<Animator>().SetBool("isRun", false);
            willon.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            willon.GetComponent<Rigidbody2D>().gravityScale = 1;
            yield return new WaitForSeconds(0.5f);
            willon.transform.localScale = new Vector3(-willon.transform.localScale.x, 1, 1);
            isAction = false;
        }
        else
        {
            willon.GetComponent<Rigidbody2D>().gravityScale = 0;
            willon.GetComponent<Rigidbody2D>().linearVelocity = Vector2.right * 3;
            willon.GetComponent<Animator>().SetBool("isRun", true);
            yield return new WaitUntil(() => willon.transform.position.x >= 99.5f);
            willon.GetComponent<Animator>().SetBool("isRun", false);
            willon.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            willon.GetComponent<Rigidbody2D>().gravityScale = 1;
            yield return new WaitForSeconds(0.5f);
            willon.transform.localScale = new Vector3(-willon.transform.localScale.x, 1, 1);
            isAction = false;
        }

    }

    IEnumerator WillonAttack()
    {
        direct2 = (willon.transform.localScale.x > 0) ? Vector2.left : Vector2.right;
        yield return new WaitForSeconds(0.5f);
        willon.GetComponent<Rigidbody2D>().gravityScale = 0;
        willon.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(direct2.x * 3, 0);
        willon.GetComponent<Animator>().SetBool("isRun", true);
        yield return new WaitUntil(() => Mathf.Abs(willon.transform.position.x - nelio.transform.position.x) <= 2.5f);
        willon.GetComponent<Animator>().SetBool("isRun", false);
        StartCoroutine(willon.GetComponent<Lonelibet>().A1());
        willon.GetComponent<Rigidbody2D>().gravityScale = 1;
        willon.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(direct2.x * 3, 3f);
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator BacktoScarlet()
    {
        direct2 = (transform.position - willon.transform.position).normalized;
        direct2 = new Vector2(direct2.x, 0);
        yield return new WaitForSeconds(0.1f);
        if (direct2.x > 0) willon.transform.localScale = new Vector3(-1, 1, 1);
        else willon.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(0.5f);
        willon.GetComponent<Rigidbody2D>().gravityScale = 0;
        willon.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(direct2.x * 3, 0);
        willon.GetComponent<Animator>().SetBool("isRun", true);
        yield return new WaitUntil(() => Mathf.Abs(willon.transform.position.x - transform.position.x) <= 0.1f);
        willon.GetComponent<Animator>().SetBool("isRun", false);
        willon.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        willon.GetComponent<Rigidbody2D>().gravityScale = 1;
        willon.transform.localScale = new Vector3(willon.transform.position.x > nelio.transform.position.x ? 1 : -1, 1, 1);
        yield return new WaitForSeconds(0.5f);
        willon.GetComponent<Lonelibet>().Bark();
        yield return new WaitForSeconds(0.2f);
        willon.GetComponent<Lonelibet>().Bark();
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator A1()
    {
        isAction = true;
        anim.SetTrigger("A1");
        yield return new WaitForSeconds(2f / 6f);
        SlashSound.Play();
        HitA1();
        yield return new WaitForSeconds(4 / 6f);
        isAction = false;
        yield return new WaitForSeconds(0.2f);
    }
    IEnumerator A2()
    {
        isAction = true;
        anim.SetTrigger("A2");
        SlashSound.Play();
        HitA2();
        rb.linearVelocity = new Vector2(direct.x * 2, 0);
        yield return new WaitForSeconds(1f / 2f);
        SlashSound.Play();
        HitA2();
        rb.linearVelocity = new Vector2(direct.x * 2, 0);
        yield return new WaitForSeconds(1 / 2f);
        isAction = false;
        yield return new WaitForSeconds(0.2f);
    }
    public IEnumerator A3()
    {
        isAction = true;
        anim.SetTrigger("A3");
        rb.linearVelocity = new Vector2(direct.x * 2, 0);
        yield return new WaitForSeconds(1 / 2f);
        SlashSound.Play();
        HitA2();
        yield return new WaitForSeconds(1 / 2f);
        isAction = false;
        yield return new WaitForSeconds(0.2f);

    }
    IEnumerator A4()
    {
        isAction = true;
        anim.SetTrigger("A4");
        rb.linearVelocity = new Vector2(direct.x * 2, 0);
        yield return new WaitForSeconds(4f / 6f);
        SlashSound.Play();
        HitA2();
        yield return new WaitForSeconds(2 / 6f);
        isAction = false;
        yield return new WaitForSeconds(0.2f);
    }
    IEnumerator A5()
    {
        isAction = true;
        anim.SetTrigger("A5");
        rb.linearVelocity = new Vector2(direct.x * jumpRange, jumpForce);
        rb.gravityScale = 2;
        yield return new WaitForSeconds(4f / 6f);
        SlashSound.Play();
        HitGroundSound.Play();
        HitA3();
        yield return new WaitForSeconds(2 / 6f);
        rb.gravityScale = 1;
        yield return new WaitForSeconds(0.5f);
        isAction = false;
        yield return new WaitForSeconds(0.2f);
    }


    IEnumerator RA()
    {
        isAction = true;
        anim.SetTrigger("BA");
        BowSound.Play();
        StartCoroutine(SpawnArrow());
        yield return new WaitForSeconds(1 + 1 / 6f);
        isAction = false;
    }

    public void BowAttack()
    {
        anim.SetTrigger("BA");
        BowSound.Play();
        StartCoroutine(SpawnArrow());
    }

    IEnumerator SpawnArrow()
    {
        yield return new WaitForSeconds(5 / 6f);
        GameObject a = Instantiate(arrow, firePos.transform.position, Quaternion.Euler(0, 0, transform.localScale.x > 0 ? 0 : 180));
        a.GetComponent<Rigidbody2D>().linearVelocity = (transform.localScale.x > 0 ? Vector2.left : Vector2.right) * arrowSpeed;
    }

    void Flip()
    {
        if (nelio == null) return;
        if (nelio.transform.position.x < transform.position.x) { transform.localScale = new Vector3(1, 1, 1); }
        if (nelio.transform.position.x > transform.position.x) { transform.localScale = new Vector3(-1, 1, 1); }
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
    void HitA2()
    {
        Collider2D[] enemies = Physics2D.OverlapCapsuleAll(hitboxA2.transform.position, new Vector2(2.85f, 2f), CapsuleDirection2D.Horizontal, 0,
            LayerMask.GetMask("Player"));

        foreach (Collider2D c in enemies)
        {
            if (c.CompareTag("Player") && !c.GetComponent<P_Dash>().isImmute)
            {
                StartCoroutine(c.GetComponent<P_Hurt>().Hurt());
            }
        }
    }
    void HitA3()
    {
        Collider2D[] enemies = Physics2D.OverlapCapsuleAll(hitboxA3.transform.position, new Vector2(3.8f, 2.8f), CapsuleDirection2D.Horizontal, 0,
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
