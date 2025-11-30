using UnityEngine;

public class BeastGhostBullet_ : MonoBehaviour
{
    public float lifeTime = 2f;
    private float speed = 5f;
    private Vector3 direction = Vector3.right;
    
    public void SetDirection(Vector3 dir)
    {

        direction = dir.normalized;

    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (BulletPool.isBulletFrozen) return;
        transform.Translate(direction * speed * Time.deltaTime);

    }
    void OnEnable()
    {
        Invoke("DisableBullet", lifeTime);
    }

    void DisableBullet()
    {
        BulletPool.Instance.ReturnBeastGhostBullet(gameObject);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (BulletPool.isBulletFrozen) return;
        if (other.CompareTag("Player") && !other.GetComponent<P_Dash>().isImmute)
        {
            P_Life bullet = other.GetComponent<P_Life>();
            bullet.hp--; 
            gameObject.SetActive(false);
        }
    }
}
