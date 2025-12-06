using System.Collections;
using UnityEngine;

public class P_Hurt : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    public AudioSource takedameSound;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    public IEnumerator Hurt()
    {
        takedameSound.Play();
        animator.SetTrigger("Hurt");
        GetComponent<P_Life>().hp -= 1;
        GetComponent<P_Block>().isBlock = true;                
        GetComponent<P_Dash>().isImmute = true;
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(0.5f);
        GetComponent<P_Block>().isBlock = false;
        yield return new WaitForSeconds(0.7f);
        GetComponent<P_Dash>().isImmute = false;

    }

    public void GetHurt()
    {
        StartCoroutine(Hurt());
    }
}
