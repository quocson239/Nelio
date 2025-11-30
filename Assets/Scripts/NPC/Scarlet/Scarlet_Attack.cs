using System.Collections;
using UnityEngine;

public class Scarlet_Attack : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject firePos;
    [SerializeField] float arrowSpeed;
    Rigidbody2D rb;
    Animator anim;


    bool isAction;
    bool isInCombo;
    [Header("Sounds")]
    [SerializeField] AudioSource BowSound;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
                
    }
    
    void Update()
    {
        if(!isInCombo && Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(Combo1());
        }
        if (!isInCombo && Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(Combo2());
        }
        if (!isInCombo && Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(Combo3());
        }
    }


    IEnumerator Combo1()
    {
        isInCombo = true;        
        yield return StartCoroutine(A1());
        yield return StartCoroutine(A2());        
        yield return new WaitForSeconds(2f);
        isInCombo = false;
    }
    IEnumerator Combo2()
    {
        isInCombo = true;        
        yield return StartCoroutine(A3());
        yield return StartCoroutine(A4());
        yield return StartCoroutine(A5());
        yield return new WaitForSeconds(2f);
        isInCombo = false;
    }
    IEnumerator Combo3()
    {
        isInCombo = true;
        yield return StartCoroutine(A1());
        yield return StartCoroutine(A2());
        yield return StartCoroutine(A3());
        yield return StartCoroutine(A4());
        yield return StartCoroutine(A5());
        yield return new WaitForSeconds(2f);
        isInCombo = false;
    }
    IEnumerator A1()
    {
        isAction = true;
        anim.SetTrigger("A1");
        yield return new WaitForSeconds(5f / 6f);        
        yield return new WaitForSeconds(1 / 6f);
        //HitA1();               
        isAction = false;
    }
    IEnumerator A2()
    {
        isAction = true;
        anim.SetTrigger("A2");
        yield return new WaitForSeconds(5f / 6f);
        yield return new WaitForSeconds(1 / 6f);
        //HitA1();               
        isAction = false;
    }
    IEnumerator A3()
    {
        isAction = true;
        anim.SetTrigger("A3");
        yield return new WaitForSeconds(5f / 6f);
        yield return new WaitForSeconds(1 / 6f);
        //HitA1();               
        isAction = false;
    }
    IEnumerator A4()
    {
        isAction = true;
        anim.SetTrigger("A4");
        yield return new WaitForSeconds(5f / 6f);
        yield return new WaitForSeconds(1 / 6f);
        //HitA1();               
        isAction = false;
    }
    IEnumerator A5()
    {
        isAction = true;
        anim.SetTrigger("A5");
        yield return new WaitForSeconds(5f / 6f);
        yield return new WaitForSeconds(1 / 6f);
        //HitA1();               
        isAction = false;
    }


    public void BowAttack()
    {
        anim.SetTrigger("BA");
        BowSound.Play();
        StartCoroutine(SpawnArrow());
    }

    IEnumerator SpawnArrow()
    {
        yield return new WaitForSeconds(5/6f);
        GameObject a = Instantiate(arrow, firePos.transform.position, Quaternion.Euler(0, 0, 0));
        a.GetComponent<Rigidbody2D>().linearVelocity = Vector2.left * arrowSpeed;
    }
}
