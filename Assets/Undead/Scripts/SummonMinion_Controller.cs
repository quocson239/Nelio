using System.Collections;
using UnityEngine;

public class SummonMinion_Controller : MonoBehaviour
{
    private Transform boss;
    private Transform player;
    private GameObject nelio;
    public int health = 3;
    public float followDistance = 3f;

    public Transform firePoint;
    public float speed = 3f;
    public float fireRate = 2f;
    public GameObject bulletPrefab;

    private enum MinionState { Spawning, IdleFollow, Dead }
    private MinionState currentState = MinionState.Spawning;
    private float lastFireTime;

    private Animator animator;

    private Undead_Controller bossController;
    private Vector3 fixedFollowOffset;
    private int mySlotIndex;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(SpawningRoutine());
        boss = GameObject.FindGameObjectWithTag("Enemy").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nelio = GameObject.Find("Nelio");
    }
    public void SetMySlotIndex(int index)
    {
        mySlotIndex = index;
    }
    public void SetFollowOffset(Vector3 offset)
    {
        fixedFollowOffset = offset;
    }
    public void SetBossController(Undead_Controller controller)
    {
        bossController = controller;
    }
    void Update()
    {
        if (nelio.GetComponent<P_Life>().hp > 0)
        {
            switch (currentState)
            {
                case MinionState.Spawning:
                    break;
                case MinionState.IdleFollow:
                    UpdateRotation(player.position);
                    FollowBoss();
                    TryFireAtPlayer();
                    break;
                case MinionState.Dead:
                    break;
            }
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
                Debug.Log("Minion: Lật sang phải.");
            }
        }
        else if (direction.x < 0)
        {
            if (currentScale.x > 0)
            {
                transform.localScale = new Vector3(-absScaleX, currentScale.y, currentScale.z);
                Debug.Log("Minion: Lật sang trái.");
            }
        }
    }

    IEnumerator SpawningRoutine()
    {
        animator.SetTrigger("Appear");
        yield return new WaitForSeconds(1.0f);
        currentState = MinionState.IdleFollow;
    }


    private void FollowBoss()
    {
        float offsetX = boss.localScale.x > 0 ? fixedFollowOffset.x : -fixedFollowOffset.x;

        Vector3 targetPosition = boss.position + new Vector3(offsetX, fixedFollowOffset.y, fixedFollowOffset.z);
        if (Vector3.Distance(transform.position, targetPosition) > followDistance)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.deltaTime
            );
        }
    }

    private void TryFireAtPlayer()
    {
        if (Time.time >= lastFireTime + fireRate)
        {
            Vector3 directionToPlayer = (player.position - transform.position);

            GameObject bulletObject = Instantiate(
                bulletPrefab,
                transform.position,
                Quaternion.identity
            );

            MinionProjectile bulletScript = bulletObject.GetComponent<MinionProjectile>();
            if (bulletScript != null)
            {
                bulletScript.Initialize(directionToPlayer);
            }
            UpdateRotation(player.position);
            Debug.Log("Quỷ con: Đã bắn đạn!");
            lastFireTime = Time.time;
        }
    }

    private void StartDeath()
    {
        animator.SetTrigger("Dead");

        if (bossController != null)
        {
            bossController.MinionDied(mySlotIndex);
        }
        Destroy(gameObject, 1.0f);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0 && currentState != MinionState.Dead)
        {
            currentState = MinionState.Dead;
            StartDeath();
        }
    }
    public void DieImmediately()
    {
        if (currentState != MinionState.Dead)
        {
            Debug.Log("Quỷ con: Bị Boss hủy diệt!");

            currentState = MinionState.Dead;

            animator.SetTrigger("Dead");

            Destroy(gameObject, 0.5f);
        }
    }
}