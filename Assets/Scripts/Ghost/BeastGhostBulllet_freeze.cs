using System.Collections;
using System.Data;
using UnityEngine;

public class BeastGhostBullet_freeze : MonoBehaviour
{
    float lifeTime = 5f;
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
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player") && !c.GetComponent<P_Dash>().isImmute)
        {
            StartCoroutine(Freeze(c.gameObject));
            StartCoroutine(HideBullet(this.gameObject));
            
        }
    }
    public IEnumerator Freeze(GameObject c)
    {
        c.GetComponent<P_Hurt>().takedameSound.Play();
        c.GetComponent<Animator>().SetTrigger("Hurt");
        c.GetComponent<P_Life>().hp -= 1;
        c.GetComponent<P_Block>().isBlock = true;
        c.GetComponent<P_Dash>().isImmute = true;
        Color currentColor = c.GetComponent<SpriteRenderer>().color;
        c.GetComponent<SpriteRenderer>().color = new Color32(5, 151, 255, 255);
        c.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        c.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        c.GetComponent<Animator>().SetBool("isRun", false);
        yield return new WaitForSeconds(1);
        c.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        c.GetComponent<SpriteRenderer>().color = currentColor;
        yield return new WaitForSeconds(0.5f);
        c.GetComponent<P_Block>().isBlock = false;
        yield return new WaitForSeconds(0.7f);
        c.GetComponent<P_Dash>().isImmute = false;                
    }
    IEnumerator HideBullet(GameObject c)
    {
        c.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(5f);
        c.gameObject.SetActive(false);
    }
}
