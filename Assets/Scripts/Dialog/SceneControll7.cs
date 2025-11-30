using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class SceneControll : MonoBehaviour
{
    public GameObject dialog1Start;
    public GameObject dialog2Start;
    public GameObject dialog3Start;
    public GameObject dialog4Start;
    public GameObject dialog6Start;
    public GameObject dialog7Start;
    public GameObject dialog8Start;
    public GameObject dialog9Start;
    public GameObject dialog10Start;
    public GameObject dialog11Start;
    public GameObject dialog12Start;
    public GameObject dialog13Start;

    public GameObject Nelio;
    public GameObject losmind;

    public GameObject Warning; 
    private bool isWarningShown = false;

    public GameObject closeMap;
    //public GameObject closeMap2;


    public CinemachineCamera cam1;
    public CinemachineCamera cam2;
    public CinemachineCamera cam3;

    public GameObject map1;
    public GameObject map2;

    public GameObject ShakeCam;

    public GameObject fireEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(A1());
        losmind.SetActive(false);
        map1.SetActive(false);
        map2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    IEnumerator A1()
    {
        Nelio.GetComponent<Animator>().SetBool("isRun", false);
        Nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        Nelio.GetComponent<P_Block>().isBlock = true;
        dialog1Start.SetActive(true);
        yield return new WaitUntil(() => dialog1Start.GetComponent<Dialog>().index > dialog1Start.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog1Start.activeSelf);
        Nelio.GetComponent<P_Block>().isBlock = false;
        yield return new WaitUntil(() => Nelio.transform.position.x > 5.49f);
        Nelio.GetComponent<P_Block>().isBlock = true;
        Nelio.GetComponent<Animator>().SetBool("isRun", false);
        Nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        dialog2Start.SetActive(true);
        yield return new WaitUntil(() => dialog2Start.GetComponent<Dialog>().index > dialog2Start.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog2Start.activeSelf);
        Nelio.GetComponent<P_Block>().isBlock = false;


        yield return new WaitUntil(() => Nelio.transform.position.x > 30.96f);
        SwitchToCam2();
        StartCoroutine(Slow());
        BulletPool.isBulletFrozen = true;        
        Nelio.GetComponent<P_Block>().isBlock = true;
        Nelio.GetComponent<Animator>().SetBool("isRun", false);
        Nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        losmind.SetActive(true);
        dialog4Start.SetActive(true); 
        yield return new WaitUntil(() => dialog6Start.GetComponent<Dialog>().index > dialog6Start.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog6Start.activeSelf);
        if (!Player_Trap_Effect.instance.isStunned)
        {
            Nelio.GetComponent<P_Block>().isBlock = false;
        }

        yield return new WaitForSeconds(0.5f);
        BulletPool.isBulletFrozen = false;

        yield return new WaitUntil(() => losmind.GetComponent<BeastGhostController>().isDead == true);
        BulletPool.isBulletFrozen = true;
        Nelio.GetComponent<P_Block>().isBlock = true;
        Nelio.GetComponent<Animator>().SetBool("isRun", false);
        Nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        dialog7Start.SetActive(true);
        yield return new WaitUntil(() => dialog8Start.GetComponent<Dialog>().index > dialog8Start.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog8Start.activeSelf);
        losmind.GetComponent<Animator>().SetTrigger("isDisappear");
        yield return new WaitForSeconds(1f);
        
        dialog9Start.SetActive(true);
        yield return new WaitUntil(() => dialog9Start.GetComponent<Dialog>().index > dialog9Start.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog9Start.activeSelf);
        Nelio.transform.localScale = new Vector3(1, 1, 1);
        Nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(Vector2.right.x + 2f, Nelio.GetComponent<Rigidbody2D>().linearVelocity.y);
        Nelio.GetComponent<Animator>().SetBool("isRun", true);
        yield return new WaitUntil(() => Nelio.transform.position.x > 50.6f);
        Nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        Nelio.GetComponent<Animator>().SetBool("isRun", false);

        dialog10Start.SetActive(true);
        yield return new WaitUntil(() => dialog10Start.GetComponent<Dialog>().index > dialog10Start.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog10Start.activeSelf);
        Nelio.transform.localScale = new Vector3(-1, 1, 1);
        Nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(Vector2.left.x -2f, Nelio.GetComponent<Rigidbody2D>().linearVelocity.y);
        Nelio.GetComponent<Animator>().SetBool("isRun", true);

        yield return new WaitUntil(() => Nelio.transform.position.x < 48.15f);
        Nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        Nelio.GetComponent<Animator>().SetBool("isRun", false);

        StartCoroutine(Slow2());
        dialog11Start.SetActive(true);
        yield return new WaitUntil(() => dialog11Start.GetComponent<Dialog>().index > dialog11Start.GetComponent<Dialog>().lines.Length - 1
                                   && !dialog11Start.activeSelf);
        Nelio.transform.localScale = new Vector3(-1, 1, 1);
        Nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(Vector2.left.x - 2f, Nelio.GetComponent<Rigidbody2D>().linearVelocity.y);
        Nelio.GetComponent<Animator>().SetBool("isRun", true);
        yield return new WaitUntil(() => Nelio.transform.position.x < 45.03f);
        Nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        Nelio.GetComponent<Animator>().SetBool("isRun", false);
        dialog12Start.SetActive(true);
        yield return new WaitUntil(() => dialog12Start.GetComponent<Dialog>().index > dialog12Start.GetComponent<Dialog>().lines.Length - 1
                                   && !dialog12Start.activeSelf);
        yield return new WaitUntil(() => ShakeCam.GetComponent<CameraShake>().ShakeCam());

        map2.SetActive(false);
        map1.SetActive(true);
        Warning.SetActive(false);
        fireEffect.SetActive(false);
        dialog13Start.SetActive(true);
        yield return new WaitUntil(() => dialog13Start.GetComponent<Dialog>().index > dialog13Start.GetComponent<Dialog>().lines.Length - 1
                                   && !dialog13Start.activeSelf);
        cam3.Priority = 20;
        cam3.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-5f, 0);
        yield return new WaitUntil(() => cam3.transform.position.x <= 1.5);
        cam3.Priority = -1;
        Nelio.GetComponent<P_Block>().isBlock = false;
        yield return new WaitUntil(() => Nelio.transform.position.x < 30.16f);
        SwitchToCam1();
    }
    public void TriggerDialog3()
    {
        if (isWarningShown) return;
        if (isWarningShown == false)
        {
            StartCoroutine(A2());
            isWarningShown = true;
        }
    }
    IEnumerator A2()
    {
        Nelio.GetComponent<Animator>().SetBool("isRun", false);
        Nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        Nelio.GetComponent<P_Block>().isBlock = true;
        dialog3Start.SetActive(true);
        yield return new WaitUntil(() => dialog3Start.GetComponent<Dialog>().index > dialog3Start.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog1Start.activeSelf);
        Nelio.GetComponent<P_Block>().isBlock = false;
    }
    IEnumerator Slow()
    {
        InvokeRepeating("GoDown", 0, 0.1f);
        yield return new WaitUntil(() => closeMap.transform.position.y < 0f);
        CancelInvoke();
    }
    void GoDown()
    {
        closeMap.transform.position += new Vector3(0, -0.1f, 0);
        //closeMap2.transform.position += new Vector3(0, 0.1f, 0);
    }
    IEnumerator Slow2()
    {
        InvokeRepeating("GoUp", 0, 0.1f);
        yield return new WaitUntil(() => closeMap.transform.position.y > 6.76f);
        CancelInvoke();
    }
    void GoUp()
    {
        closeMap.transform.position += new Vector3(0, 0.1f, 0);
        //closeMap2.transform.position += new Vector3(0, -0.1f, 0);
    }
    void SwitchToCam2()
    {
        cam1.Priority = 0;
        cam2.Priority = 10;
    }
    void SwitchToCam1()
    {
        cam1.Priority = 10;
        cam2.Priority = 0;
    }
}
