using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeastGhostController : MonoBehaviour
{

    public LayerMask Player;
    public Transform firePoint;
    public Transform player;
    Animator Animator;
    Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public int maxHealth = 10;
    public int currentHealth;
    public bool isDead = false;

    public static BeastGhostController instance;


    public GameObject warningZonePrefab;

    Vector3[] spawnOffsets1 = new Vector3[]
    {
    new Vector3(-4f, -0.5f, 0),
    new Vector3(0f, -0.5f, 0),
    new Vector3(4f, -0.5f, 0)
    };
    Vector3[] spawnOffsets2 = new Vector3[]
{
    new Vector3(-2f, -0.5f, 0),
    new Vector3(0f, -0.5f, 0),
    new Vector3(2f, -0.5f, 0),
    new Vector3(4f, -0.5f, 0),
    new Vector3(6f, -0.5f, 0)
};

    float timeRoll;
    float rollCoolDown = 1f;
    public int rollNum;
    float timer;

    float skill1 = 3f;

    float skill2 = 3f;

    float skill3 = 3f;

    public float shootCooldown = 2f;
    private float shootTimer;
    private bool isCastingUltimate = false;
    
    private Vector3 lockedPosition;

    public List<Transform> targetPosition;
    public GameObject teleportEffect;
    bool isTeleporting = false;
    private Coroutine currentSkillCoroutine;

    public bool isBattle;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();

    }
    bool isBlocked;
    private int lastHealth = -1;
    void Update()
    {
        if(isBattle)
        {
            currentHealth = (int)GetComponent<EnemyLife>().hp;
            shootTimer += Time.deltaTime;
            Flip(player);

            if (Time.time >= timeRoll + rollCoolDown && !isDead && !isBlocked)
            {
                Roll();
            }

            if (Time.time >= timer + skill1 && rollNum == 1 && !isDead)
            {
                if (shootTimer >= shootCooldown)
                {
                    Shoot(player);
                    shootTimer = 0f;
                    if (isShot)
                    {
                        Shoot2(player);
                    }
                }
            }
            else if (Time.time >= timer + skill2 && rollNum == 2 && !isDead && !isCastingUltimate && currentHealth >= 8)
            {
                StopCurrentSkill();
                StartCoroutine(UltimateSkill());
                isCastingUltimate = true;

            }
            else if (Time.time >= timer + skill3 && rollNum == 3 && !isDead && !isCastingUltimate && currentHealth >= 5 && currentHealth < 8)
            {
                StopCurrentSkill();
                StartCoroutine(UltimateSkillFinal());
                isCastingUltimate = true;
            }
            else if (Time.time >= timer + skill3 && rollNum == 4 && !isDead && !isCastingUltimate && currentHealth < 5)
            {
                StopCurrentSkill();
                StartCoroutine(UltimateSkillFinal2());
                isCastingUltimate = true;
                isBlocked = true;
                rollNum = 4;
            }
            if (isDead)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                StopAllCoroutines();
            }
            if (currentHealth != lastHealth)
            {
                lastHealth = currentHealth;
                Tele();
            }
        }
        
        
    }
    void StopCurrentSkill()
    {
        if (currentSkillCoroutine != null)
        {
            StopCoroutine(currentSkillCoroutine);
            currentSkillCoroutine = null;
        }

        // Reset trạng thái cast
        isCastingUltimate = false;
    }


    private void Roll()
    {
        timeRoll = Time.time;
        rollNum = Random.Range(1, 5);
    }
    void CastGroundAttack()
    {
        if (BulletPool.isBulletFrozen) return;
        else
        {
            Vector3 spawnPos = player.position + new Vector3(0, -0.5f, 0);
            GameObject zone = Instantiate(warningZonePrefab, spawnPos, Quaternion.identity);
        }

    }
    void CastGroundAttack2()
    {
        if (BulletPool.isBulletFrozen) return;
        else
        {
            foreach (Vector3 offset in spawnOffsets1)
            {
                Vector3 spawnPos = player.position + offset;
                Instantiate(warningZonePrefab, spawnPos, Quaternion.identity);
            }
        }

    }
    void CastGroundAttack3()
    {
        if (BulletPool.isBulletFrozen) return;
        else
        {
            foreach (Vector3 offset in spawnOffsets2)
            {
                Vector3 spawnPos = player.position + offset;
                Instantiate(warningZonePrefab, spawnPos, Quaternion.identity);
            }
        }

    }
    IEnumerator UltimateSkill()
    {
        Free1s();
        yield return new WaitForSeconds(3f);
        Animator.SetTrigger("isCastSpell");
        CastGroundAttack();
        yield return new WaitForSeconds(1f);
        isCastingUltimate = false;
    }
    IEnumerator UltimateSkillFinal()
    {
        spriteRenderer.color = Color.magenta;
        Free1s();
        yield return new WaitForSeconds(3f);
        Animator.SetTrigger("isCastSpell");
        CastGroundAttack2();
        yield return new WaitForSeconds(1f);
        isCastingUltimate = false;
    }
    IEnumerator UltimateSkillFinal2()
    {
        spriteRenderer.color = Color.magenta;
        Free1s();
        yield return new WaitForSeconds(3f);
        Animator.SetTrigger("isCastSpell");
        CastGroundAttack3();
        yield return new WaitForSeconds(1f);
        isCastingUltimate = false;
    }
    public void Free1s()
    {
        StartCoroutine(LockTransformRoutine());
    }

    private IEnumerator LockTransformRoutine()
    {
        lockedPosition = transform.position;        
        yield return new WaitForSeconds(1f);        
    }
    public void Flip(Transform target)
    {
        spriteRenderer.flipX = (target.position.x < transform.position.x);
    }



    public void ResetEnemy()
    {
        Animator.SetBool("isDie", false);
        currentHealth = maxHealth;
        if (Animator == null)
            Animator = GetComponent<Animator>();

    }

    bool isShot = false;
    void Shoot(Transform target)
    {
        Free1s();
        GameObject BeastGhostBullet = BulletPool.Instance.GetBeastGhostBullet();
        if (BeastGhostBullet != null)
        {
            BeastGhostBullet.transform.position = firePoint.position;
            Vector3 direction = (target.position - firePoint.position).normalized;
            BeastGhostBullet.GetComponent<BeastGhostBullet_>().SetDirection(direction);
            isShot = true;
        }
    }
    void Shoot2(Transform target)
    {
        StartCoroutine(Shoot2Coroutine(target));
    }

    IEnumerator Shoot2Coroutine(Transform target)
    {
        yield return new WaitForSeconds(10f); // chờ 10s

        Free1s();
        GameObject BeastGhostBullet2 = BulletPool.Instance.GetBeastGhostBullet2();
        if (BeastGhostBullet2 != null)
        {
            BeastGhostBullet2.transform.position = firePoint.position;
            Vector3 direction = (target.position - firePoint.position).normalized;
            BeastGhostBullet2.GetComponent<BeastGhostBullet_freeze>().SetDirection(direction);
            isShot = false;
        }
    }

    IEnumerator Teleport(Transform targetPos)
    {
        timer = Time.time;

        GameObject effectOut = Instantiate(teleportEffect, transform.position, Quaternion.identity);
        Destroy(effectOut, 0.3f);


        //Dịch chuyển boss
        transform.position = targetPos.position;
        Vector3 pos = transform.position;
        pos.z = 1;
        transform.position = pos;


        yield return new WaitForSeconds(0.5f);
        GameObject effectIn = Instantiate(teleportEffect, transform.position, Quaternion.identity);
        Debug.Log("Spawn teleport effect at " + transform.position);
        Destroy(effectIn, 0.3f);

        Debug.Log("Boss teleported to " + targetPos);
        isTeleporting = false;
    }
    public void Tele()
    {
        if (currentHealth == 9)
        {
            isTeleporting = true;
            if (isTeleporting)
                StartCoroutine(Teleport(targetPosition[0]));
        }
        if (currentHealth == 8)
        {
            isTeleporting = true;
            if (isTeleporting)
                StartCoroutine(Teleport(targetPosition[1]));
        }
        if (currentHealth == 7)
        {
            isTeleporting = true;
            if (isTeleporting)
                StartCoroutine(Teleport(targetPosition[2]));
        }
        if (currentHealth == 6)
        {
            isTeleporting = true;
            if (isTeleporting)
                StartCoroutine(Teleport(targetPosition[3]));
        }
        if (currentHealth == 5)
        {
            isTeleporting = true;
            if (isTeleporting)
                StartCoroutine(Teleport(targetPosition[4]));
        }
        if (currentHealth == 4)
        {
            isTeleporting = true;
            if (isTeleporting)
                StartCoroutine(Teleport(targetPosition[0]));
        }
        if (currentHealth == 3)
        {
            isTeleporting = true;
            if (isTeleporting)
                StartCoroutine(Teleport(targetPosition[5]));
        }
        if (currentHealth == 2)
        {
            isTeleporting = true;
            if (isTeleporting)
                StartCoroutine(Teleport(targetPosition[2]));
        }
        if (currentHealth == 1)
        {
            isTeleporting = true;
            if (isTeleporting)
                StartCoroutine(Teleport(targetPosition[5]));
        }
    }

}
