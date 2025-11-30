using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Robot_Control : MonoBehaviour
{
    public Transform Player;
    public Animator animator;
    public List<Transform> targetPosition;

    Vector3 direct;
    float timer;
    float timerSkill1;
    float timerSkill2;
    bool isAttacking = false;
    bool isTeleporting = false;
    bool isUsingSkill = false;

    [SerializeField] GameObject hit1Pos;
    [SerializeField] Vector2 hit1Range;

    Rigidbody2D rb;


    float timeRoll;
    float rollCoolDown = 1f;
    public int rollNum;

    bool isDead = false;

    float Skill1CoolDown = 5f;
    float Skill2CoolDown = 5f;

    public GameObject teleportEffect;

    [SerializeField] GameObject laserPrefab;
    [SerializeField] Transform lazerPoint; // vị trí bắn laser (trên đầu robot)

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject warningZonePrefab;

    public Vector3[] spawnOffsets;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        direct = Vector3.left;
        Roll();
        timerSkill1 = Time.time;
        timerSkill2 = Time.time;
        StartCoroutine(TriggerInitialSkill());
    }
    IEnumerator TriggerInitialSkill()
    {
        yield return new WaitForSeconds(0.2f); // chờ một chút cho ổn định
        if (rollNum == 1)
            StartCoroutine(Skill1());
        else if (rollNum == 2)
            StartCoroutine(Skill2());
    }
    // Update is called once per frame
    void Update()
    {
        if (Player.position.x > transform.position.x)
            direct = Vector3.right;
        else
            direct = Vector3.left;

        transform.localScale = (direct == Vector3.right) ? Vector3.one : new Vector3(-1, 1, 1);
        if (isUsingSkill && Time.time >= timeRoll + rollCoolDown && !isDead && !isAttacking && !isTeleporting)
        {
            Roll();
        }

        if (!isUsingSkill && Time.time >= timerSkill1 + Skill1CoolDown && rollNum == 1 && !isDead && !isAttacking && !isTeleporting)
        {
            StartCoroutine(Skill1());
        }
        else if (!isUsingSkill && Time.time >= timerSkill2 + Skill2CoolDown && rollNum == 2 && !isDead && !isAttacking && !isTeleporting)
        {
            StartCoroutine(Skill2());
        }


        if (isDead)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            StopAllCoroutines();
        }
    }
    private void Roll()
    {
        timeRoll = Time.time;
        rollNum = Random.Range(1, 3);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // Chọn màu cho Gizmos
        Gizmos.DrawWireCube(hit1Pos.transform.position, hit1Range);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 0.8f);
    }
    bool PlayerInHitZone()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(hit1Pos.transform.position, hit1Range, 0, LayerMask.GetMask("Player"));
        foreach (Collider2D col in hits)
        {
            if (col.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }
    IEnumerator Attack1()
    {
        isAttacking = true;
        timer = Time.time;
        rb.gravityScale = 0;

        float attackStartTime = Time.time;
        bool reachedPlayer = false;

        // Giai đoạn rượt đuổi
        while (!reachedPlayer)
        {
            float distance = Mathf.Abs(transform.position.x - Player.position.x);

            if (distance > 1f)
            {
                rb.linearVelocity = (direct == Vector3.right) ? new Vector2(5, 0) : new Vector2(-5, 0);
            }
            else
            {
                reachedPlayer = true;
                rb.linearVelocity = Vector2.zero;
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
            }

            // Nếu quá thời gian thì hủy tấn công
            if (Time.time - attackStartTime > 2f)
            {
                rb.gravityScale = 1;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.linearVelocity = Vector2.zero;
                isAttacking = false;
                yield break;
            }

            yield return null;
        }

        // Giai đoạn combo
        int comboCount = 3;
        for (int i = 0; i < comboCount; i++)
        {
            animator.SetTrigger("isAttack");
            Debug.Log($"Trigger attack {i + 1}");
            yield return new WaitForSeconds(0.5f);
            Hit1();

            // Nếu player chạy xa trong lúc combo, thì rượt lại
            if (!PlayerInHitZone())
            {
                rb.constraints = RigidbodyConstraints2D.None;
                break;
            }
        }

        yield return new WaitForSeconds(0.3f);

        rb.gravityScale = 1;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.linearVelocity = Vector2.zero;
        isAttacking = false;
    }


    void Hit1()
    {
        Collider2D[] player = Physics2D.OverlapBoxAll(hit1Pos.transform.position, hit1Range, 0, LayerMask.GetMask("Player"));

        if (player.Length > 0) // Kiểm tra xem có collider nào được quét không
        {
            foreach (Collider2D col in player)
            {
                if (col.gameObject.CompareTag("Player"))
                {
                    Debug.Log("Hit Player");
                    //    col.gameObject.GetComponent<PlayerLifeController>().StartCoroutine("TakeDame", 1f);
                }
            }
        }

    }
    IEnumerator Teleport(Transform targetPos)
    {
        timer = Time.time;
        // Tắt vật lý tạm thời nếu cần
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        // Gọi animation biến mất nếu có
        animator.SetTrigger("isDissapear");
        yield return new WaitForSeconds(0.5f);
        GameObject effectOut = Instantiate(teleportEffect, transform.position, Quaternion.identity);
        Destroy(effectOut, 0.3f);
        //Dịch chuyển boss
        transform.position = targetPos.position;
        yield return new WaitForSeconds(0.5f);
        GameObject effectIn = Instantiate(teleportEffect, transform.position, Quaternion.identity);
        Destroy(effectIn, 0.3f);
        animator.SetTrigger("isAppear");
        // Bật lại vật lý
        rb.gravityScale = 1;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.linearVelocity = new Vector2(0, -0.1f);

        Debug.Log("Boss teleported to " + targetPos);
        isTeleporting = false;
    }
    float comboDuration = 5f; // thời gian combo tối đa
    float comboStartTime;
    IEnumerator Skill1()
    {
        isUsingSkill = true;
        timerSkill1 = Time.time;
        comboStartTime = Time.time;
        if (transform.position != targetPosition[0].position)
        {
            isTeleporting = true;
            yield return StartCoroutine(Teleport(targetPosition[0]));
            rb.gravityScale = 1;
            rb.constraints = RigidbodyConstraints2D.None;
            yield return new WaitForSeconds(1.5f); // chờ một chút để ổn định vị trí sau khi dịch chuyển
        }
        while (PlayerInHitZone() && !isDead)
        {
            yield return StartCoroutine(Attack1());

            // Chờ một chút giữa các đòn combo
            yield return new WaitForSeconds(0.1f);

            // Nếu roll cooldown đã đến, thoát khỏi combo
            if (Time.time - comboStartTime > comboDuration)
            {
                break;
            }
        }
        isAttacking = false;
        isUsingSkill = false;

    }

    IEnumerator Skill2()
    {
        isUsingSkill = true;
        timerSkill2 = Time.time;
        if (transform.position != targetPosition[1].position)
        {
            isTeleporting = true;
            yield return StartCoroutine(Teleport(targetPosition[1]));
        }

        yield return StartCoroutine(Attack2());
        isUsingSkill = false;
    }
    IEnumerator Attack2()
    {
        animator.SetBool("isAttack2", true);
        yield return new WaitForSeconds(2.5f);
        yield return StartCoroutine(FireLaser());
        yield return new WaitForSeconds(1f);
        

    }
    [SerializeField] Transform targetPoint; // vị trí chỉ định để laser bẻ góc

    IEnumerator FireLaser()
    {
        // Laser từ robot đến điểm chỉ định
        GameObject laserForward = Instantiate(laserPrefab, lazerPoint.position, Quaternion.identity);
        LineRenderer lrForward = laserForward.GetComponent<LineRenderer>();
        lrForward.SetPosition(0, lazerPoint.position);
        lrForward.SetPosition(1, targetPoint.position);

        yield return new WaitForSeconds(0.3f); // delay trước khi bẻ góc

        // Laser từ điểm chỉ định chiếu thẳng xuống
        GameObject laserDown = Instantiate(laserPrefab, targetPoint.position, Quaternion.identity);
        LineRenderer lrDown = laserDown.GetComponent<LineRenderer>();
        lrDown.SetPosition(0, targetPoint.position);
        lrDown.SetPosition(1, targetPoint.position + Vector3.down * 8f); // chiếu thẳng xuống
        lrForward.useWorldSpace = true;
        lrDown.useWorldSpace = true;
        yield return new WaitForSeconds(1f); // giữ laser trong 1 giây
        Destroy(laserForward);
        Destroy(laserDown);
        animator.SetBool("isAttack2", false);
        CastLaserAttack();
        yield return new WaitForSeconds(5.5f);
    }
    void CastLaserAttack()
    {
        foreach (Vector3 offset in spawnOffsets)
        {
            Vector3 spawnPos = offset;
            Instantiate(warningZonePrefab, spawnPos, Quaternion.identity);
        }
    }
}
