using System.Collections;
using UnityEngine;

public class P_Move : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float waterSpeed = 1.5f;
    private float currentMoveSpeed;
    bool isRun;
    float x;
    SpriteRenderer sr;

    private bool isInWater = false;

    Rigidbody2D rb;
    Animator animator;

    [Header("Block Condition")]
    bool isAttack;
    bool isDash;
    bool isBlock;
    bool isWS;
    bool isWJ;
    bool isGround;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        isBlock = GetComponent<P_Block>().isBlock;
        isAttack = GetComponent<P_Attack>().isAttack;
        isDash = GetComponent<P_Dash>().isDash;
        isWS = GetComponent<P_OnWall>().isWS;
        isWJ = GetComponent<P_OnWall>().isWJ;
        isGround = GetComponent<P_Jump>().isGround();
        if (!isBlock)
        {
            x = Input.GetAxisRaw("Horizontal");
            isRun = (x != 0);
            Animate();

            if (!isAttack && !isDash && !isWS && !isWJ)
            {
                Move();
                Flip();
            }
        }        

    }
    bool isBeingStunned = false;

    public void Stun(float duration)
    {
        if (!isBeingStunned)
        {
            StartCoroutine(StunCoroutine(duration));
            StartCoroutine(Freeze(duration));
        }
    }
    IEnumerator StunCoroutine(float duration)
    {
        isBeingStunned = true;
        GetComponent<P_Block>().isBlock = true;
        animator.SetBool("isRun", false);
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(duration);
        GetComponent<P_Block>().isBlock = false;
        isBeingStunned = false;
    }
    public IEnumerator Freeze(float duration)
    {
        Color currentColor = sr.color;
        sr.color = new Color32(5, 151, 255, 255);
        yield return new WaitForSeconds(duration);
        sr.color = currentColor;
    }
    void Move()
    {
        if (isInWater)
        {
            currentMoveSpeed = waterSpeed;
        }
        else
        {
            currentMoveSpeed = moveSpeed;
        }
        rb.linearVelocity = new Vector2 (x * currentMoveSpeed, rb.linearVelocity.y);
        
    }
    void Animate()
    {
        animator.SetBool("isRun", isRun);
    }

    void Flip()
    {
        if (x > 0) transform.localScale = Vector3.one;
        if (x < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isAttack && !isDash && !isBlock)
        {
            float angle = Vector2.Angle(collision.contacts[0].normal, Vector2.up);
            if (angle > 0)
            {
                Vector2 direct = Vector2.Perpendicular(collision.contacts[0].normal);
                if(!isBlock) rb.linearVelocity = new Vector2(direct.x * moveSpeed, rb.linearVelocity.y);
                else rb.linearVelocity = new Vector2(-direct.x * moveSpeed, rb.linearVelocity.y);
            }
        }
        if(collision.gameObject.CompareTag("Water"))
        {
            moveSpeed-=1.5f;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = true;
        }
    }

    // Khi thoát khỏi vùng nước
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = false;
        }
    }
}
