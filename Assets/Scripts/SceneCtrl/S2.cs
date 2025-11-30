using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S2 : MonoBehaviour
{
    [SerializeField] GameObject milo;
    [SerializeField] GameObject nelio;
    [SerializeField] Image blackBg;
    [SerializeField] GameObject dialogStart;
    [SerializeField] GameObject dialogEnd;
    [SerializeField] GameObject dialogEnd2;
    [SerializeField] GameObject cam2;
    [SerializeField] GameObject branchBreak;
    [SerializeField] GameObject hideGround;
    [SerializeField] GameObject fallFruit1;
    [SerializeField] GameObject fallFruit2;
    [SerializeField] GameObject fallFruit3;
    [SerializeField] GameObject fallFruit4;
    [SerializeField] GameObject holeGround;
    [SerializeField] GameObject branchGround;
    [SerializeField] GameObject smallTalk1;
    [SerializeField] GameObject smallTalk2;
    [SerializeField] GameObject smallTalk3;
    [SerializeField] GameObject smallTalk4;
    [SerializeField] GameObject smallTalk5;
    [SerializeField] GameObject smallTalk6;
    [SerializeField] GameObject cam3;
    [SerializeField] GameObject portal;
    [SerializeField] GameObject grabTree;
    [SerializeField] GameObject neCin1;
    [SerializeField] GameObject neCin2;
    [SerializeField] GameObject neCin3;
    [SerializeField] GameObject neCin4;
    [SerializeField] GameObject neCin5;
    [SerializeField] GameObject neCin6;
    [SerializeField] GameObject tutorial1;
    [SerializeField] GameObject tutorial2;
    [SerializeField] GameObject tutorial3;
    [SerializeField] GameObject aUp;
    [SerializeField] GameObject dUp;
    [SerializeField] GameObject spaceUp;
    [SerializeField] GameObject wUp;
    [SerializeField] GameObject arrowDirect1;
    [SerializeField] GameObject arrowDirect2;    
    [SerializeField] GameObject NST;


    [Header("Audio")]
    [SerializeField] AudioSource bgMusic;
    [SerializeField] AudioSource bgMusic2;
    [SerializeField] AudioSource birdSound;
    [SerializeField] AudioSource catSound;
    [SerializeField] AudioSource waterFlowSound;
    [SerializeField] AudioSource fallingTreeSound;
    [SerializeField] AudioSource breakTreeSound;
    [SerializeField] AudioSource portalSound;
    [SerializeField] AudioSource jumpSound;
    void Start()
    {                
        StartCoroutine(PlayScene2());
        StartCoroutine(NelioBlock1());
        //StartCoroutine(BreakTree());
        //StartCoroutine(ClimbTree());
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
            wUp.SetActive(!Input.GetKey(KeyCode.W));
        }

        if (nelio.transform.position.x >= 8f && nelio.transform.position.x <= 40f)
        {
            if(!waterFlowSound.isPlaying) waterFlowSound.Play();
            float x = nelio.transform.position.x;
            waterFlowSound.GetComponent<AudioSource>().volume = Mathf.Clamp((1 - Mathf.Abs(x - 24) / 16), 0.3f, 0.7f);
        }
        else
        {
            waterFlowSound.Stop();

        }
    }
    IEnumerator PlayScene2()
    {
        bgMusic.Play();
        birdSound.Play();
        blackBg.gameObject.SetActive(true);
        blackBg.CrossFadeAlpha(0, 5f, false);
        nelio.GetComponent<P_Block>().isBlock = true;
        yield return new WaitForSeconds(2f);
        milo.GetComponent<Animator>().SetBool("isRun", true);        
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2, 0);
        yield return new WaitUntil(() => milo.transform.position.x >= 5f);
        smallTalk1.SetActive(true);
        milo.GetComponent<Animator>().SetBool("isRun", false);
        milo.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<P_Block>().isBlock = false;
        tutorial1.SetActive(true);
        yield return new WaitUntil(() => nelio.transform.position.x >= -1f);
        smallTalk1.SetActive(false);
        yield return new WaitUntil(() => nelio.transform.position.x >= 3f);
        tutorial2.SetActive(true);
        milo.GetComponent<Animator>().SetBool("isRun", true);
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2, 0);
        yield return new WaitUntil(() => milo.transform.position.x >= 9f);
        milo.GetComponent<Animator>().SetBool("isRun", false);
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(1f, 5f);
        milo.GetComponent<Animator>().SetTrigger("Jump");
        if (milo.GetComponent<SpriteRenderer>().isVisible) jumpSound.Play();       
        yield return new WaitForSeconds(0.5f);
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 5f);
        milo.GetComponent<Animator>().SetTrigger("Jump");
        if (milo.GetComponent<SpriteRenderer>().isVisible) jumpSound.Play();
        yield return new WaitUntil(() => milo.transform.position.x >= 11f && milo.GetComponent<Milo_Jump>().isGround());
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0.7f, 5f);
        milo.GetComponent<Animator>().SetTrigger("Jump");
        if (milo.GetComponent<SpriteRenderer>().isVisible) jumpSound.Play();
        yield return new WaitForSeconds(0.5f);
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2f, 5f);
        milo.GetComponent<Animator>().SetTrigger("Jump");
        if (milo.GetComponent<SpriteRenderer>().isVisible) jumpSound.Play();
        yield return new WaitUntil(() => milo.transform.position.x >= 13f && milo.GetComponent<Milo_Jump>().isGround());
        milo.GetComponent<Animator>().SetBool("isRun", false);
        milo.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        yield return new WaitUntil(() => nelio.transform.position.x >= 12f);
        milo.GetComponent<Animator>().SetBool("isRun", true);
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2, 0);
        yield return new WaitUntil(() => milo.transform.position.x >= 30f);        
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(milo.GetComponent<Rigidbody2D>().linearVelocity.x, 5f);
        milo.GetComponent<Animator>().SetTrigger("Jump");
        if (milo.GetComponent<SpriteRenderer>().isVisible) jumpSound.Play();
        yield return new WaitUntil(() => milo.transform.position.x >= 33f);
        milo.GetComponent<Animator>().SetBool("isRun", false);
        milo.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        yield return new WaitUntil(() => nelio.transform.position.x >= 31f);
        milo.GetComponent<Animator>().SetBool("isRun", true);
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2.5f, 0);
        yield return new WaitUntil(() => milo.transform.position.x >= 63.5f);
        milo.GetComponent<Animator>().SetBool("isRun", false);
        milo.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        yield return new WaitUntil(() => nelio.transform.position.x >= 62.5f);
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        nelio.GetComponent<P_Block>().isBlock = true;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        cam2.SetActive(true);
        cam2.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2, 0.2f);
        yield return new WaitUntil(() => cam2.transform.position.x >= 69f);
        catSound.Play();
        cam2.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        cam2.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, 1.5f);
        yield return new WaitUntil(() => cam2.transform.position.y >= 11f);
        cam2.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(2.5f);        
        cam2.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        dialogStart.SetActive(true);
        catSound.Play();
        yield return new WaitUntil(() => dialogEnd.GetComponent<Dialog>().index > dialogEnd.GetComponent<Dialog>().lines.Length - 1 && !dialogEnd.activeSelf);
        bgMusic.Stop();
        nelio.GetComponent<P_Block>().isBlock = false;        
        StartCoroutine(ClimbTree());
    }

    IEnumerator ClimbTree()
    {
        tutorial1.SetActive(true);
        branchGround.SetActive(false);
        birdSound.Play();
        arrowDirect1.SetActive(false);
        arrowDirect2.SetActive(true);
        yield return new WaitUntil(() => nelio.transform.position.x >= 69f);
        arrowDirect2.SetActive(false);
        tutorial1.SetActive(false);
        tutorial3.SetActive(true);
        nelio.GetComponent<P_Block>().isBlock = true;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.W));
        nelio.GetComponent<Animator>().SetBool("isClimb", true);
        nelio.GetComponent<Rigidbody2D>().gravityScale = 0f;
        yield return new WaitForSeconds(0.3f);
        tutorial3.SetActive(false);
        yield return new WaitForSeconds(0.6f);
        nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 2f);
        yield return new WaitUntil(() => nelio.transform.position.y >= 11f);
        nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(1f, 0f);
        yield return new WaitUntil(() => nelio.transform.position.x >= 70f);
        branchGround.SetActive(true);
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Rigidbody2D>().gravityScale = 1f;
        nelio.GetComponent<Animator>().SetBool("isClimb", false);
        yield return new WaitUntil(() => nelio.GetComponent<P_Jump>().isGround());
        nelio.GetComponent<Animator>().SetBool("isRun", true);
        nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(1.5f, 0);
        yield return new WaitUntil(() => nelio.transform.position.x >= 72f);
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<P_Block>().isBlock = false;
        nelio.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        nelio.GetComponent<P_Move>().enabled = false;
        milo.transform.position = new Vector2(80f, milo.transform.position.y);
        milo.transform.localScale = new Vector3(-1, 1, 1);
        yield return new WaitForSeconds(1.5f);
        cam3.SetActive(true);
        yield return new WaitForSeconds(2f);
        smallTalk2.SetActive(true);
        yield return new WaitForSeconds(1.25f);
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal.SetActive(true);
        yield return new WaitForSeconds(2f);
        cam3.SetActive(false);
        smallTalk2.SetActive(false);
        yield return new WaitForSeconds(2f);
        smallTalk3.SetActive(true);
        yield return new WaitForSeconds(2f);
        smallTalk3.SetActive(false);
        StartCoroutine(BreakTree());

    }
    IEnumerator BreakTree()
    {        
        yield return new WaitForSeconds(0.1f);
        breakTreeSound.Play();
        yield return new WaitForSeconds(0.4f);
        branchBreak.transform.rotation = Quaternion.Euler(0, 0, -30);
        branchBreak.GetComponent<Rigidbody2D>().gravityScale = 2f; 
        fallFruit1.GetComponent<Rigidbody2D>().gravityScale = 2f;
        fallFruit2.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
        fallFruit3.GetComponent<Rigidbody2D>().gravityScale = 3f;
        fallFruit4.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
        holeGround.SetActive(false);
        branchGround.SetActive(false);        
        milo.GetComponent<Animator>().SetBool("isFall", true);
        yield return new WaitForSeconds(0.2f);
        fallingTreeSound.Play();
        yield return new WaitUntil(() => branchBreak.transform.position.y <= 5f);        
        branchBreak.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        branchBreak.GetComponent<Rigidbody2D>().gravityScale = 0f;
        yield return new WaitForSeconds(0.2f);
        hideGround.SetActive(false);
        yield return new WaitUntil(() => nelio.GetComponent<P_Jump>().isGround());  
        nelio.GetComponent<Animator>().SetTrigger("Hurt");
        grabTree.transform.position = new Vector2(79.65f, 2.7f);
        grabTree.transform.rotation = Quaternion.Euler(0, 0, -70);
        milo.transform.position = new Vector2(80f, 3.2f);
        milo.transform.rotation = Quaternion.Euler(0, 0, 100);
        milo.GetComponent<Rigidbody2D>().gravityScale = 0f;
        milo.GetComponent<Animator>().SetBool("isGrab", true);
        yield return new WaitForSeconds(2f);
        bgMusic2.Play();
        nelio.GetComponent<P_Block>().isBlock = true;
        cam3.SetActive(true);        
        yield return new WaitForSeconds(2f);
        smallTalk4.SetActive(true);
        catSound.Play();
        yield return new WaitForSeconds(2f);
        smallTalk4.SetActive(false);
        cam3.SetActive(false);
        yield return new WaitForSeconds(2f);
        //Tutorial Wall Jump
        tutorial1.SetActive(true);
        arrowDirect1.SetActive(false);
        tutorial2.SetActive(true);
        nelio.GetComponent<P_Block>().isBlock = false;
        nelio.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        nelio.GetComponent<P_Move>().enabled = true;        
        yield return new WaitUntil(() => nelio.transform.position.x >= 76f);
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        nelio.SetActive(false);  
        StartCoroutine(Cinematic());
        milo.GetComponent<Rigidbody2D>().linearVelocity = -milo.transform.up * 1.5f;
        grabTree.GetComponent<Rigidbody2D>().linearVelocity = grabTree.transform.up * 1.5f;
        yield return new WaitUntil(() => milo.transform.position.x >= 82f);
        milo.SetActive(false);
        milo.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        yield return new WaitUntil(() => grabTree.transform.position.x >= 82f);
        grabTree.SetActive(false);
        grabTree.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(0.25f);        
        portalSound.Play();
        yield return new WaitForSeconds(0.75f);
        portal.SetActive(false);
        yield return new WaitForSeconds(0.5f);        
        dialogEnd2.SetActive(true);
        bgMusic2.GetComponent<AudioSource>().volume = 0.8f;
        yield return new WaitForSeconds(0.2f);
        bgMusic2.GetComponent<AudioSource>().volume = 0.6f;        
        yield return new WaitUntil(() => dialogEnd2.GetComponent<Dialog>().index > dialogEnd2.GetComponent<Dialog>().lines.Length - 1 && !dialogEnd2.activeSelf);        
        bgMusic2.GetComponent<AudioSource>().volume = 0.3f;
        yield return new WaitForSeconds(0.2f);
        bgMusic2.GetComponent<AudioSource>().volume = 0.1f;
        StartCoroutine(NextScene3());
    }    

    IEnumerator NextScene3()
    {                
        blackBg.gameObject.SetActive(true);
        blackBg.CrossFadeAlpha(1, 3f, false);        
        yield return new WaitForSeconds(6f);
        NST.SetActive(true);        
        yield return new WaitUntil(() => NST.GetComponent<Dialog>().index > NST.GetComponent<Dialog>().lines.Length - 1 && !NST.activeSelf);
        SceneManager.LoadScene("S3");
    }    

    IEnumerator Cinematic()
    {
        neCin1.SetActive(true);
        yield return new WaitForSeconds(0.15f);        
        neCin2.SetActive(true);
        neCin1.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        neCin3.SetActive(true);
        neCin2.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        neCin4.SetActive(true);
        neCin3.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        neCin5.SetActive(true);
        neCin4.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        neCin6.SetActive(true);
        neCin5.SetActive(false);
    }

    IEnumerator NelioBlock1()
    {
        yield return new WaitUntil(() => nelio.transform.position.x >= 62.5f);
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        nelio.GetComponent<P_Block>().isBlock = true;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
    }




}
