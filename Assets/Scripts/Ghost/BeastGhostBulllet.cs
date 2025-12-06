using System.Collections;
using UnityEngine;

public class BeastGhostBullet_ : MonoBehaviour
{
    float lifeTime = 5f;
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
        //if (BulletPool.isBulletFrozen) return;
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
    void OnTriggerEnter2D(Collider2D c)
    {
        //if (BulletPool.isBulletFrozen) return;
        if (c.CompareTag("Player") && !c.GetComponent<P_Dash>().isImmute)
        {
            StartCoroutine(c.GetComponent<P_Hurt>().Hurt());
            StartCoroutine(HideBullet(this.gameObject));
        }
    }

    IEnumerator HideBullet(GameObject c)
    {        
        c.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(5f);
        c.gameObject.SetActive(false);
    }
}
