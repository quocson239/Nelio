using System.Collections;
using UnityEngine;

public class P_Dash : MonoBehaviour
{
    [SerializeField] float dashForce;
    [SerializeField] GameObject dashGhost;
    [SerializeField] float dashCD;
    public bool isDash;
    public bool isImmute;

    Vector2 direct;
    float timer;

    Rigidbody2D rb;
    Animator animator;

    [Header("-----Sound----")]
    [SerializeField] AudioSource dashSound;

    [Header("Block Condition")]    
    bool isAttack;
    bool isBlock;
    bool isGround;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        isBlock = GetComponent<P_Block>().isBlock;
        isAttack = GetComponent<P_Attack>().isAttack;
        isGround = GetComponent<P_Jump>().isGround();
        direct = (transform.localScale.x > 0) ? Vector2.right : Vector2.left;
        if (!isBlock)
        {            
            if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time >= timer + dashCD && !isDash && !isAttack)
            {
                if(!isGround) StartCoroutine(Dash());
                else StartCoroutine(Roll());
            }
        }
        
    }

    public IEnumerator Dash()
    {
        dashSound.Play();
        timer = Time.time;
        isDash = true;
        isImmute = true;
        animator.SetTrigger("Dash");
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(direct * dashForce, ForceMode2D.Impulse);
        rb.gravityScale = 0f;
        InvokeRepeating("SpawnDashGhost", 0, 0.05f);
        yield return new WaitForSeconds(1/6f);
        rb.gravityScale = 1f;
        CancelInvoke();
        rb.linearVelocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        isDash = false;
        isImmute = false;
    }
    public IEnumerator Roll()
    {
        dashSound.Play();
        timer = Time.time;
        isDash = true;
        isImmute = true;
        animator.SetTrigger("Roll");
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(direct * (dashForce - 4f), ForceMode2D.Impulse);
        rb.gravityScale = 1f;        
        yield return new WaitForSeconds(1 / 2f);
        rb.gravityScale = 1f;        
        rb.linearVelocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        isDash = false;
        isImmute = false;
    }

    void SpawnDashGhost()
    {
        GameObject g = Instantiate(dashGhost, transform.position, Quaternion.identity);
        g.transform.localScale = (transform.localScale.x > 0) ? transform.localScale : new Vector3(-1, 1, 1);
        Destroy(g, 0.2f);
    }

}
