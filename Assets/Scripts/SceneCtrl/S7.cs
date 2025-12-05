using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S7 : MonoBehaviour
{
    [SerializeField] GameObject nelio;
    [SerializeField] GameObject hpSystem;
    [SerializeField] GameObject scarlet;
    [SerializeField] GameObject scarletBoss;
    [SerializeField] GameObject whiteLonelibetBoss;
    [SerializeField] Image blackBg;
    [SerializeField] GameObject portal;

    [SerializeField] GameObject scar_Sit;
    [SerializeField] GameObject firefly;

    [SerializeField] GameObject tutorialE;
    [SerializeField] GameObject eUp;
    [SerializeField] GameObject tutorialShift;
    [SerializeField] GameObject shiftDown;


    [SerializeField] GameObject portalE;
    [SerializeField] GameObject whiteLonelibet;
    [SerializeField] GameObject hitGhostPre;

    [SerializeField] GameObject portal2;
    [SerializeField] GameObject portal3;

    [SerializeField] GameObject W5;
    [SerializeField] GameObject bossHPSystem;

    [SerializeField] Image VicPan;
    [SerializeField] TextMeshProUGUI vicTitle;

    [SerializeField] Image DeadPan;
    [SerializeField] TextMeshProUGUI deadTitle;
    [SerializeField] TextMeshProUGUI deadTitle2;

    [SerializeField] GameObject portal4;

    [SerializeField] GameObject gift;
    [SerializeField] GameObject tutorialE2;
    [SerializeField] GameObject eUp2;

    [SerializeField] GameObject teleGhost;

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

    [Header("Camera")]
    [SerializeField] GameObject cam1;
    [SerializeField] GameObject cam2;
    [SerializeField] GameObject cam3;


    [Header("Cinematic")]
    [SerializeField] GameObject LC1;
    [SerializeField] GameObject LC2;
    [SerializeField] GameObject LC3;
    [SerializeField] GameObject LC4;
    [SerializeField] GameObject LC5;
    [SerializeField] GameObject LC6;
    [SerializeField] GameObject LC7;
    [SerializeField] GameObject LC8;
    [SerializeField] GameObject LC9;
    [SerializeField] GameObject LC10;


    [Header("Audio")]
    [SerializeField] AudioSource bgMusic;
    [SerializeField] AudioSource bgMusic2;
    [SerializeField] AudioSource portalSound;
    [SerializeField] AudioSource hitSound;
    [SerializeField] AudioSource victorySound;
    [SerializeField] AudioSource deadSound;
    [SerializeField] AudioSource giftSound;
    void Start()
    {
        StartCoroutine(NelioBlock1());
        StartCoroutine(NelioDead());

        StartCoroutine(PlayScene7());

        //StartCoroutine(Test());
        //StartCoroutine(Cinematic());
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialE.activeSelf)
        {
            eUp.SetActive(!Input.GetKey(KeyCode.E));
        }
        if (tutorialE2.activeSelf)
        {
            eUp2.SetActive(!Input.GetKey(KeyCode.E));
        }
    }

    IEnumerator Test()
    {
        yield return null;
        bgMusic.Play();
        BlockNelio();
        nelio.SetActive(false);
        scarletBoss.SetActive(false);
        //
        

    }
    IEnumerator PlayScene7()
    {
        bgMusic.Play();
        nelio.transform.position = new Vector3(-6, -0.3f, 0);
        blackBg.gameObject.SetActive(true);
        hpSystem.SetActive(false);
        portal.SetActive(false);
        nelio.SetActive(false);
        nelio.GetComponent<P_Block>().isBlock = true;
        scarlet.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        blackBg.CrossFadeAlpha(0, 15f, false);
        yield return new WaitForSeconds(4f);
        blackBg.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(2f);
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
        nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 0);
        yield return new WaitUntil(() => nelio.transform.position.x >= -3f);
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Rigidbody2D>().gravityScale = 1;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(0.5f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal.SetActive(false);
        yield return new WaitForSeconds(1f);
        nelio.GetComponent<P_Block>().isBlock = false;
        yield return new WaitUntil(() => nelio.transform.position.x >= 4f);
        BlockNelio();
        yield return new WaitForSeconds(1f);
        dialog1Start.SetActive(true);
        yield return new WaitUntil(() => dialog1End.GetComponent<Dialog>().index > dialog1End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog1End.activeSelf);
        nelio.GetComponent<Animator>().SetBool("isRun", true);
        nelio.GetComponent<SpriteRenderer>().enabled = true;
        nelio.GetComponent<Rigidbody2D>().gravityScale = 0;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 0);
        yield return new WaitUntil(() => nelio.transform.position.x >= 9.5f);
        BlockNelio();
        scar_Sit.SetActive(false);
        scarlet.SetActive(true);
        scarlet.GetComponent<Animator>().SetTrigger("Stand");
        yield return new WaitForSeconds(1f);
        dialog2Start.SetActive(true);
        yield return new WaitUntil(() => dialog2End.GetComponent<Dialog>().index > dialog2End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog2End.activeSelf);
        scarlet.transform.localScale = new Vector3(-1, 1, 1);
        scarlet.GetComponent<Rigidbody2D>().gravityScale = 0;
        scarlet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 0);
        scarlet.GetComponent<Animator>().SetBool("isRun", true);
        UnblockNelio();
        yield return new WaitUntil(() => scarlet.transform.position.x >= 55f);
        scarlet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        scarlet.GetComponent<Animator>().SetBool("isRun", false);
        scarlet.GetComponent<Rigidbody2D>().gravityScale = 1;
        yield return new WaitUntil(() => scarlet.transform.position.x >= 55f && nelio.transform.position.x >= 55.5f);
        yield return new WaitForSeconds(1f);
        dialog3Start.SetActive(true);
        yield return new WaitUntil(() => dialog3End.GetComponent<Dialog>().index > dialog3End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog3End.activeSelf);
        nelio.GetComponent<Animator>().SetBool("isRun", true);
        nelio.GetComponent<SpriteRenderer>().enabled = true;
        nelio.GetComponent<Rigidbody2D>().gravityScale = 0;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 0);
        yield return new WaitUntil(() => nelio.transform.position.x >= 59f);
        BlockNelio();
        yield return new WaitForSeconds(1f);
        tutorialE.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        yield return new WaitForSeconds(0.3f);
        firefly.SetActive(false);
        tutorialE.SetActive(false);
        yield return new WaitForSeconds(1f);
        nelio.transform.localScale = new Vector3(-1, 1, 1);
        dialog4Start.SetActive(true);
        yield return new WaitUntil(() => dialog4Start.GetComponent<Dialog>().index > dialog4Start.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog4Start.activeSelf);
        yield return new WaitForSeconds(0.5f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portalE.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        dialog4End.SetActive(true);
        yield return new WaitUntil(() => dialog4End.GetComponent<Dialog>().index > dialog4End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog4End.activeSelf);
        whiteLonelibet.SetActive(true);
        whiteLonelibet.GetComponent<Rigidbody2D>().gravityScale = 0;
        whiteLonelibet.GetComponent<Animator>().SetBool("isRun", true);
        whiteLonelibet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-2f, 0);
        yield return new WaitForSeconds(0.7f);
        whiteLonelibet.GetComponent<Animator>().SetTrigger("A1");
        whiteLonelibet.GetComponent<Rigidbody2D>().gravityScale = 1;
        whiteLonelibet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-3f, 3);
        yield return new WaitForSeconds(0.2f);
        nelio.transform.localScale = new Vector3(1, 1, 1);
        yield return StartCoroutine(Cin1());
        whiteLonelibet.GetComponent<Animator>().SetBool("isRun", false);
        yield return new WaitForSeconds(0.5f);
        whiteLonelibet.transform.localScale = new Vector3(-1, 1, 1);
        scarlet.GetComponent<Scarlet_Attack>().BowAttack();
        yield return new WaitForSeconds(1f);
        whiteLonelibet.GetComponent<Animator>().SetTrigger("A1");
        whiteLonelibet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(3f, 5);
        yield return new WaitForSeconds(0.3f);
        hitSound.Play();
        StartCoroutine(whiteLonelibet.GetComponent<EnemyHurt>().Hurt());
        GameObject h = Instantiate(hitGhostPre, whiteLonelibet.transform.position, Quaternion.Euler(0, 0, Random.Range(60f, 270f)));
        Destroy(h, 1 / 3f);
        yield return new WaitForSeconds(1 / 6f);
        whiteLonelibet.SetActive(false);
        yield return StartCoroutine(Cinematic());
        yield return new WaitForSeconds(2f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portalE.SetActive(false);
        yield return new WaitForSeconds(1f);
        nelio.transform.localScale = new Vector3(-1, 1, 1);
        yield return new WaitForSeconds(1f);
        dialog5Start.SetActive(true);
        yield return new WaitUntil(() => dialog5End.GetComponent<Dialog>().index > dialog5End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog5End.activeSelf);
        yield return new WaitForSeconds(2f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal2.SetActive(true);
        yield return new WaitForSeconds(1f);
        nelio.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(1f);
        dialog6Start.SetActive(true);
        yield return new WaitUntil(() => dialog6End.GetComponent<Dialog>().index > dialog6End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog6End.activeSelf);
        UnblockNelio();
        yield return new WaitUntil(() => nelio.transform.position.x >= 63f);
        BlockNelio();
        nelio.SetActive(false);
        hpSystem.SetActive(false);
        scarlet.GetComponent<Rigidbody2D>().gravityScale = 0;
        scarlet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 0);
        scarlet.GetComponent<Animator>().SetBool("isRun", true);
        yield return new WaitUntil(() => scarlet.transform.position.x >= 63.5f);
        scarlet.SetActive(false);
        scarlet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        scarlet.GetComponent<Animator>().SetBool("isRun", false);
        scarlet.GetComponent<Rigidbody2D>().gravityScale = 1;
        yield return new WaitForSeconds(2f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal2.SetActive(false);
        yield return StartCoroutine(BGFade());
        //
        scarletBoss.transform.position = new Vector3(82, -2.75f, 0);
        nelio.transform.position = new Vector3(81, -1.9f, 0);
        cam2.SetActive(true);
        cam1.SetActive(false);
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(BGApear());
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(0.5f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal3.SetActive(true);
        nelio.SetActive(true);
        nelio.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        nelio.GetComponent<Animator>().SetBool("isRun", true);
        nelio.GetComponent<SpriteRenderer>().enabled = true;
        nelio.GetComponent<Rigidbody2D>().gravityScale = 0;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 0);
        yield return new WaitUntil(() => nelio.transform.position.x >= 86f);
        BlockNelio();
        scarletBoss.SetActive(true);
        scarletBoss.GetComponent<Rigidbody2D>().gravityScale = 0;
        scarletBoss.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 0);
        scarletBoss.GetComponent<Animator>().SetBool("isRun", true);
        yield return new WaitUntil(() => scarletBoss.transform.position.x >= 85f);
        scarletBoss.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        scarletBoss.GetComponent<Animator>().SetBool("isRun", false);
        scarletBoss.GetComponent<Rigidbody2D>().gravityScale = 1;
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(0.5f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal3.SetActive(false);
        yield return new WaitForSeconds(2f);
        cam3.SetActive(true);
        cam2.SetActive(false);
        W5.SetActive(true);
        hpSystem.SetActive(true);
        yield return new WaitForSeconds(2f);
        whiteLonelibet.GetComponent<Lonelibet>().Bark();
        yield return new WaitForSeconds(0.3f);
        whiteLonelibet.GetComponent<Lonelibet>().Bark();
        yield return new WaitForSeconds(1.5f);
        dialog7Start.SetActive(true);
        yield return new WaitUntil(() => dialog7End.GetComponent<Dialog>().index > dialog7End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog7End.activeSelf);
        whiteLonelibet.GetComponent<Lonelibet>().Bark();
        yield return new WaitForSeconds(0.3f);
        whiteLonelibet.GetComponent<Lonelibet>().Bark();
        yield return new WaitForSeconds(1.5f);
        dialog8Start.SetActive(true);
        yield return new WaitUntil(() => dialog8End.GetComponent<Dialog>().index > dialog8End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog8End.activeSelf);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(scarletBoss.GetComponent<Scarlet_Attack>().A3());
        yield return new WaitForSeconds(0.8f);
        yield return StartCoroutine(nelio.GetComponent<P_Dash>().Roll());
        BlockNelio();
        nelio.transform.localScale = new Vector3(-1, 1, 1);
        yield return new WaitForSeconds(1f);
        dialog9Start.SetActive(true);
        yield return new WaitUntil(() => dialog9End.GetComponent<Dialog>().index > dialog9End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog9End.activeSelf);
        bossHPSystem.SetActive(true);
        UnblockNelio();
        bgMusic.Stop();
        bgMusic2.Play();
        yield return new WaitForSeconds(1f);
        scarletBoss.GetComponent<Scarlet_Attack>().isBattle = true;
        yield return new WaitUntil(() => scarletBoss.GetComponent<EnemyLife>().isDead);        
        bgMusic2.Stop();
        yield return StartCoroutine(scarletBoss.GetComponent<Scarlet_Attack>().BacktoScarlet());
        BlockNelio();
        nelio.transform.localScale = new Vector3(scarletBoss.transform.position.x > nelio.transform.position.x ? 1 : -1, 1, 1);
        yield return new WaitForSeconds(1f);
        dialog10Start.SetActive(true);
        yield return new WaitUntil(() => dialog10End.GetComponent<Dialog>().index > dialog10End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog10End.activeSelf);
        GameObject tG = Instantiate(teleGhost, scarletBoss.transform.position + new Vector3(0, 1, 0), Quaternion.Euler(0, 0, 0));
        Destroy(tG, 4 / 6f);
        yield return new WaitForSeconds(4 / 6f);
        scarletBoss.SetActive(false);
        whiteLonelibetBoss.SetActive(false);
        bossHPSystem.SetActive(false);
        yield return StartCoroutine(VicPanShow());
        yield return new WaitForSeconds(1f);
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
        portal4.SetActive(true);
        yield return new WaitForSeconds(2f);
        cam2.SetActive(true);
        cam3.SetActive(false);
        yield return new WaitForSeconds(2f);
        nelio.GetComponent<P_Block>().isBlock = false;
        yield return new WaitUntil(() => nelio.transform.position.x >= 100f);
        hpSystem.SetActive(false);
        nelio.SetActive(false);
        nelio.GetComponent<P_Block>().isBlock = true;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        yield return new WaitForSeconds(2f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal4.SetActive(false);
        yield return StartCoroutine(NextScene8());
    }

    IEnumerator NextScene8()
    {
        blackBg.CrossFadeAlpha(0, 0.1f, false);
        yield return new WaitForSeconds(0.5f);
        blackBg.gameObject.SetActive(true);
        blackBg.CrossFadeAlpha(1, 5f, false);
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("S8Losmind");
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
    IEnumerator Cin1()
    {
        Time.timeScale = 0.1f;
        whiteLonelibet.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        tutorialShift.SetActive(true);
        InvokeRepeating("ShiftOnOff", 0, 0.02f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.LeftShift));
        tutorialShift.SetActive(false);
        CancelInvoke("ShiftOnOff");
        nelio.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        Time.timeScale = 1f;
        whiteLonelibet.GetComponent<Rigidbody2D>().gravityScale = 1;
        //StartCoroutine(nelio.GetComponent<P_Dash>().Dash());
        yield return StartCoroutine(nelio.GetComponent<P_Dash>().Roll());

    }

    IEnumerator Cinematic()
    {
        LC1.SetActive(true);
        yield return new WaitForSeconds(0.06f);
        LC1.SetActive(false);
        LC2.SetActive(true);
        yield return new WaitForSeconds(0.06f);
        LC2.SetActive(false);
        LC3.SetActive(true);
        yield return new WaitForSeconds(0.06f);
        LC3.SetActive(false);
        LC4.SetActive(true);
        yield return new WaitForSeconds(0.06f);
        LC4.SetActive(false);
        LC5.SetActive(true);
        yield return new WaitForSeconds(0.06f);
        LC5.SetActive(false);
        LC6.SetActive(true);
        yield return new WaitForSeconds(0.06f);
        LC6.SetActive(false);
        LC7.SetActive(true);
        yield return new WaitForSeconds(0.06f);
        LC7.SetActive(false);
        //LC8.SetActive(true);
        //yield return new WaitForSeconds(0.7f);
        //LC8.SetActive(false);
        //LC9.SetActive(true);
        //yield return new WaitForSeconds(0.15f);
        //LC9.SetActive(false);
        //LC10.SetActive(true);
        //yield return new WaitForSeconds(1f);
        //LC10.SetActive(false);
    }
    void ShiftOnOff()
    {
        shiftDown.SetActive(!shiftDown.activeSelf);
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
        SceneManager.LoadScene("S7");
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
