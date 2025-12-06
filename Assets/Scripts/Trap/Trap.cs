using UnityEngine;

public class Trap : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player") && !c.GetComponent<P_Dash>().isImmute && gameObject.CompareTag("trap"))
        {
            Debug.Log("Trap Hit Player");            
            StartCoroutine(c.GetComponent<P_Hurt>().Hurt());            
        }
    }
}
