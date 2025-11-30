using UnityEngine;

public class P_BulletController : MonoBehaviour
{
    public Vector3 direct;

    SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direct * 10f * Time.deltaTime;
        Flip();
    }

    void Flip()
    {
        sprite.flipX = direct == Vector3.left;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
