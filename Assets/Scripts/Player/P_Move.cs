using UnityEngine;

public class P_Move : MonoBehaviour
{
    public float moveSpeed;

    bool isRun;
    float x;


    

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

    void Move()
    {        
        rb.linearVelocity = new Vector2 (x * moveSpeed, rb.linearVelocity.y);
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
        if (collision.gameObject.CompareTag("Ground") && !isAttack && !isDash)
        {
            float angle = Vector2.Angle(collision.contacts[0].normal, Vector2.up);
            if (angle > 0)
            {
                Vector2 direct = Vector2.Perpendicular(collision.contacts[0].normal);
                if(!isBlock) rb.linearVelocity = new Vector2(direct.x * moveSpeed, rb.linearVelocity.y);
                else rb.linearVelocity = new Vector2(-direct.x * moveSpeed, rb.linearVelocity.y);
            }
        }
    }

}
