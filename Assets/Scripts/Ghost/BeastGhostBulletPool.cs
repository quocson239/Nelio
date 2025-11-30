using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;
    public GameObject BeastGhostBulletPrefab;
    public int BeastGhostPoolSize = 5;
    private Queue<GameObject> beastGhostBulletPool = new Queue<GameObject>();

    public GameObject BeastGhostBulletPrefab2;
    public int BeastGhostPoolSize2 = 5;
    private Queue<GameObject> beastGhostBulletPool2 = new Queue<GameObject>();

    public static bool isBulletFrozen = false;
    private void Awake()
    {
        Instance = this;
        InitializeBeastGhostBulletPool();
        InitializeBeastGhostBulletPool2();
    }
    void InitializeBeastGhostBulletPool()
    {
        for (int i = 0; i < BeastGhostPoolSize; i++)
        {
            GameObject beastGhost = Instantiate(BeastGhostBulletPrefab);
            beastGhost.SetActive(false);
            beastGhostBulletPool.Enqueue(beastGhost);
        }
    }
    void InitializeBeastGhostBulletPool2()
    {
        for (int i = 0; i < BeastGhostPoolSize2; i++)
        {
            GameObject beastGhost2 = Instantiate(BeastGhostBulletPrefab2);
            beastGhost2.SetActive(false);
            beastGhostBulletPool2.Enqueue(beastGhost2);
        }
    }

    public GameObject GetBeastGhostBullet()
    {
        if (isBulletFrozen) return null;
        if (beastGhostBulletPool.Count > 0)
        {
            GameObject BeastGhost = beastGhostBulletPool.Dequeue();
            BeastGhost.SetActive(true);
            return BeastGhost;
        }
        else
        {
            GameObject BeastGhost = Instantiate(BeastGhostBulletPrefab);
            return BeastGhost;
        }
    }
    public void ReturnBeastGhostBullet(GameObject beastGhostBullet)
    {
        beastGhostBullet.SetActive(false);
        beastGhostBulletPool.Enqueue(beastGhostBullet);
    }
    public GameObject GetBeastGhostBullet2()
    {
        if (isBulletFrozen) return null;
        if (beastGhostBulletPool2.Count > 0)
        {
            GameObject BeastGhost2 = beastGhostBulletPool2.Dequeue();
            BeastGhost2.SetActive(true);
            return BeastGhost2;
        }
        else
        {
            GameObject BeastGhost2 = Instantiate(BeastGhostBulletPrefab2);
            return BeastGhost2;
        }
    }
    public void ReturnBeastGhostBullet2(GameObject beastGhostBullet2)
    {
        beastGhostBullet2.SetActive(false);
        beastGhostBulletPool2.Enqueue(beastGhostBullet2);
    }
}
