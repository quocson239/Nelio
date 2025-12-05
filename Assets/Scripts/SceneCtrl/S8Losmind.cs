using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S8Losmind : MonoBehaviour
{
    
    [SerializeField] GameObject nelio;
    [SerializeField] GameObject hpSystem;
    [SerializeField] GameObject losmind;
    [SerializeField] GameObject bossHPSystem;
    [SerializeField] Image blackBg;
    [SerializeField] GameObject portal;

    public GameObject Warning;    
    public GameObject closeMap;    
    public GameObject map1;
    public GameObject map2;    
    public GameObject fireEffect;

    [Header("Gifts and Tutorials")]
    [SerializeField] GameObject gift;
    [SerializeField] GameObject tutorialE2;
    [SerializeField] GameObject eUp2;


    [Header("Camera")]
    [SerializeField] GameObject cam1;
    [SerializeField] GameObject cam2;
    [SerializeField] GameObject cam3;


    [Header("Victory and Dead Panels")]
    [SerializeField] Image VicPan;
    [SerializeField] TextMeshProUGUI vicTitle;
    [SerializeField] Image DeadPan;
    [SerializeField] TextMeshProUGUI deadTitle;
    [SerializeField] TextMeshProUGUI deadTitle2;


    [Header("Dialogs")]
    [SerializeField] GameObject dialog1Start;
    [SerializeField] GameObject dialog2Start;
    [SerializeField] GameObject dialog2End;
    [SerializeField] GameObject dialog3Start;
    [SerializeField] GameObject dialog3End;
    [SerializeField] GameObject dialog4Start;
    [SerializeField] GameObject dialog4End; 
    [SerializeField] GameObject dialog5Start;
    [SerializeField] GameObject dialog5End;
    [SerializeField] GameObject dialog6Start;
    [SerializeField] GameObject dialog6End;
    [SerializeField] GameObject dialog7Start;
    [SerializeField] GameObject dialog7End;

    [Header("Audio")]
    [SerializeField] AudioSource bgMusic;
    [SerializeField] AudioSource bgMusic2;
    [SerializeField] AudioSource portalSound;
    [SerializeField] AudioSource hitSound;
    [SerializeField] AudioSource victorySound;
    [SerializeField] AudioSource deadSound;
    [SerializeField] AudioSource giftSound;
    [SerializeField] AudioSource fireSound;
    [SerializeField] AudioSource pulleySound;
    [SerializeField] AudioSource doorHitGroundSound;
    void Start()
    {
        StartCoroutine(NelioDead());

        StartCoroutine(PlayScene8());        
        map1.SetActive(true);
        map2.SetActive(false);
    }

    void Update()
    {
        if (tutorialE2.activeSelf)
        {
            eUp2.SetActive(!Input.GetKey(KeyCode.E));
        }
    }
    IEnumerator PlayScene8()
    {
        bgMusic.Play();        
        nelio.transform.position = new Vector3(-3.5f, -0.5f, 0);
        blackBg.gameObject.SetActive(true);
        hpSystem.SetActive(false);
        portal.SetActive(false);
        nelio.SetActive(false);
        nelio.GetComponent<P_Block>().isBlock = true;
        losmind.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        fireSound.Play();
        yield return StartCoroutine(BGApear());
        yield return new WaitForSeconds(0.5f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal.SetActive(true);
        nelio.SetActive(true);
        nelio.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        nelio.GetComponent<Animator>().SetBool("isRun", true);
        nelio.GetComponent<SpriteRenderer>().enabled = true;
        nelio.GetComponent<Rigidbody2D>().gravityScale = 0;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(1.5f, 0);
        yield return new WaitUntil(() => nelio.transform.position.x >= -2.5f);
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Rigidbody2D>().gravityScale = 1;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(0.5f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal.SetActive(false);
        yield return new WaitForSeconds(2f);
        dialog1Start.SetActive(true);
        yield return new WaitUntil(() => dialog1Start.GetComponent<Dialog>().index > dialog1Start.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog1Start.activeSelf);
        yield return new WaitForSeconds(0.5f);
        UnblockNelio();
        hpSystem.SetActive(true);
        yield return new WaitUntil(() => nelio.transform.position.x >= 31.3f);
        fireSound.Stop();
        BlockNelio();
        cam2.SetActive(true);
        cam1.SetActive(false);        
        yield return StartCoroutine(Slow());
        losmind.SetActive(true);
        losmind.transform.localScale = new Vector3(-1, 1, 1);
        //tele fx
        yield return new WaitForSeconds(1f);
        dialog2Start.SetActive(true);
        yield return new WaitUntil(() => dialog2End.GetComponent<Dialog>().index > dialog2End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog2End.activeSelf);
        yield return new WaitForSeconds(0.5f);
        bgMusic.Stop();
        bgMusic2.Play();
        bossHPSystem.SetActive(true);
        UnblockNelio();
        losmind.GetComponent<BeastGhostController>().isBattle = true;
        yield return new WaitUntil(() => losmind.GetComponent<EnemyLife>().isDead);
        losmind.GetComponent<BeastGhostController>().isBattle = false;
        bgMusic2.Stop();
        BlockNelio();
        yield return new WaitForSeconds(1f);
        nelio.transform.localScale = new Vector3(losmind.transform.position.x > nelio.transform.position.x ? 1 : -1, 1, 1);
        dialog3Start.SetActive(true);
        yield return new WaitUntil(() => dialog3End.GetComponent<Dialog>().index > dialog3End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog3End.activeSelf);
        bossHPSystem.SetActive(false);
        losmind.SetActive(false);
        yield return StartCoroutine(VicPanShow());
        bgMusic.Play();
        yield return new WaitForSeconds(1f);
        giftSound.Play();
        gift.SetActive(true);
        tutorialE2.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        yield return new WaitForSeconds(0.3f);
        gift.SetActive(false);
        tutorialE2.SetActive(false);
        yield return new WaitForSeconds(1f);
        dialog4Start.SetActive(true);
        yield return new WaitUntil(() => dialog4End.GetComponent<Dialog>().index > dialog4End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog4End.activeSelf);
        yield return new WaitForSeconds(0.5f);
        nelio.transform.localScale = new Vector3(-1, 1, 1);
        yield return new WaitForSeconds(0.5f);
        nelio.transform.localScale = new Vector3(1, 1, 1);
        dialog5Start.SetActive(true);
        yield return new WaitUntil(() => dialog5End.GetComponent<Dialog>().index > dialog5End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog5End.activeSelf);
        yield return new WaitForSeconds(0.5f);
        nelio.transform.localScale = new Vector3(-1, 1, 1);
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(Slow2());
        dialog6Start.SetActive(true);
        yield return new WaitUntil(() => dialog6End.GetComponent<Dialog>().index > dialog6End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog6End.activeSelf);
        fireEffect.SetActive(false);
        StartCoroutine(ShakeCam());
        map2.SetActive(true);
        map1.SetActive(false);
        hpSystem.SetActive(false);
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(MoveCam231());
        yield return new WaitForSeconds(0.5f);
        dialog7Start.SetActive(true);
        yield return new WaitUntil(() => dialog7End.GetComponent<Dialog>().index > dialog7End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog7End.activeSelf);
        yield return new WaitForSeconds(0.5f);
        UnblockNelio();
        hpSystem.SetActive(true);
        yield return new WaitUntil(() => nelio.transform.position.x <= -3.5f);
        nelio.SetActive(false);
        BlockNelio();
        yield return new WaitForSeconds(2f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal.SetActive(false);
        yield return StartCoroutine(NextScene9());
    }
    IEnumerator NextScene9()
    {
        blackBg.CrossFadeAlpha(0, 0.1f, false);
        yield return new WaitForSeconds(0.5f);
        blackBg.gameObject.SetActive(true);
        blackBg.CrossFadeAlpha(1, 5f, false);
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("S9Undead");
    }
    IEnumerator MoveCam231()
    {        
        cam3.SetActive(true);
        cam2.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        cam3.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-3f, 0);
        yield return new WaitUntil(() => cam3.transform.position.x <= 4f);
        cam3.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(0.5f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal.SetActive(true);
        yield return new WaitForSeconds(2f);
        cam1.SetActive(true);
        cam3.SetActive(false);
        yield return new WaitForSeconds(2f);
    }

    IEnumerator Slow()
    {
        InvokeRepeating("GoDown", 0, 0.1f);
        pulleySound.Play();
        yield return new WaitUntil(() => closeMap.transform.position.y < 0f);
        pulleySound.Stop();
        doorHitGroundSound.Play();
        CancelInvoke();
    }
    void GoDown()
    {
        closeMap.transform.position += new Vector3(0, -0.1f, 0);        
    }
    IEnumerator Slow2()
    {
        InvokeRepeating("GoUp", 0, 0.1f);
        pulleySound.Play();
        yield return new WaitUntil(() => closeMap.transform.position.y > 6.76f);
        pulleySound.Stop();
        CancelInvoke();
    }
    void GoUp()
    {
        closeMap.transform.position += new Vector3(0, 0.1f, 0);        
    }

    IEnumerator ShakeCam()
    {        
        InvokeRepeating("Shake", 0, 0.05f);
        yield return new WaitForSeconds(0.5f);
        CancelInvoke();
        cam2.transform.rotation = new Quaternion(0, 0, 0, 1);
    }

    void Shake()
    {
        cam2.transform.rotation = new Quaternion(0, 0, Random.Range(-0.1f, 0.1f), 1);
    }

    IEnumerator VicPanShow()
    {
        yield return new WaitForSeconds(0.1f);
        VicPan.CrossFadeAlpha(0f, 0.1f, false);
        vicTitle.CrossFadeAlpha(0f, 0.1f, false);
        yield return new WaitForSeconds(1f);
        VicPan.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        victorySound.Play();
        VicPan.CrossFadeAlpha(220 / 255f, 3f, false);
        vicTitle.CrossFadeAlpha(1f, 3f, false);
        yield return new WaitForSeconds(6f);
        VicPan.CrossFadeAlpha(0f, 3f, false);
        vicTitle.CrossFadeAlpha(0f, 3f, false);
        yield return new WaitForSeconds(3f);
        VicPan.gameObject.SetActive(false);
    }

    IEnumerator DeadPanShow()
    {
        yield return new WaitForSeconds(0.1f);
        DeadPan.CrossFadeAlpha(0f, 0.1f, false);
        deadTitle.CrossFadeAlpha(0f, 0.1f, false);
        deadTitle2.CrossFadeAlpha(0f, 0.1f, false);
        yield return new WaitForSeconds(1f);
        DeadPan.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        deadSound.Play();
        DeadPan.CrossFadeAlpha(220 / 255f, 3f, false);
        deadTitle.CrossFadeAlpha(1f, 3f, false);
        yield return new WaitForSeconds(6f);
        deadTitle2.CrossFadeAlpha(1f, 3f, false);
        yield return new WaitForSeconds(3f);
    }

    IEnumerator BGFade()
    {
        blackBg.CrossFadeAlpha(0, 0.1f, false);
        yield return new WaitForSeconds(0.5f);
        blackBg.gameObject.SetActive(true);
        blackBg.CrossFadeAlpha(1, 5f, false);
        yield return new WaitForSeconds(6f);
    }
    IEnumerator BGApear()
    {
        blackBg.CrossFadeAlpha(1, 0.1f, false);
        yield return new WaitForSeconds(0.5f);
        blackBg.gameObject.SetActive(true);
        blackBg.CrossFadeAlpha(0, 15f, false);
        yield return new WaitForSeconds(4f);
        blackBg.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(2f);
    }
    IEnumerator NelioBlock1()
    {
        yield return new WaitForSeconds(5f);
        yield return new WaitUntil(() => nelio.transform.position.x >= 55.5f);
        nelio.GetComponent<P_Block>().isBlock = true;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
    }

    IEnumerator NelioDead()
    {
        yield return new WaitUntil(() => nelio.GetComponent<P_Life>().isDead);
        yield return StartCoroutine(DeadPanShow());
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.R));
        SceneManager.LoadScene("S8Losmind");
    }

    void BlockNelio()
    {
        nelio.GetComponent<P_Block>().isBlock = true;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Rigidbody2D>().gravityScale = 1;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
    }

    void UnblockNelio()
    {
        nelio.GetComponent<P_Block>().isBlock = false;
    }
}
