using Unity.VisualScripting;
using UnityEngine;

public class P_OnWall : MonoBehaviour
{
    [SerializeField] GameObject handPos;

    float moveInput;
    Vector2 direct;
    public bool isWS;
    public bool isWJ;    


    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;

    [Header("-----Sound----")]
    [SerializeField] AudioSource jumpSound;

    [Header("Block Condition")]   
    bool isGround;
    bool isBlock;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        direct = Vector2.right;
    }

    
    void Update()
    {
        isGround = GetComponent<P_Jump>().isGround();

        moveInput = Input.GetAxis("Horizontal");
        Animate();

        WallSlide();
        WallJump();

        if(moveInput != 0 && !isWJ && !isWS)
        {
            sr.flipX = false;
        }
    }

    void WallSlide()
    {
        if(isWall() && !isGround && moveInput/direct.x > 0 && !isWJ)
        {            
            isWS = true;            
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Clamp(rb.linearVelocity.y, -1f, float.MaxValue));
            sr.flipX = true;
            animator.SetTrigger("WS");
            
        }        
        else
        {
            isWS = false;            
            animator.ResetTrigger("WS");
        }    
    }

    void WallJump()
    {
        if (isWS)
        {
            isWJ = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isWJ && isWS)
        {
            isWJ = true;
            rb.linearVelocity = new Vector2(-direct.x * 5f, 5f);
            animator.SetTrigger("Jump");
            jumpSound.Play();
            Invoke(nameof(OffWJ), 0.3f);
        }        
    }

    void OffWJ()
    {
        isWJ = false;
    }

    void Animate()
    {
        animator.SetBool("isWS", isWS);
    }

    public bool isWall()
    {
        return Physics2D.OverlapCapsule(handPos.transform.position, new Vector2(0.1f, 0.5f), CapsuleDirection2D.Vertical, 0, LayerMask.GetMask("Wall"));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(handPos.transform.position, new Vector2(0.1f, 0.5f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            direct = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        }
    }

}
