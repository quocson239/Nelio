using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S9 : MonoBehaviour
{
    [SerializeField] GameObject milo;
    [SerializeField] GameObject nelio;
    [SerializeField] GameObject hpSystem;
    [SerializeField] GameObject undead;
    [SerializeField] GameObject bossHPSystem;

    [SerializeField] Image blackBg;
    [SerializeField] GameObject portal;
    [SerializeField] GameObject portal2;
    [SerializeField] GameObject closeGate;

    [Header("Gifts and Tutorials")]
    [SerializeField] GameObject gift;
    [SerializeField] GameObject tutorialE2;
    [SerializeField] GameObject eUp2;


    [Header("Victory and Dead Panels")]
    [SerializeField] Image VicPan;
    [SerializeField] TextMeshProUGUI vicTitle;
    [SerializeField] Image DeadPan;
    [SerializeField] TextMeshProUGUI deadTitle;
    [SerializeField] TextMeshProUGUI deadTitle2;


    [Header("Dialogs")]
    [SerializeField] GameObject dialog1Start;
    [SerializeField] GameObject dialog1End;
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
    [SerializeField] GameObject dialog8Start;
    [SerializeField] GameObject dialog8End;
    [SerializeField] GameObject dialog9Start;
    [SerializeField] GameObject dialog9End;
    [SerializeField] GameObject dialog10Start;
    [SerializeField] GameObject dialog10End;
    [SerializeField] GameObject dialog11Start;
    [SerializeField] GameObject dialog11End;

    [Header("Camera")]
    [SerializeField] GameObject cam1;
    [SerializeField] GameObject cam2;
    [SerializeField] GameObject cam3;

    [Header("Audio")]
    [SerializeField] AudioSource bgMusic;
    [SerializeField] AudioSource bgMusic2;
    [SerializeField] AudioSource portalSound;
    [SerializeField] AudioSource hitSound;
    [SerializeField] AudioSource victorySound;
    [SerializeField] AudioSource deadSound;
    [SerializeField] AudioSource giftSound;    
    [SerializeField] AudioSource pulleySound;
    [SerializeField] AudioSource doorHitGroundSound;
    [SerializeField] AudioSource jumpSound;
    void Start()
    {
        StartCoroutine(NelioDead());
        StartCoroutine(NelioBlock1());
        StartCoroutine(PlayScene9());
    }
    
    void Update()
    {
        if (tutorialE2.activeSelf)
        {
            eUp2.SetActive(!Input.GetKey(KeyCode.E));
        }
    }



    IEnumerator PlayScene9()
    {
        bgMusic.Play();
        milo.transform.position = new Vector3(2.55f, -1.4f, 0);
        nelio.transform.position = new Vector3(-8.3f, -1.3f, 0);
        blackBg.gameObject.SetActive(true);
        hpSystem.SetActive(false);
        portal.SetActive(false);
        nelio.SetActive(false);
        nelio.GetComponent<P_Block>().isBlock = true;
        undead.SetActive(false);
        yield return new WaitForSeconds(0.5f);        
        yield return StartCoroutine(BGApear());
        yield return new WaitForSeconds(0.5f);
        dialog1Start.SetActive(true);
        yield return new WaitUntil(() => dialog1Start.GetComponent<Dialog>().index > dialog1Start.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog1Start.activeSelf);
        yield return new WaitForSeconds(0.5f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal.SetActive(true);
        nelio.SetActive(true);
        nelio.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        milo.transform.localScale = new Vector3(-1, 1, 1);
        nelio.GetComponent<Animator>().SetBool("isRun", true);
        nelio.GetComponent<SpriteRenderer>().enabled = true;
        nelio.GetComponent<Rigidbody2D>().gravityScale = 0;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(1.5f, 0);
        yield return new WaitUntil(() => nelio.transform.position.x >= -7f);
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Rigidbody2D>().gravityScale = 1;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(0.5f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal.SetActive(false);
        yield return new WaitForSeconds(2f);
        dialog2Start.SetActive(true);
        yield return new WaitUntil(() => dialog2End.GetComponent<Dialog>().index > dialog2End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog2End.activeSelf);
        yield return new WaitForSeconds(0.5f);
        nelio.GetComponent<Animator>().SetBool("isRun", true);
        nelio.GetComponent<SpriteRenderer>().enabled = true;
        nelio.GetComponent<Rigidbody2D>().gravityScale = 0;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(1.5f, 0);
        yield return new WaitUntil(() => nelio.transform.position.x >= -4f);        
        nelio.GetComponent<Rigidbody2D>().gravityScale = 1;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(5, 3);
        nelio.GetComponent<Animator>().SetTrigger("Jump");
        jumpSound.Play();
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => nelio.GetComponent<P_Jump>().isGround());        
        nelio.GetComponent<Animator>().SetBool("isRun", true);
        nelio.GetComponent<SpriteRenderer>().enabled = true;
        nelio.GetComponent<Rigidbody2D>().gravityScale = 0;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 0);
        milo.GetComponent<Animator>().SetBool("isRun", true);
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-2, 0);
        yield return new WaitUntil(() => Mathf.Abs(nelio.transform.position.x - milo.transform.position.x) <= 0.8f);
        milo.GetComponent<Animator>().SetBool("isRun", false);
        milo.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        BlockNelio();
        yield return new WaitForSeconds(0.5f);
        dialog3Start.SetActive(true);
        yield return new WaitUntil(() => dialog3End.GetComponent<Dialog>().index > dialog3End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog3End.activeSelf);
        yield return new WaitForSeconds(0.5f);
        milo.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(0.5f);
        dialog4Start.SetActive(true);
        yield return new WaitUntil(() => dialog4End.GetComponent<Dialog>().index > dialog4End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog4End.activeSelf);
        yield return new WaitForSeconds(0.5f);
        UnblockNelio();
        hpSystem.SetActive(true);
        yield return new WaitUntil(() => nelio.transform.position.x >= 5f);
        milo.GetComponent<Animator>().SetBool("isRun", true);
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 0f);
        yield return new WaitUntil(() => milo.transform.position.x >= 2f);
        milo.GetComponent<Animator>().SetBool("isRun", false);
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 5f);
        milo.GetComponent<Animator>().SetTrigger("Jump");
        if (milo.GetComponent<SpriteRenderer>().isVisible) jumpSound.Play();
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => milo.GetComponent<Milo_Jump>().isGround());
        //milo.GetComponent<Rigidbody2D>().gravityScale = 1;
        milo.GetComponent<Animator>().SetBool("isRun", true);
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 0f);
        yield return new WaitUntil(() => milo.transform.position.x >= 4.5f);
        milo.GetComponent<Animator>().SetBool("isRun", false);
        milo.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        yield return new WaitUntil(() => nelio.transform.position.x >= 12f);
        milo.GetComponent<Animator>().SetBool("isRun", true);
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 0f);
        yield return new WaitUntil(() => milo.transform.position.x >= 12f);
        milo.GetComponent<Animator>().SetBool("isRun", false);
        milo.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        yield return new WaitUntil(() => nelio.transform.position.x >= 18f);
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(5f, 3f);
        milo.GetComponent<Animator>().SetTrigger("Jump");
        if (milo.GetComponent<SpriteRenderer>().isVisible) jumpSound.Play();
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => milo.GetComponent<Milo_Jump>().isGround());
        milo.GetComponent<Animator>().SetBool("isRun", true);
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 0f);
        yield return new WaitUntil(() => milo.transform.position.x >= 17.5f);
        milo.GetComponent<Animator>().SetBool("isRun", false);
        milo.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        yield return new WaitUntil(() => nelio.transform.position.x >= 22f);
        BlockNelio();        
        milo.GetComponent<Animator>().SetBool("isRun", true);
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 0f);
        yield return new WaitUntil(() => milo.transform.position.x >= 21f);
        milo.GetComponent<Animator>().SetBool("isRun", false);
        milo.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
        nelio.transform.localScale = new Vector3(-1, 1, 1);
        yield return new WaitForSeconds(0.5f);
        dialog5Start.SetActive(true);
        yield return new WaitUntil(() => dialog5End.GetComponent<Dialog>().index > dialog5End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog5End.activeSelf);
        yield return new WaitForSeconds(0.5f);
        UnblockNelio();
        yield return new WaitUntil(() => nelio.transform.position.x >= 27f);
        BlockNelio();
        yield return StartCoroutine(Slow());
        yield return new WaitForSeconds(0.5f);
        cam2.SetActive(true);
        cam1.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        undead.SetActive(true);
        undead.transform.localScale = new Vector3(-1, 1, 1);
        yield return new WaitForSeconds(0.5f);
        dialog6Start.SetActive(true);
        yield return new WaitUntil(() => dialog6End.GetComponent<Dialog>().index > dialog6End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog6End.activeSelf);
        yield return new WaitForSeconds(0.5f);
        bgMusic.Stop();
        bgMusic2.Play();
        bossHPSystem.SetActive(true);
        UnblockNelio();
        yield return new WaitUntil(() => undead.GetComponent<EnemyLife>().isDead);        
        bgMusic2.Stop();
        BlockNelio();
        yield return new WaitForSeconds(1f);
        nelio.transform.localScale = new Vector3(undead.transform.position.x > nelio.transform.position.x ? 1 : -1, 1, 1);
        yield return new WaitForSeconds(0.5f);
        dialog7Start.SetActive(true);
        yield return new WaitUntil(() => dialog7End.GetComponent<Dialog>().index > dialog7End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog7End.activeSelf);
        yield return new WaitForSeconds(0.5f);
        bossHPSystem.SetActive(false);
        undead.SetActive(false);
        yield return StartCoroutine(VicPanShow());
        yield return new WaitForSeconds(1f);
        bgMusic.Play();
        giftSound.Play();
        gift.SetActive(true);
        tutorialE2.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        yield return new WaitForSeconds(0.3f);
        gift.SetActive(false);
        tutorialE2.SetActive(false);
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(0.5f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal2.SetActive(true);
        yield return new WaitForSeconds(2f);
        cam3.SetActive(true);
        cam2.SetActive(false);
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(Slow2());
        yield return new WaitForSeconds(0.5f);
        nelio.transform.localScale = new Vector3(-1, 1, 1);
        dialog8Start.SetActive(true);
        yield return new WaitUntil(() => dialog8End.GetComponent<Dialog>().index > dialog8End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog8End.activeSelf);
        yield return new WaitForSeconds(0.5f);
        milo.GetComponent<Animator>().SetBool("isRun", true);
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 0f);
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => Mathf.Abs(nelio.transform.position.x - milo.transform.position.x) <= 1f);
        milo.GetComponent<Animator>().SetBool("isRun", false);
        milo.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        cam2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        dialog9Start.SetActive(true);
        yield return new WaitUntil(() => dialog9End.GetComponent<Dialog>().index > dialog9End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog9End.activeSelf);
        yield return new WaitForSeconds(0.5f);
        milo.GetComponent<Animator>().SetBool("isRun", true);
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 0f);
        yield return new WaitUntil(() => milo.transform.position.x >= 40.5f);
        milo.SetActive(false);
        nelio.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(1f);
        nelio.GetComponent<Animator>().SetBool("isRun", true);
        nelio.GetComponent<SpriteRenderer>().enabled = true;
        nelio.GetComponent<Rigidbody2D>().gravityScale = 0;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 0);
        yield return new WaitUntil(() => nelio.transform.position.x >= 40f);
        BlockNelio();
        dialog10Start.SetActive(true);
        yield return new WaitUntil(() => dialog10End.GetComponent<Dialog>().index > dialog10End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog10End.activeSelf);
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(0.5f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal2.SetActive(false);
        yield return new WaitForSeconds(2f);
        dialog11Start.SetActive(true);
        yield return new WaitUntil(() => dialog11End.GetComponent<Dialog>().index > dialog11End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog11End.activeSelf);
        StartCoroutine(NextScene10());

    }

    IEnumerator NextScene10()
    {
        blackBg.CrossFadeAlpha(0, 0.1f, false);
        yield return new WaitForSeconds(0.5f);
        blackBg.gameObject.SetActive(true);
        blackBg.CrossFadeAlpha(1, 5f, false);
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("S10");
    }

    IEnumerator Slow()
    {
        InvokeRepeating("GoDown", 0, 0.1f);
        pulleySound.Play();
        yield return new WaitUntil(() => closeGate.transform.position.y < 0f);
        pulleySound.Stop();
        doorHitGroundSound.Play();
        CancelInvoke();
    }
    void GoDown()
    {
        closeGate.transform.position += new Vector3(0, -0.1f, 0);
    }

    IEnumerator Slow2()
    {
        InvokeRepeating("GoUp", 0, 0.1f);
        pulleySound.Play();
        yield return new WaitUntil(() => closeGate.transform.position.y > 7f);
        pulleySound.Stop();
        CancelInvoke();
    }
    void GoUp()
    {
        closeGate.transform.position += new Vector3(0, 0.1f, 0);
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
        yield return new WaitUntil(() => nelio.transform.position.x >= 22f);
        nelio.GetComponent<P_Block>().isBlock = true;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
    }

    IEnumerator NelioDead()
    {
        yield return new WaitUntil(() => nelio.GetComponent<P_Life>().isDead);
        yield return StartCoroutine(DeadPanShow());
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.R));
        SceneManager.LoadScene("S9Undead");
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
