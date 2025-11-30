using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S5 : MonoBehaviour
{
    [SerializeField] GameObject nelio;
    [SerializeField] GameObject scarletWave;
    [SerializeField] Image blackBg;
    [SerializeField] GameObject cam2;
    [SerializeField] GameObject cam3;
    [SerializeField] GameObject smallTalk1;
    [SerializeField] GameObject smallTalk2;
    [SerializeField] GameObject dialog1Start;
    [SerializeField] GameObject dialog2Start;
    [SerializeField] GameObject hpSystem;
    [SerializeField] GameObject portal;
    [SerializeField] GameObject tutorialSpace;
    [SerializeField] GameObject tutorialShift;
    [SerializeField] GameObject spaceDown;
    [SerializeField] GameObject shiftDown;

    [Header("Lightning Cin")]
    [SerializeField] GameObject L11;
    [SerializeField] GameObject L12;
    [SerializeField] GameObject L13;
    [SerializeField] GameObject L21;
    [SerializeField] GameObject L22;
    [SerializeField] GameObject L23;

    [Header("Audio")]
    [SerializeField] AudioSource bgMusic;
    [SerializeField] AudioSource bgMusic2;
    [SerializeField] AudioSource birdSound;    
    [SerializeField] AudioSource waterFlowSound;    
    [SerializeField] AudioSource portalSound;
    [SerializeField] AudioSource scarletByeSound;
    [SerializeField] AudioSource lightningSound;
    void Start()
    {
        blackBg.gameObject.SetActive(true);
        StartCoroutine(PlayScene5());
        //StartCoroutine(Test());        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayScene5()
    {
        bgMusic.Play();
        birdSound.Play();
        nelio.transform.localScale = new Vector3(-1, 1, 1);
        nelio.GetComponent<P_Block>().isBlock = true;
        blackBg.CrossFadeAlpha(0, 15f, false);
        yield return new WaitForSeconds(4f);
        blackBg.CrossFadeAlpha(0, 1f, false);
        cam2.SetActive(true);
        yield return new WaitForSeconds(3f);
        scarletByeSound.Play();
        smallTalk1.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        smallTalk2.SetActive(true);
        yield return new WaitForSeconds(4f);
        smallTalk1.SetActive(false);
        smallTalk2.SetActive(false);
        cam2.SetActive(false);
        yield return new WaitForSeconds(3f);
        nelio.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(2f);
        scarletWave.SetActive(false);
        nelio.GetComponent<Animator>().SetBool("isRun", true);
        nelio.GetComponent<Rigidbody2D>().gravityScale = 0;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 0);
        yield return new WaitUntil(() => nelio.transform.position.x >= 83.5f);
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Rigidbody2D>().gravityScale = 1;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        yield return new WaitForSeconds(1f);
        dialog1Start.SetActive(true);
        yield return new WaitUntil(() => dialog1Start.GetComponent<Dialog>().index > dialog1Start.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog1Start.activeSelf);        
        cam3.SetActive(true);
        nelio.transform.localScale = new Vector3(-1, 1, 1);
        yield return new WaitForSeconds(1f);
        nelio.GetComponent<Animator>().SetBool("isRun", true);
        nelio.GetComponent<Rigidbody2D>().gravityScale = 0;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-2f, 0);
        yield return new WaitUntil(() => nelio.transform.position.x <= 81.4f);
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Rigidbody2D>().gravityScale = 1;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        yield return new WaitForSeconds(0.5f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal.SetActive(true);
        bgMusic.GetComponent<AudioSource>().volume = 0.3f;
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(L1Cin());
        yield return StartCoroutine(L2Cin());
        nelio.transform.localScale = new Vector3(1, 1, 1);
        yield return StartCoroutine(L3Cin());
        bgMusic.GetComponent<AudioSource>().volume = 0.7f;
        dialog2Start.SetActive(true);
        yield return new WaitUntil(() => dialog2Start.GetComponent<Dialog>().index > dialog2Start.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog2Start.activeSelf);
        nelio.GetComponent<Animator>().SetBool("isRun", true);
        nelio.GetComponent<Rigidbody2D>().gravityScale = 0;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 0);
        yield return new WaitUntil(() => nelio.transform.position.x >= 83.4f);
        nelio.SetActive(false);
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Rigidbody2D>().gravityScale = 1;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        yield return new WaitForSeconds(0.5f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        blackBg.CrossFadeAlpha(1, 15f, false);
        yield return new WaitForSeconds(4f);
        blackBg.CrossFadeAlpha(1, 1f, false);
        yield return new WaitForSeconds(1f);
        StartCoroutine(NextScene6());
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(2f);
    }

    IEnumerator L1Cin()
    {
        Time.timeScale = 0.1f;
        L11.SetActive(true);
        tutorialSpace.SetActive(true);
        InvokeRepeating("SpaceOnOff", 0, 0.02f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        tutorialSpace.SetActive(false);
        CancelInvoke("SpaceOnOff");
        Time.timeScale = 1f;
        StartCoroutine(nelio.GetComponent<P_Jump>().Jump1());
        yield return new WaitForSeconds(0.5f);        
        nelio.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        L11.SetActive(false);
        L12.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        lightningSound.Play();
        L12.SetActive(false);
        L13.SetActive(true);
        yield return new WaitForSeconds(0.2f);        
        L13.SetActive(false);
        Time.timeScale = 0.1f;
    }

    IEnumerator L2Cin()
    {
        Time.timeScale = 0.1f;
        L21.SetActive(true);
        tutorialShift.SetActive(true);
        InvokeRepeating("ShiftOnOff", 0, 0.02f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.LeftShift));
        tutorialShift.SetActive(false);
        CancelInvoke("ShiftOnOff");
        nelio.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        Time.timeScale = 1f;
        StartCoroutine(nelio.GetComponent<P_Dash>().Dash());
        yield return StartCoroutine(nelio.GetComponent<P_Dash>().Dash());
        L21.SetActive(false);
        L22.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        lightningSound.Play();
        L22.SetActive(false);
        L23.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        L23.SetActive(false);        
    }
    IEnumerator L3Cin()
    {        
        L11.SetActive(true);                 
        yield return new WaitForSeconds(0.25f);        
        L11.SetActive(false);
        L12.SetActive(true);
        Time.timeScale = 0.1f;
        tutorialShift.SetActive(true);
        InvokeRepeating("ShiftOnOff", 0, 0.02f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.LeftShift));
        tutorialShift.SetActive(false);
        CancelInvoke("ShiftOnOff");
        Time.timeScale = 1f;
        StartCoroutine(nelio.GetComponent<P_Dash>().Roll());
        yield return new WaitForSeconds(1/6f);
        lightningSound.Play();
        L12.SetActive(false);
        L13.SetActive(true);
        yield return new WaitForSeconds(1/6f);
        L13.SetActive(false);        
    }

    IEnumerator NextScene6()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("S6Darker");
    }

    void SpaceOnOff()
    {
        spaceDown.SetActive(!spaceDown.activeSelf);
    }
    void ShiftOnOff()
    {
        shiftDown.SetActive(!shiftDown.activeSelf);
    }
}
