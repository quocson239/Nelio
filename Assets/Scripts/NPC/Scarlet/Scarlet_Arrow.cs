using UnityEngine;

public class Scarlet_Arrow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Dog"))
        {            
            Destroy(this.gameObject);
        } 
        if (c.gameObject.CompareTag("Player") && !c.GetComponent<P_Dash>().isImmute)
        {
            StartCoroutine(c.GetComponent<P_Hurt>().Hurt());
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(this.gameObject,1f);
        }
    }
}
