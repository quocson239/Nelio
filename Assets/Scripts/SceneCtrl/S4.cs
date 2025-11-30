using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Splines.SplineInstantiate;

public class S4 : MonoBehaviour
{
    [SerializeField] GameObject nelio;
    [SerializeField] GameObject scarlet;
    [SerializeField] GameObject lonelibet;
    [SerializeField] Image blackBg;
    [SerializeField] GameObject dialog1Start;
    [SerializeField] GameObject dialog1End;
    [SerializeField] GameObject hpSystem;
    [SerializeField] GameObject dialog2Start;    
    [SerializeField] GameObject dialog3Start;    
    [SerializeField] GameObject dialog3End;
    [SerializeField] GameObject tutorial1;
    [SerializeField] GameObject tutorial2;
    [SerializeField] GameObject tutorial3;
    [SerializeField] GameObject tutorial4;
    [SerializeField] GameObject cam2;
    [SerializeField] GameObject smallTalk1;
    [SerializeField] GameObject aUp;
    [SerializeField] GameObject dUp;
    [SerializeField] GameObject spaceUp;    
    [SerializeField] GameObject mouseDownL;
    [SerializeField] GameObject mouseDownR;
    [SerializeField] GameObject mouseDownBoth;
    [SerializeField] GameObject cam3;
    [SerializeField] GameObject arrowPointScarlet;
    [SerializeField] GameObject tutorial5;
    [SerializeField] GameObject eUp;
    [SerializeField] GameObject arrowTuto1;
    [SerializeField] GameObject campfire;
    [SerializeField] GameObject scarletSitting;
    [SerializeField] GameObject nelioSitting;
    [SerializeField] GameObject cam4;
    [SerializeField] GameObject dialog4Start;
    [SerializeField] GameObject dialog4End;
    [SerializeField] GameObject cam5;
    [SerializeField] GameObject skyDeco;
    [SerializeField] GameObject NST;

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
    [SerializeField] AudioSource cricketSound;
    [SerializeField] AudioSource giftSound;
    [SerializeField] AudioSource scarletShoutSound;
    [SerializeField] AudioSource wolfHowling;
    [SerializeField] AudioSource wolfCrying;
    [SerializeField] AudioSource scarletCough;
    [SerializeField] AudioSource campFireSound;
    [SerializeField] AudioSource scarletSoftCough;
    void Start()
    {
        blackBg.gameObject.SetActive(true);
        StartCoroutine(PlayScene4());
        //StartCoroutine(Test1());
        //StartCoroutine(Cinematic());
    }

    void Update()
    {
        if (tutorial1.activeSelf)
        {
            aUp.SetActive(!Input.GetKey(KeyCode.A));
            dUp.SetActive(!Input.GetKey(KeyCode.D));
        }
        if (tutorial2.activeSelf)
        {
            spaceUp.SetActive(!Input.GetKey(KeyCode.Space));
        }
        if (tutorial3.activeSelf)
        {
            mouseDownL.SetActive(false);
            //mouseDownR.SetActive(Input.GetMouseButton(1) && !Input.GetMouseButton(0));
            mouseDownBoth.SetActive(false);
        }
        if (tutorial4.activeSelf)
        {
            mouseDownL.SetActive(Input.GetMouseButton(0) && !Input.GetMouseButton(1));
            mouseDownR.SetActive(Input.GetMouseButton(1) && !Input.GetMouseButton(0));
            mouseDownBoth.SetActive(Input.GetMouseButton(0) && Input.GetMouseButton(1));
        }
        if (tutorial5.activeSelf)
        {
            eUp.SetActive(!Input.GetKey(KeyCode.E));
        }
    }

    IEnumerator PlayScene4()
    {
        bgMusic.Play();
        cricketSound.Play();
        nelio.transform.localScale = new Vector3(-1, 1, 1);
        nelio.GetComponent<P_Block>().isBlock = true;
        blackBg.CrossFadeAlpha(0, 15f, false);
        yield return new WaitForSeconds(4f);
        blackBg.CrossFadeAlpha(0, 1f, false);
        dialog1Start.SetActive(true);
        yield return new WaitUntil(() => dialog1Start.GetComponent<Dialog>().index > dialog1Start.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog1Start.activeSelf);
        yield return new WaitForSeconds(1f);
        hpSystem.SetActive(true);
        giftSound.Play();
        yield return new WaitForSeconds(2f);
        dialog1End.SetActive(true);
        yield return new WaitUntil(() => dialog1End.GetComponent<Dialog>().index > dialog1End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog1End.activeSelf);
        yield return new WaitForSeconds(1f);
        wolfHowling.Play();
        yield return new WaitForSeconds(4f);
        scarletShoutSound.Play();
        scarlet.GetComponent<Animator>().SetBool("isLying",true);
        lonelibet.transform.localScale = new Vector3(-1, 1, 1);
        yield return new WaitForSeconds(2f);
        dialog2Start.SetActive(true);
        yield return new WaitUntil(() => dialog2Start.GetComponent<Dialog>().index > dialog2Start.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog2Start.activeSelf);
        yield return new WaitForSeconds(0.5f);
        nelio.GetComponent<P_Attack>().enabled = false;
        tutorial1.SetActive(true);
        tutorial2.SetActive(true);
        nelio.GetComponent<P_Block>().isBlock = false;
        yield return new WaitUntil(() => nelio.transform.position.x <= 45f);
        nelio.GetComponent<P_Block>().isBlock = true;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        cam2.SetActive(true);
        yield return new WaitForSeconds(2f);
        smallTalk1.SetActive(true);
        yield return new WaitForSeconds(2f);
        tutorial3.SetActive(true);
        InvokeRepeating("MouseTuto3", 0f, 0.2f);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(1));
        CancelInvoke("MouseTuto3");
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(nelio.GetComponent<P_Attack>().RA());
        smallTalk1.SetActive(false);
        tutorial3.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        lonelibet.GetComponent<Animator>().SetTrigger("JC");
        yield return new WaitForSeconds(2 / 3f);
        lonelibet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(3.5f, 3f);
        lonelibet.GetComponent<Rigidbody2D>().gravityScale = 1f;
        yield return new WaitUntil(() => lonelibet.transform.position.x >= 34.25f);
        lonelibet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        lonelibet.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(0.1f);
        lonelibet.SetActive(false);
        lonelibet.transform.position = new Vector3(29.77f, -0.285f, 0);
        StartCoroutine(Cinematic());
        yield return StartCoroutine(Cinematic());
        cam3.SetActive(true);
        lonelibet.transform.localScale = new Vector3(1, 1, 1);
        lonelibet.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        lonelibet.SetActive(true);
        wolfCrying.Play();
        yield return new WaitForSeconds(0.5f);
        lonelibet.GetComponent<Animator>().SetBool("isRun", true);
        lonelibet.GetComponent<Rigidbody2D>().gravityScale = 0f;
        lonelibet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-3, 0);
        yield return new WaitUntil(() => lonelibet.transform.position.x <= 19f);
        lonelibet.SetActive(false);
        cam3.SetActive(false);
        yield return new WaitForSeconds(2f);
        tutorial1.SetActive(true);
        arrowTuto1.SetActive(false);
        tutorial2.SetActive(true);
        nelio.GetComponent<P_Block>().isBlock = false;
        arrowPointScarlet.SetActive(true);
        yield return new WaitUntil(() => nelio.transform.position.x <= 38.5f);
        nelio.GetComponent<P_Block>().isBlock = true;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial5.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        yield return new WaitForSeconds(0.2f);
        hpSystem.SetActive(false);
        arrowPointScarlet.SetActive(false);
        tutorial5.SetActive(false);
        scarlet.GetComponent<Animator>().SetBool("isLying", false);
        scarlet.transform.localScale = new Vector3(-1, 1, 1);
        scarlet.transform.position = new Vector3(37.5f, scarlet.transform.position.y, 0);
        yield return new WaitForSeconds(2f);
        dialog3Start.SetActive(true);
        yield return new WaitUntil(() => dialog3Start.GetComponent<Dialog>().index > dialog3Start.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog3Start.activeSelf);
        scarletCough.Play();
        yield return new WaitUntil(() => dialog3End.GetComponent<Dialog>().index > dialog3End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog3End.activeSelf);        
        yield return new WaitForSeconds(1f);
        blackBg.CrossFadeAlpha(1, 3f, false);
        yield return new WaitForSeconds(4f);
        cam2.SetActive(false);
        cam4.SetActive(true);
        nelio.transform.position = new Vector3(78, 2.7f, 0);        
        nelio.SetActive(false);
        scarletSitting.SetActive(true);
        campfire.SetActive(true);
        nelioSitting.SetActive(true);
        skyDeco.SetActive(true);
        yield return new WaitForSeconds(2f);
        campFireSound.Play();
        blackBg.CrossFadeAlpha(0, 15f, false);
        yield return new WaitForSeconds(4f);
        blackBg.CrossFadeAlpha(0, 1f, false);        
        yield return new WaitForSeconds(2f);
        dialog4Start.SetActive(true);
        scarletSoftCough.Play();
        dialog4Start.SetActive(true);
        yield return new WaitUntil(() => dialog4End.GetComponent<Dialog>().index > dialog4End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog4End.activeSelf);
        yield return new WaitForSeconds(1f);
        cam4.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0.5f);
        yield return new WaitUntil(() => cam4.transform.position.y >= cam5.transform.position.y);
        cam4.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(5f);
        blackBg.CrossFadeAlpha(1, 15f, false);
        yield return new WaitForSeconds(6f);
        blackBg.CrossFadeAlpha(1, 1f, false);
        yield return new WaitForSeconds(1f);
        campFireSound.Stop();
        StartCoroutine(NextScene5());
    }

    IEnumerator Test1()
    {
        blackBg.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);        
        blackBg.CrossFadeAlpha(1, 3f, false);
        yield return new WaitForSeconds(4f);
        cam2.SetActive(false);
        cam4.SetActive(true);
        nelio.transform.position = new Vector3(78, 2.7f, 0);
        nelio.SetActive(false);
        scarletSitting.SetActive(true);
        campfire.SetActive(true);
        nelioSitting.SetActive(true);
        skyDeco.SetActive(true);
        yield return new WaitForSeconds(2f);
        campFireSound.Play();
        blackBg.CrossFadeAlpha(0, 15f, false);
        yield return new WaitForSeconds(4f);
        blackBg.CrossFadeAlpha(0, 1f, false);        
        yield return new WaitForSeconds(2f);
        //Change
        scarletSoftCough.Play();
        dialog4Start.SetActive(true);
        yield return new WaitUntil(() => dialog4End.GetComponent<Dialog>().index > dialog4End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog4End.activeSelf);
        yield return new WaitForSeconds(1f);
        cam4.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0.5f);
        yield return new WaitUntil(() => cam4.transform.position.y >= cam5.transform.position.y);
        cam4.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(5f);
        blackBg.CrossFadeAlpha(1, 15f, false);
        yield return new WaitForSeconds(6f);        
        blackBg.CrossFadeAlpha(1, 1f, false);
        yield return new WaitForSeconds(1f);
        campFireSound.Stop();
        bgMusic.Stop();
        StartCoroutine(NextScene5());
    }
    IEnumerator NextScene5()
    {        
        yield return new WaitForSeconds(3f);
        NST.SetActive(true);
        yield return new WaitUntil(() => NST.GetComponent<Dialog>().index > NST.GetComponent<Dialog>().lines.Length - 1 && !NST.activeSelf);
        SceneManager.LoadScene("S5");
    }

    IEnumerator Cinematic()
    {
        LC1.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        LC1.SetActive(false);
        LC2.SetActive(true);        
        yield return new WaitForSeconds(0.15f);        
        LC2.SetActive(false);
        LC3.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        LC3.SetActive(false);
        LC4.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        LC4.SetActive(false);
        LC5.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        LC5.SetActive(false);
        LC6.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        LC6.SetActive(false);
        LC7.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        LC7.SetActive(false);
        LC8.SetActive(true);
        yield return new WaitForSeconds(0.7f);        
        LC8.SetActive(false);
        LC9.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        LC9.SetActive(false);
        LC10.SetActive(true);
        yield return new WaitForSeconds(1f);
        LC10.SetActive(false);       
    }

    void MouseTuto3()
    {
        mouseDownR.SetActive(!mouseDownR.activeSelf);
    }
}
