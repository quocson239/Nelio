using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CloseMap : MonoBehaviour
{
    public GameObject closeMap;
    public GameObject closeMap2;
    public GameObject boss;
    public Transform player;
    public CinemachineCamera vcamFollow;
    public CinemachineCamera vcamFixed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(Slow());
            vcamFollow.Priority = 0;
            vcamFixed.Priority = 10;
            boss.SetActive(true);

            Debug.Log("Switched to fixed camera with blend.");
        }
    }
    IEnumerator Slow()
    {
        InvokeRepeating("GoDown", 0, 0.1f);
        yield return new WaitUntil(()=>closeMap.transform.position.y <1.5f );
        CancelInvoke();
        Destroy(gameObject);

    }
    void GoDown()
    {
        closeMap.transform.position += new Vector3(0, -0.1f, 0);
        closeMap2.transform.position += new Vector3(0, 0.1f, 0);
    }


}
