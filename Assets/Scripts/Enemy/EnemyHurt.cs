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
        GetComponent<Undead_Controller>().bossHealth -= 1;
        Material cur = sr.material;
        sr.material = white;
        yield return new WaitForSeconds(0.1f);
        sr.material = cur;
    }
}
