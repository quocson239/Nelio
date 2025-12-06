using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] GameObject hpSystem;
    [SerializeField] Image hpBar;
    public float hp;
    public bool isDead;

    float maxHp;

    Rigidbody2D rb;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        maxHp = hp;
    }

    void Update()
    {
        if (hpSystem != null)
        {
            if (hpSystem.activeSelf)
            {
                hpBar.fillAmount = hp / maxHp;
            }
        }

        if (hp <= 0 && !isDead)
        {
            isDead = true;
            animator.SetTrigger("Dead");
        }
    }
}
