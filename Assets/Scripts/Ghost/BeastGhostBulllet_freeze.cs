using System.Collections;
using UnityEngine;

public class BeastGhostBullet_freeze : MonoBehaviour
{
    public float lifeTime = 2f;
    private float speed = 5f;
    private Vector3 direction = Vector3.right;
    public bool isStunned = false;
    public static BeastGhostBullet_freeze instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Stun(float duration)
    {
        if (!isStunned)
        {
            StartCoroutine(StunCoroutine(duration));
        }
    }


    private IEnumerator StunCoroutine(float duration)
    {
        isStunned = true;
        Debug.Log("Player stunned!");
        yield return new WaitForSeconds(duration);
        isStunned = false;
        Debug.Log("Player recovered from stun.");
        yield return new WaitUntil(() => !isStunned);
    }
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
        transform.Translate(direction * speed * Time.deltaTime);

    }
    void OnEnable()
    {
        Invoke("DisableBullet", lifeTime);
    }

    void DisableBullet()
    {
        BulletPool.Instance.ReturnBeastGhostBullet2(gameObject);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.GetComponent<P_Dash>().isImmute)
        {
            P_Life bullet = other.GetComponent<P_Life>();
            bullet.hp--;
            other.GetComponent<P_Move>().Stun(1f);
            gameObject.SetActive(false);

        }
    }
}
