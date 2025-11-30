using UnityEngine;

public class Warning_Laser : MonoBehaviour
{
    public Transform Laserposition;
    public float warningDuration = 1.5f;
    void OnEnable()
    {
        Invoke("TriggerAttack", warningDuration);
    }

    void TriggerAttack()
    {
        GameObject robotbullet = Robot_BulletPool.Instance.GetRobotBullet();
        robotbullet.transform.position = Laserposition.position;
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

}
