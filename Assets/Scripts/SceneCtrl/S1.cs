using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S1 : MonoBehaviour
{
    [SerializeField] GameObject milo;
    [SerializeField] GameObject nelio;
    [SerializeField] Image blackBg;
    [SerializeField] GameObject dialogStart;
    [SerializeField] GameObject dialogEnd;
    [SerializeField] GameObject tutorial;
    [SerializeField] GameObject aUp;
    [SerializeField] GameObject dUp;

    [Header("Audio")]
    [SerializeField] AudioSource bgMusic;
    [SerializeField] AudioSource birdSound;
    [SerializeField] AudioSource catSound;

    void Start()
    {
        nelio.GetComponent<P_Block>().isBlock = true;
        milo.transform.localScale = new Vector3(-1, 1, 1);
        StartCoroutine(PlayScene1());
    }
    
    void Update()
    {
        if(tutorial.activeSelf)
        {
            aUp.SetActive(!Input.GetKey(KeyCode.A));
            dUp.SetActive(!Input.GetKey(KeyCode.D));
        }
    }

    IEnumerator PlayScene1()
    {
        blackBg.gameObject.SetActive(true);
        dialogStart.SetActive(true);
        catSound.Play();        
        yield return new WaitUntil(() => dialogStart.GetComponent<Dialog>().index > dialogStart.GetComponent<Dialog>().lines.Length - 1 && !dialogStart.activeSelf);
        birdSound.Play();
        bgMusic.Play();
        blackBg.CrossFadeAlpha(0, 10f, false);
        yield return new WaitUntil(() => dialogEnd.GetComponent<Dialog>().index > dialogEnd.GetComponent<Dialog>().lines.Length - 1 && !dialogEnd.activeSelf);
        milo.transform.localScale = new Vector3(1, 1, 1);
        milo.GetComponent<Animator>().SetBool("isRun", true);
        milo.GetComponent<Rigidbody2D>().gravityScale = 0;
        milo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(2, 0);
        yield return new WaitUntil(() => milo.transform.position.x >= 7.5f);
        milo.SetActive(false);
        nelio.GetComponent<P_Block>().isBlock = false;
        tutorial.SetActive(true);
        yield return new WaitUntil(() => nelio.transform.position.x >= 7.5f);
        nelio.GetComponent<P_Block>().isBlock = true;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        blackBg.CrossFadeAlpha(1, 3f, false);
        yield return new WaitForSeconds(1.5f);
        nelio.SetActive(false);
        tutorial.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("S2");
    }
    
}
