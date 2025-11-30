using UnityEngine;

public class Milo_Move : MonoBehaviour
{
    float moveSpeed = 2f;

    Rigidbody2D rb;
    Animation anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            float angle = Vector2.Angle(collision.contacts[0].normal, Vector2.up);
            if (angle > 0)
            {
                Vector2 direct = Vector2.Perpendicular(collision.contacts[0].normal);
                rb.linearVelocity = new Vector2(-direct.x * moveSpeed, rb.linearVelocity.y);
            }
        }
    }

}
