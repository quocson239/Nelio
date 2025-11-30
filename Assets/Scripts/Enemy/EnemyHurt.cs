using System.Collections;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    [SerializeField] Material white;

    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Hurt()
    {
        if(GetComponent<Undead_Controller>() != null)
            GetComponent<Undead_Controller>().TakeDamage(1);
        if(GetComponent<BeastGhostController>() != null)
            GetComponent<BeastGhostController>().TakeDamage(1);
        if (GetComponent<SummonMinion_Controller>() != null)
            GetComponent<SummonMinion_Controller>().TakeDamage(1);
        Material cur = sr.material;
        sr.material = white;
        yield return new WaitForSeconds(0.1f);
        sr.material = cur;
    }
}
