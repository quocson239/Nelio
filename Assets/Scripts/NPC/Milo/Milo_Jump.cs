using UnityEngine;

public class Milo_Jump : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] GameObject footPos;

    public bool isJump;
    public bool isFall;

    Rigidbody2D rb;
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Animate();

        if (rb.linearVelocity.y < 0 && !isGround())
        {
            isFall = true;
        }
        else
        {
            isFall = false;
        }
    }
    void Animate()
    {
        animator.SetBool("isFall", isFall);
        animator.SetBool("isGround", isGround());
    }
    public bool isGround()
    {
        return Physics2D.OverlapCapsule(footPos.transform.position, new Vector2(0.45f, 0.1f), CapsuleDirection2D.Horizontal, 0, LayerMask.GetMask("Ground"));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(footPos.transform.position, new Vector2(0.45f, 0.1f));
    }
}
