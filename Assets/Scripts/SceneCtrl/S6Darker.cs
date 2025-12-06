using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S6Darker : MonoBehaviour
{
    [SerializeField] GameObject nelio;
    [SerializeField] GameObject hpSystem;
    [SerializeField] GameObject darker;
    [SerializeField] Image blackBg;
    [SerializeField] GameObject globalLight;

    [SerializeField] GameObject portal;

    [SerializeField] GameObject cam2;
    [SerializeField] GameObject cam3;


    [SerializeField] GameObject wall1;
    [SerializeField] GameObject wall2;
    [SerializeField] GameObject fire1;
    [SerializeField] GameObject fire2;
    [SerializeField] GameObject fire3;
    [SerializeField] GameObject d_head;
    [SerializeField] GameObject d_blade;
    [SerializeField] GameObject light_throne;
    [SerializeField] GameObject light_backthrone;
    [SerializeField] GameObject d_sit;
    [SerializeField] GameObject d_tele1;
    [SerializeField] GameObject d_tele2;
    [SerializeField] GameObject bossHpSystem;

    [SerializeField] GameObject dialog1Start;
    [SerializeField] GameObject dialog2Start;
    [SerializeField] GameObject dialog3Start;
    [SerializeField] GameObject dialog4Start;
    [SerializeField] GameObject dialog4End;


    [SerializeField] Image VicPan;
    [SerializeField] TextMeshProUGUI vicTitle;
    [SerializeField] GameObject gift;
    [SerializeField] GameObject tutorialE;
    [SerializeField] GameObject eUp;
    [SerializeField] GameObject portal2;

    [SerializeField] Image DeadPan;
    [SerializeField] TextMeshProUGUI deadTitle;
    [SerializeField] TextMeshProUGUI deadTitle2;


    [Header("Audio")]
    [SerializeField] AudioSource bgMusic;
    [SerializeField] AudioSource bgMusic2;
    [SerializeField] AudioSource portalSound;
    [SerializeField] AudioSource darkerTeleSound;
    [SerializeField] AudioSource victorySound;
    [SerializeField] AudioSource deadSound;
    [SerializeField] AudioSource giftSound;
    void Start()
    {
        StartCoroutine(NelioDead());
        StartCoroutine(PlayScene6());
        //StartCoroutine(Test());
        
        //StartCoroutine(NextScene7());
        //StartCoroutine(VicPanShow());

        //fire1.SetActive(true);
        //fire2.SetActive(true);
        //fire3.SetActive(true);
    }
    
    void Update()
    {
        if (tutorialE.activeSelf)
        {
            eUp.SetActive(!Input.GetKey(KeyCode.E));
        }
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(2f);

    }

    IEnumerator PlayScene6()
    {
        bgMusic.Play();
        nelio.transform.position = new Vector3(-8, -2.3f, 0);
        blackBg.gameObject.SetActive(true);
        hpSystem.SetActive(false);
        portal.SetActive(false);
        nelio.SetActive(false);
        nelio.GetComponent<P_Block>().isBlock = true;
        darker.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        blackBg.CrossFadeAlpha(0, 15f, false);
        yield return new WaitForSeconds(4f);
        blackBg.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(2f);
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
        yield return new WaitUntil(() => nelio.transform.position.x >= -6f);
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Rigidbody2D>().gravityScale = 1;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        yield return new WaitForSeconds(2f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal.SetActive(false);
        yield return new WaitForSeconds(1f);
        dialog1Start.SetActive(true);
        yield return new WaitUntil(() => dialog1Start.GetComponent<Dialog>().index > dialog1Start.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog1Start.activeSelf);
        hpSystem.SetActive(true);
        nelio.GetComponent<P_Block>().isBlock = false;
        yield return new WaitUntil(() => nelio.transform.position.x >= 47f);
        nelio.GetComponent<P_Block>().isBlock = true;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        yield return new WaitForSeconds(0.1f);
        globalLight.GetComponent<Light2D>().intensity = 0.02f;
        yield return new WaitForSeconds(0.1f);
        globalLight.GetComponent<Light2D>().intensity = 0.01f;
        yield return new WaitForSeconds(0.1f);
        globalLight.GetComponent<Light2D>().intensity = 0f;
        wall1.SetActive(true);
        wall2.SetActive(true);
        cam2.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        dialog2Start.SetActive(true);
        yield return new WaitUntil(() => dialog2Start.GetComponent<Dialog>().index > dialog2Start.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog2Start.activeSelf);
        nelio.GetComponent<P_Block>().isBlock = false;
        yield return new WaitUntil(() => fire1.activeSelf && fire2.activeSelf && fire3.activeSelf);
        nelio.GetComponent<P_Block>().isBlock = true;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        yield return new WaitForSeconds(1f);
        d_head.SetActive(true);
        yield return new WaitForSeconds(1f);
        d_blade.SetActive(true);
        yield return new WaitForSeconds(1f);
        light_throne.SetActive(true);
        yield return new WaitForSeconds(1f);
        light_backthrone.SetActive(true);
        yield return new WaitForSeconds(2f);
        dialog3Start.SetActive(true);
        //
        yield return new WaitUntil(() => dialog3Start.GetComponent<Dialog>().index > dialog3Start.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog3Start.activeSelf);
        yield return new WaitForSeconds(2f);
        d_sit.SetActive(false);
        darkerTeleSound.Play();
        GameObject d = Instantiate(d_tele1, d_sit.transform.position, Quaternion.identity);
        Destroy(d, 1 / 3f);
        GameObject d2 = Instantiate(d_tele2, darker.transform.position, Quaternion.identity);
        Destroy(d2, 0.5f);
        yield return new WaitForSeconds(1 / 3f);
        darker.transform.localScale = new Vector3(-1, 1, 1);
        darker.SetActive(true);
        yield return new WaitForSeconds(2f);
        nelio.GetComponent<P_Block>().isBlock = false;
        darker.GetComponent<Darker>().enabled = false;
        bgMusic.Stop();
        bgMusic2.Play();
        yield return new WaitForSeconds(2f);
        darker.GetComponent<Darker>().enabled = true;
        bossHpSystem.SetActive(true);
        yield return new WaitUntil(() => darker.GetComponent<EnemyLife>().isDead);
        bgMusic2.Stop();
        bgMusic.Play();
        nelio.GetComponent<P_Block>().isBlock = true;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        yield return new WaitForSeconds(2f);
        dialog4Start.SetActive(true);
        yield return new WaitUntil(() => dialog4End.GetComponent<Dialog>().index > dialog4End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog4End.activeSelf);
        yield return new WaitForSeconds(2f);
        darkerTeleSound.Play();
        GameObject d3 = Instantiate(d_tele1, darker.transform.position + new Vector3(0, -0.5f, 0), Quaternion.identity);
        Destroy(d3, 1 / 3f);
        yield return new WaitForSeconds(1 / 3f);
        darker.SetActive(false);
        bossHpSystem.SetActive(false);
        yield return StartCoroutine(VicPanShow());
        yield return new WaitForSeconds(1f);
        giftSound.Play();
        gift.SetActive(true);
        tutorialE.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        yield return new WaitForSeconds(0.3f);
        gift.SetActive(false);
        tutorialE.SetActive(false);
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(0.5f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal2.SetActive(true);
        yield return new WaitForSeconds(2f);
        cam2.SetActive(false);
        yield return new WaitForSeconds(2f);
        nelio.GetComponent<P_Block>().isBlock = false;
        yield return new WaitUntil(() => nelio.transform.position.x >= 63.5f);
        nelio.SetActive(false);
        nelio.GetComponent<P_Block>().isBlock = true;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        yield return new WaitForSeconds(2f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal2.SetActive(false);
        yield return StartCoroutine(NextScene7());
    }


    IEnumerator NextScene7()
    {
        blackBg.CrossFadeAlpha(0, 0.1f, false);
        yield return new WaitForSeconds(0.5f);
        blackBg.gameObject.SetActive(true);
        blackBg.CrossFadeAlpha(1, 5f, false);
        yield return new WaitForSeconds(6f);        
        SceneManager.LoadScene("S7");
    }

    IEnumerator NelioDead()
    {
        yield return new WaitUntil(() => nelio.GetComponent<P_Life>().isDead);
        yield return StartCoroutine(DeadPanShow());
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.R));
        SceneManager.LoadScene("S6Darker");
    }

    IEnumerator VicPanShow()
    {
        yield return new WaitForSeconds(0.1f);
        VicPan.CrossFadeAlpha(0f, 0.1f, false);
        vicTitle.CrossFadeAlpha(0f, 0.1f, false);
        yield return new WaitForSeconds(1f);
        VicPan.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        VicPan.CrossFadeAlpha(220/255f, 3f, false);
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

}
