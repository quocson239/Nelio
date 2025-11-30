using UnityEngine;

public class Robot_laser_bullet : MonoBehaviour
{
    private float lifeTime = 5f;
    private float speed = 5f;
    private float sweepRange = 3f; // khoảng quét trái phải
    private float sweepSpeed = 2f; // tốc độ quét
    private Vector3 startPos;
    private float appearTime;
    private float delayBeforeMove = 0.5f;
    private bool hasStartedMoving = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStartedMoving && Time.time >= appearTime + delayBeforeMove)
        {
            startPos = transform.position; // gán đúng vị trí sau khi đứng yên
            hasStartedMoving = true;
        }

        if (!hasStartedMoving)
        {
            // Đứng yên tại chỗ
            return;
        }

        // Bắt đầu quét quanh vị trí đã gán
        float offset = Mathf.Sin((Time.time - appearTime - delayBeforeMove) * sweepSpeed) * sweepRange;
        transform.position = startPos + Vector3.right * offset;
    }
    void OnEnable()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        float bottomY = sr.bounds.min.y;
        startPos = new Vector3(transform.position.x, bottomY, transform.position.z);

        appearTime = Time.time;
        hasStartedMoving = false;
        Invoke("DisableBullet", lifeTime);
    }

    void DisableBullet()
    {
        Robot_BulletPool.Instance.ReturnRobotBullet(gameObject);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<P_Health>()?.TakeDamage(10);
            gameObject.SetActive(false);
        }
    }
}
