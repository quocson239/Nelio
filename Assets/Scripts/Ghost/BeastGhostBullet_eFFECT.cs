using UnityEngine;
using UnityEngine.UIElements;

public class BeastGhostBullet_eFFect : MonoBehaviour
{
    public float lifeTime = 2f;
    private float speed = 2f;
    private Vector3 direction = Vector3.right;
    public GameObject damageEffect;
    public GameObject stunEffect;


    public enum BulletEffectType { Damage, Stun}

    private BulletEffectType effectType;
    private SpriteRenderer spriteRenderer;

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
        spriteRenderer = GetComponent<SpriteRenderer>();

        int rand = Random.Range(0, 2);
        effectType = (BulletEffectType)rand;

        switch (effectType)
        {
            case BulletEffectType.Damage:
                spriteRenderer.color = Color.red;
                break;
            case BulletEffectType.Stun:
                spriteRenderer.color = Color.yellow;
                break;
        }

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
        if (other.CompareTag("Player"))
        {
            Player_Trap_Effect trap = other.GetComponent<Player_Trap_Effect>();

            switch (effectType)
            {
                case BulletEffectType.Stun:
                    trap?.Stun(2f);
                    break;
            }

            gameObject.SetActive(false);
            GameObject effect = null;
            switch (effectType)
            {
                case BulletEffectType.Stun:
                    trap?.Stun(2f);
                    effect = Instantiate(stunEffect, other.transform.position, Quaternion.identity);
                    break;
            }
            Destroy(effect, 1.5f);
        }
        
    }

}
