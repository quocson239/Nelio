using System.Collections;
using UnityEngine;

public class P_Life : MonoBehaviour
{
    public int hp;
    public bool isDead;

    [SerializeField] GameObject hpSystem;
    [SerializeField] GameObject[] hpOb;
    [SerializeField] GameObject[] hpFF;

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        animator.SetBool("isDead", isDead);
        if(hpSystem.activeSelf)
        {
            for(int i = 0; i < 9; i++)
            {
                hpOb[i].SetActive(i < hp);
                hpFF[i].SetActive(i < hp);
            }
        }
        if (hp <= 0)
        {
            isDead = true;
            GetComponent<P_Block>().isBlock = true;
            GetComponent<P_Hurt>().enabled = false;
            StartCoroutine(disappear());
        }
    }
    IEnumerator disappear()
    {
        yield return new WaitForSeconds(1.2f);
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
