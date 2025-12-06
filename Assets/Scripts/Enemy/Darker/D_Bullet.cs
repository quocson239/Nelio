using UnityEngine;

public class D_Bullet : MonoBehaviour
{
    [Header("----Sound----")]
    [SerializeField] AudioSource HitSound;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.CompareTag("Player") && !c.GetComponent<P_Dash>().isImmute)
        {
            c.GetComponent<P_Hurt>().GetHurt();
        }
    }
}
