using System.Collections;
using UnityEngine;

public class P_Jump : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] GameObject footPos;
    [SerializeField] LayerMask groundMask;

    public bool isJump;
    public bool isFall;

    [Header("-----Sound----")]
    [SerializeField] AudioSource jumpSound;


    bool isJump2; 

    Rigidbody2D rb;
    Animator animator;

    [Header("Block Condition")]
    bool isDash;
    bool isAttack;
    bool isBlock;
    bool isWall;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        isBlock = GetComponent<P_Block>().isBlock;
        isDash = GetComponent<P_Dash>().isDash;
        isAttack = GetComponent<P_Attack>().isAttack;
        isWall = GetComponent<P_OnWall>().isWall();
        if (!isBlock)
        {            
            if (!isDash && !isAttack)
            {
                if (Input.GetKeyDown(KeyCode.Space) && isGround())
                {
                    StartCoroutine(Jump1());
                }
                if (Input.GetKeyDown(KeyCode.Space) && !isGround() && !isJump2)
                {
                    StartCoroutine(Jump2());
                }
            }            
        }

        Animate();

        if (rb.linearVelocity.y < 0 && !isGround() && !isWall)
        {
            isFall = true;
        }
        else
        {
            isFall = false;
        }

        if (isGround())
        {
            isJump = false;
            isJump2 = false;
        }

    }

    public IEnumerator Jump1()
    {      
        jumpSound.Play();
        animator.SetTrigger("Jump");
        rb.linearVelocity = new Vector2 (rb.linearVelocity.x, jumpForce);
        yield return new WaitForSeconds(0.02f);
        isJump = true;
    }

    IEnumerator Jump2()
    {
        jumpSound.Play();
        isJump2 = true;
        animator.SetTrigger("DJ");        
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        yield return null;
    }
    

    void Animate()
    {
        animator.SetBool("isFall", isFall);
        animator.SetBool("isGround", isGround());
    }

    public bool isGround()
    {
        return Physics2D.OverlapCapsule(footPos.transform.position, new Vector2(0.45f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(footPos.transform.position, new Vector2(0.45f, 0.1f));
    }
}
