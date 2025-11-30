using System.Collections;
using UnityEngine;

public class Block2TorchChallenge : MonoBehaviour
{
    public GameObject[] fires;
    public int active = 0;
    public bool challengeSuccess;
    public GameObject bridge;
    public GameObject cam;
    bool camActive = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 2; i++)
        {
            fires[i].SetActive(i < active);
        }
        if(active == 2)
        {
            challengeSuccess = true;
        }
        bridge.SetActive(challengeSuccess);
        if(challengeSuccess && !camActive)
        {
            camActive = true;
            StartCoroutine(Cam());
        }
    }
    
    IEnumerator Cam()
    {
        cam.SetActive(true);
        yield return new WaitForSeconds(4f);
        cam.SetActive(false);
    }
}
