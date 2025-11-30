using UnityEngine;

public class Trap : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.GetComponent<P_Dash>().isImmute && gameObject.CompareTag("trap"))
        {
            Debug.Log("Trap Hit Player");
            GameObject.Find("DialogSystem").GetComponent<SceneControll>().TriggerDialog3();
            P_Life bullet = other.GetComponent<P_Life>();
            bullet.hp--;
        }
    }
}
