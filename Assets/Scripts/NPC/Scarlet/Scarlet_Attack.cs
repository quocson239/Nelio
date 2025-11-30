using System.Collections;
using UnityEngine;

public class Scarlet_Attack : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject firePos;
    [SerializeField] float arrowSpeed;
    Rigidbody2D rb;
    Animator anim;

    [Header("Sounds")]
    [SerializeField] AudioSource BowSound;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
                
    }
    
    void Update()
    {
        
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
