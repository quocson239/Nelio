using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S10 : MonoBehaviour
{
    [SerializeField] GameObject milo;
    [SerializeField] GameObject portal;
    [SerializeField] Image blackBg;    
    

    [Header("Gifts and Tutorials")]
    [SerializeField] GameObject letter1;
    [SerializeField] GameObject letter2;
    [SerializeField] GameObject tutorialE2;
    [SerializeField] GameObject eUp2;
    [SerializeField] GameObject press1;
    [SerializeField] GameObject press2;

    [Header("Dialogs")]
    [SerializeField] GameObject dialog1Start;
    [SerializeField] GameObject dialog1End;
    [SerializeField] GameObject dialog2Start;
    [SerializeField] GameObject dialog2End;
    [SerializeField] GameObject dialog3Start;
    [SerializeField] GameObject dialog3End;

    [Header("Camera")]
    [SerializeField] GameObject cam1;
    [SerializeField] GameObject cam2;
    [SerializeField] GameObject cam3;

    [Header("Audio")]
    [SerializeField] AudioSource bgMusic;
    [SerializeField] AudioSource bgMusic2;
    [SerializeField] AudioSource portalSound;
    [SerializeField] AudioSource giftSound;
    [SerializeField] AudioSource meoSound;
    void Start()
    {
        StartCoroutine(PlayScene10());
    }

    
    void Update()
    {
        if (tutorialE2.activeSelf)
        {
            eUp2.SetActive(!Input.GetKey(KeyCode.E));
        }
    }

    IEnumerator PlayScene10()
    {
        bgMusic.Play();
        milo.SetActive(false);
        milo.transform.position = new Vector3(82f, 2.5f, 0);
        blackBg.gameObject.SetActive(true);        
        portal.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(BGApear());
        yield return new WaitForSeconds(0.5f);
        milo.transform.localScale = new Vector3(-1, 1, 1);
        yield return new WaitForSeconds(0.5f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal.SetActive(true);
        milo.SetActive(true);
        milo.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(2f);
        milo.GetComponent<Animator>().SetBool("isRun", true);
        milo.GetComponent<SpriteRenderer>().enabled = true;
        milo.GetComponent<Rigidbody2D>().gravityScale = 0;
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-1.5f, 0);
        yield return new WaitUntil(() => milo.transform.position.x <= 80f);
        milo.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        milo.GetComponent<Rigidbody2D>().gravityScale = 1;
        milo.GetComponent<Animator>().SetBool("isRun", false);
        yield return new WaitForSeconds(1f);
        dialog1Start.SetActive(true);
        yield return new WaitUntil(() => dialog1End.GetComponent<Dialog>().index > dialog1End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog1End.activeSelf);
        yield return new WaitForSeconds(0.5f);
        milo.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(0.5f);
        dialog2Start.SetActive(true);
        yield return new WaitUntil(() => dialog2End.GetComponent<Dialog>().index > dialog2End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog2End.activeSelf);
        yield return new WaitForSeconds(0.5f);
        letter1.SetActive(true);
        bgMusic.Stop();
        bgMusic2.Play();
        giftSound.Play();        
        tutorialE2.SetActive(true);
        press1.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        press1.SetActive(false);
        letter1.SetActive(false);
        letter2.SetActive(true);
        press2.SetActive(true);
        yield return new WaitForSeconds(2f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        yield return new WaitForSeconds(0.3f);
        letter2.SetActive(false);
        tutorialE2.SetActive(false);           
        yield return new WaitForSeconds(0.5f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        meoSound.Play();
        dialog3Start.SetActive(true);
        yield return new WaitUntil(() => dialog3Start.GetComponent<Dialog>().index > dialog3Start.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog3Start.activeSelf);
        dialog3End.GetComponent<Dialog>().isStop = true;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(NextSceneEnding());

    }

    IEnumerator NextSceneEnding()
    {
        blackBg.CrossFadeAlpha(0, 0.1f, false);
        yield return new WaitForSeconds(0.5f);
        blackBg.gameObject.SetActive(true);
        blackBg.CrossFadeAlpha(1, 15f, false);
        yield return new WaitForSeconds(16f);
        SceneManager.LoadScene("Ending");
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
}
