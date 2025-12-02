using System.Collections;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    [SerializeField] Material white;

    Animator animator;
    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Hurt()
    {        
        if(GetComponent<EnemyLife>() != null) GetComponent<EnemyLife>().hp -= 1;
        Material cur = sr.material;
        sr.material = white;
        yield return new WaitForSeconds(0.1f);
        sr.material = cur;
    }
}
