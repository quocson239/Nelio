using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WarningZone : MonoBehaviour
{
    public float warningDuration = 1.5f;
    void OnEnable()
    {
        Invoke("TriggerAttack", warningDuration);
    }

    void TriggerAttack()
    {
        if (BulletPool.isBulletFrozen)
        {
            gameObject.SetActive(false); 
            return;
        }
        GameObject BeastGhostBullet = BulletPool.Instance.GetBeastGhostBullet();
        BeastGhostBullet.transform.position = transform.position;
        BeastGhostBullet.GetComponent<BeastGhostBullet_>().SetDirection(Vector3.up);
        gameObject.SetActive(false); 
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
