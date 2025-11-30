using System.Collections.Generic;
using UnityEngine;

public class Robot_BulletPool : MonoBehaviour
{
    public static Robot_BulletPool Instance;
    public GameObject Robot_BulletPrefab;
    public int Robot_PoolSize = 5;
    private Queue<GameObject> robotBulletPool = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;
        InitializeRobotBulletPool();
    }
    void InitializeRobotBulletPool()
    {
        for (int i = 0; i < Robot_PoolSize; i++)
        {
            GameObject robot_bullet = Instantiate(Robot_BulletPrefab);
            robot_bullet.SetActive(false);
            robotBulletPool.Enqueue(robot_bullet);
        }
    }

    public GameObject GetRobotBullet()
    {
        if (robotBulletPool.Count > 0)
        {
            GameObject robot = robotBulletPool.Dequeue();
            robot.SetActive(true);
            return robot;
        }
        else
        {
            GameObject robot = Instantiate(Robot_BulletPrefab);
            return robot;
        }
    }
    public void ReturnRobotBullet(GameObject robot)
    {
        robot.SetActive(false);
        robotBulletPool.Enqueue(robot);
    }
}
