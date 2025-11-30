using System.Collections;
using UnityEngine;

public class Undead_Controller : MonoBehaviour
{
    public Transform player;
    public float detectRange = 5f;
    public float attackRange = 2f;

    public GameObject shockwavePrefab;
    public float shockwaveRange = 5f;
    public float shockwaveDelay = 1f; 
    public float projectileOffset = 1.0f; 

    public GameObject minionPrefab;
    public Transform[] spawnPoints;
    private int maxMinionCount = 0;
    private bool[] minionSlotOccupied = new bool[3];
    public Vector3[] minionFollowOffsets;

    private enum BossState { Idle, Chase, Attack, Shockwave, Summon,Dead }
    private BossState currentState = BossState.Idle;

    private float lastAttackTime;
    private float attackCooldown = 1.5f;
    private float lastAbilityTime;
    private float abilityCooldown = 5f;

    private Animator animator;

    public float moveSpeed = 3f; 
    public int bossHealth = 10;

    public GameObject item;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        UpdateRotation(player.position);
        switch (currentState)
        {
            case BossState.Idle:
                if (distanceToPlayer <= detectRange)
                {
                    currentState = BossState.Chase;
                }
                break;
            case BossState.Chase:
                if (distanceToPlayer <= attackRange)
                {
                    currentState = BossState.Attack;
                }
                else
                {
                    MoveTowardsPlayer(); 
                }
                TryUseAbility();
                break;
            case BossState.Attack:
                if (Time.time >= lastAttackTime + attackCooldown)
                {
                    PerformNormalAttack(); 
                    lastAttackTime = Time.time;
                    currentState = BossState.Chase; 
                }
                break;
            case BossState.Shockwave:
                PerformShockwaveAttack();
                currentState = BossState.Chase;
                break;
            case BossState.Summon:
                SummonMinions(); 
                currentState = BossState.Chase;
                break;
            case BossState.Dead:
                gameObject.SetActive(false);
                break;
        }
    }
    private void UpdateRotation(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        Vector3 currentScale = transform.localScale;

        float absScaleX = Mathf.Abs(currentScale.x);

        if (direction.x > 0)
        {
            if (currentScale.x < 0)
            {
                transform.localScale = new Vector3(absScaleX, currentScale.y, currentScale.z);
                Debug.Log("Boss: Lật sang phải.");
            }
        }
        else if (direction.x < 0)
        {
            if (currentScale.x > 0)
            {
                transform.localScale = new Vector3(-absScaleX, currentScale.y, currentScale.z);
                Debug.Log("Boss: Lật sang trái.");
            }
        }
    }
    private void PerformNormalAttack()
    {
        int attackType = Random.Range(1, 3); 

        if (attackType == 1)
        {
            Debug.Log("Boss: Đánh thường Dạng 1 - Đánh cận chiến đơn giản.");
            animator.SetTrigger("Attack1");
            P_Life playerLife = player.GetComponent<P_Life>();
            playerLife.hp--;
        }
        else 
        {
            Debug.Log("Boss: Đánh thường Dạng 2 - Combo 3 hit.");
            animator.SetTrigger("Attack2");
            P_Life playerLife = player.GetComponent<P_Life>();
            playerLife.hp--;
        }
    }

    private void SummonMinions()
    {
        Debug.Log("Boss: Bù đắp Quỷ con...");
        animator.SetTrigger("Summon");

        int minionsToCreate = 3 - maxMinionCount;
        int actualCount = Mathf.Min(minionsToCreate, minionSlotOccupied.Length);

        int createdCount = 0; 

        if (minionPrefab != null && actualCount > 0)
        {
            for (int i = 0; i < minionSlotOccupied.Length; i++)
            {
                if (createdCount >= actualCount) break;

                if (minionSlotOccupied[i] == false)
                {
                    if (i >= spawnPoints.Length || i >= minionFollowOffsets.Length) continue;

                    Transform point = spawnPoints[i];
                    Vector3 followOffset = minionFollowOffsets[i];

                    GameObject minionObject = Instantiate(minionPrefab, point.position, Quaternion.identity);

                    SummonMinion_Controller minionScript = minionObject.GetComponent<SummonMinion_Controller>();
                    if (minionScript != null)
                    {
                        minionScript.SetBossController(this);
                        minionScript.SetFollowOffset(followOffset);
                        minionScript.SetMySlotIndex(i); 
                    }
                    minionSlotOccupied[i] = true;

                    createdCount++;
                }
            }
            maxMinionCount += createdCount;
        }
        lastAbilityTime = Time.time;
    }
    private void TryUseAbility()
    {
        if (Time.time < lastAbilityTime + abilityCooldown) return;

        int abilityChoice = Random.Range(1, 3);
        if (abilityChoice == 1 && Vector3.Distance(transform.position, player.position) <= shockwaveRange)
        {
            currentState = BossState.Shockwave;
        }
        else if (abilityChoice == 2 && maxMinionCount <= 3)
        {
            currentState = BossState.Summon;
    }
}
    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        Debug.Log("Boss: Đang đuổi theo Player.");
    }

    public void TakeDamage(int damageAmount)
    {
        bossHealth -= damageAmount;
        Debug.Log($"Boss: Bị tấn công! Mất {damageAmount} máu. Máu còn lại: {bossHealth}");

        if (bossHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Boss: Đã bị tiêu diệt!");
        animator.SetTrigger("Die");
        DestroyAllMinions();
        DropLoot();
        currentState = BossState.Dead;
    }
    private void DestroyAllMinions()
    {
        SummonMinion_Controller[] activeMinions = FindObjectsByType<SummonMinion_Controller>(FindObjectsSortMode.None);

        int destroyedCount = 0;
        foreach (SummonMinion_Controller minion in activeMinions)
        {
            minion.DieImmediately();
            destroyedCount++;
        }
        Debug.Log($"Boss đã hủy diệt {destroyedCount} Quỷ con còn sót lại.");
    }
    public void MinionDied(int slotIndex)
    {
        if (maxMinionCount > 0)
        {
            maxMinionCount--;
        }

        if (slotIndex >= 0 && slotIndex < minionSlotOccupied.Length)
        {
            minionSlotOccupied[slotIndex] = false;
        }

        if (maxMinionCount < 3)
        {
            currentState = BossState.Summon;
            lastAbilityTime = Time.time;
        }
    }
    private void DropLoot()
    {
        if (item == null)
        {
            Debug.Log("Không có vật phẩm nào được định nghĩa để rơi.");
            return;
        }
        GameObject lootToDrop = item;
        Vector3 dropPosition = transform.position + new Vector3(0.5f,0.5f, 0);
        Instantiate(lootToDrop, dropPosition, Quaternion.identity);
        Debug.Log($"Đã rơi vật phẩm: {lootToDrop.name} tại {dropPosition}");
    }
    private void PerformShockwaveAttack()
    {
        Debug.Log("Boss: Bắt đầu Sóng xung kích.");
        // Bắt đầu Coroutine để quản lý chuỗi hành động: Animation -> Chờ -> Tạo sóng
        StartCoroutine(ShockwaveRoutine());
        lastAbilityTime = Time.time;
    }
    private IEnumerator ShockwaveRoutine()
    {
        animator.SetTrigger("Shockwave");

        yield return new WaitForSeconds(shockwaveDelay);

        Vector3 rightSpawnPosition = transform.position + transform.right * projectileOffset;
        Vector3 leftSpawnPosition = transform.position - transform.right * projectileOffset;

        GameObject wave1 = Instantiate(shockwavePrefab, rightSpawnPosition, Quaternion.identity);
        wave1.GetComponent<ShockwaveProjectile>().SetDirection(Vector3.right);

        GameObject wave2 = Instantiate(shockwavePrefab, leftSpawnPosition, Quaternion.identity);
        wave2.GetComponent<ShockwaveProjectile>().SetDirection(Vector3.left);

        Debug.Log("Boss: Sóng xung kích đã được phóng ra.");
    }
}
