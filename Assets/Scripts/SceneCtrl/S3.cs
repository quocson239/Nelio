using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Splines.SplineInstantiate;

public class S3 : MonoBehaviour
{
    [SerializeField] GameObject nelio;
    [SerializeField] GameObject pan;
    [SerializeField] Image blackBg;
    [SerializeField] GameObject dialog1Start;
    [SerializeField] GameObject dialog1End;
    [SerializeField] GameObject dialog2Start;
    [SerializeField] GameObject dialog2End;
    [SerializeField] GameObject dialog3Start;
    [SerializeField] GameObject dialog3End;
    [SerializeField] GameObject cam2;
    [SerializeField] GameObject NST1;
    [SerializeField] GameObject dummy1;
    [SerializeField] GameObject dummy2;
    [SerializeField] GameObject tutorial1;
    [SerializeField] GameObject tutorial2;
    [SerializeField] GameObject tutorial3;
    [SerializeField] GameObject tutorial4;    
    [SerializeField] GameObject mouseDownL;
    [SerializeField] GameObject mouseDownR;
    [SerializeField] GameObject mouseDownBoth;
    [SerializeField] GameObject aUp;
    [SerializeField] GameObject dUp;
    [SerializeField] GameObject eUp;
    [SerializeField] GameObject spaceUp;
    [SerializeField] GameObject background;
    [SerializeField] GameObject mission;
    [SerializeField] TextMeshProUGUI C1;
    [SerializeField] TextMeshProUGUI C2;
    [SerializeField] TextMeshProUGUI C3;
    [SerializeField] TextMeshProUGUI C4;
    [SerializeField] GameObject Y1;
    [SerializeField] GameObject Y2;
    [SerializeField] GameObject Y3;
    [SerializeField] GameObject Y4;
    [SerializeField] GameObject dialog4Start;
    [SerializeField] GameObject dialog4End;
    [SerializeField] GameObject gift;
    [SerializeField] GameObject dialog5Start;
    [SerializeField] GameObject dialog5End;
    [SerializeField] GameObject cam3;
    [SerializeField] GameObject dialogStartTraining;
    [SerializeField] GameObject NST2;

    [Header("Audio")]
    [SerializeField] AudioSource bgMusic;
    [SerializeField] AudioSource bgMusic2;
    [SerializeField] AudioSource panHeySound;
    [SerializeField] AudioSource CompleteSound;
    [SerializeField] AudioSource panAllDoneSound;
    [SerializeField] AudioSource panReadySound;
    [SerializeField] AudioSource giftSound;
    [SerializeField] AudioSource panLaugh;

    void Start()
    {
        //background.GetComponent<SpriteRenderer>().color = new Color32(139, 159, 158, 255);
        blackBg.gameObject.SetActive(true);
        StartCoroutine(PlayScene3());
        //StartCoroutine(TrainingScene());
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
            eUp.SetActive(!Input.GetKey(KeyCode.E));
        }
        if (tutorial4.activeSelf)
        {
            mouseDownL.SetActive(Input.GetMouseButton(0) && !Input.GetMouseButton(1));
            mouseDownR.SetActive(Input.GetMouseButton(1) && !Input.GetMouseButton(0));
            mouseDownBoth.SetActive(Input.GetMouseButton(0) && Input.GetMouseButton(1));            
        }
        if(mission.activeSelf)
        {
            if(nelio != null)
            {
                if (nelio.GetComponent<P_Attack>().c1 <= 5) C1.text = "(" + nelio.GetComponent<P_Attack>().c1.ToString() + "/5" + ")";
                if (nelio.GetComponent<P_Attack>().c2 <= 5) C2.text = "(" + nelio.GetComponent<P_Attack>().c2.ToString() + "/5" + ")";
                if (nelio.GetComponent<P_Attack>().c3 <= 5) C3.text = "(" + nelio.GetComponent<P_Attack>().c3.ToString() + "/5" + ")";
                if (nelio.GetComponent<P_Attack>().c4 <= 5) C4.text = "(" + nelio.GetComponent<P_Attack>().c4.ToString() + "/5" + ")";
            }
            if (nelio.GetComponent<P_Attack>().c1 >= 5 && !Y1.activeSelf)
            {
                CompleteSound.Play();
                Y1.SetActive(true);
            }
            if (nelio.GetComponent<P_Attack>().c2 >= 5 && !Y2.activeSelf)
            {
                CompleteSound.Play();
                Y2.SetActive(true);
            }
            if (nelio.GetComponent<P_Attack>().c3 >= 5 && !Y3.activeSelf)
            {
                CompleteSound.Play();
                Y3.SetActive(true);
            }
            if (nelio.GetComponent<P_Attack>().c4 >= 5 && !Y4.activeSelf)
            {
                CompleteSound.Play();
                Y4.SetActive(true);
            }
        }


    }

    IEnumerator PlayScene3()
    {
        bgMusic.Play();
        nelio.GetComponent<P_Block>().isBlock = true;
        blackBg.CrossFadeAlpha(0, 15f, false);              
        yield return new WaitForSeconds(4f);
        blackBg.CrossFadeAlpha(0, 1f, false);
        dialog1Start.SetActive(true);
        yield return new WaitUntil(() => dialog1End.GetComponent<Dialog>().index > dialog1End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog1End.activeSelf);
        yield return new WaitForSeconds(2f);
        panHeySound.Play();
        dialog2Start.SetActive(true);
        yield return new WaitUntil(() => dialog2Start.GetComponent<Dialog>().index > dialog2Start.GetComponent<Dialog>().lines.Length - 1 
                                    && !dialog2Start.activeSelf);
        nelio.transform.localScale = new Vector3(-1, 1, 1);
        yield return new WaitUntil(() => dialog2End.GetComponent<Dialog>().index > dialog2End.GetComponent<Dialog>().lines.Length - 1 
                                    && !dialog2End.activeSelf);
        pan.transform.localScale = new Vector3(-1, 1, 1);
        cam2.SetActive(true);
        yield return new WaitForSeconds(2f);
        dialog3Start.SetActive(true);
        yield return new WaitUntil(() => dialog3End.GetComponent<Dialog>().index > dialog3End.GetComponent<Dialog>().lines.Length - 1 
                                    && !dialog3End.activeSelf);
        blackBg.CrossFadeAlpha(1, 3f, false);
        bgMusic.GetComponent<AudioSource>().volume = 0.4f;
        yield return new WaitForSeconds(0.5f);
        bgMusic.GetComponent<AudioSource>().volume = 0.3f;
        yield return new WaitForSeconds(0.5f);
        bgMusic.GetComponent<AudioSource>().volume = 0.2f;
        yield return new WaitForSeconds(0.5f);
        bgMusic.GetComponent<AudioSource>().volume = 0.1f;
        yield return new WaitForSeconds(0.5f);
        bgMusic.Stop();
        yield return new WaitForSeconds(2f);
        NST1.SetActive(true);
        yield return new WaitUntil(() => NST1.GetComponent<Dialog>().index > NST1.GetComponent<Dialog>().lines.Length - 1
                                    && !NST1.activeSelf);
        StartCoroutine(TrainingScene());
    }    
    IEnumerator TrainingScene()
    {
        nelio.GetComponent<P_Block>().isBlock = true;
        bgMusic2.Play();
        background.GetComponent<SpriteRenderer>().color = new Color32(139, 159, 158, 255);
        cam2.SetActive(false);
        pan.transform.position = new Vector3(85f, 3.2f, 0);
        pan.transform.localScale = new Vector3(1, 1, 1);
        dummy1.SetActive(true);
        dummy2.SetActive(true);
        yield return new WaitForSeconds(1f);
        blackBg.CrossFadeAlpha(0, 15f, false);
        yield return new WaitForSeconds(4f);
        blackBg.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(1f);
        dialogStartTraining.SetActive(true);
        yield return new WaitUntil(() => dialogStartTraining.GetComponent<Dialog>().index > dialogStartTraining.GetComponent<Dialog>().lines.Length - 1
                                    && !dialogStartTraining.activeSelf);
        panReadySound.Play();
        mission.SetActive(true);
        yield return new WaitForSeconds(2f);
        nelio.GetComponent<P_Block>().isBlock = false;
        tutorial1.SetActive(true);
        tutorial2.SetActive(true);
        tutorial4.SetActive(true);
        yield return new WaitUntil(() => Y1.activeSelf && Y2.activeSelf && Y3.activeSelf && Y4.activeSelf);
        yield return new WaitForSeconds(1f);
        panAllDoneSound.Play();
        yield return new WaitForSeconds(1f);
        nelio.GetComponent<P_Block>().isBlock = true;
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial4.SetActive(false);
        mission.SetActive(false);
        yield return new WaitForSeconds(1f);
        cam3.SetActive(true);
        if (nelio.transform.position.x < 83f)
        {
            nelio.transform.localScale = new Vector3(1, 1, 1);
            nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(3, 0);
            nelio.GetComponent<Animator>().SetBool("isRun", true);
        }
        else if(nelio.transform.position.x > 83f)
        {
            nelio.transform.localScale = new Vector3(-1, 1, 1);
            nelio.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-3, 0);
            nelio.GetComponent<Animator>().SetBool("isRun", true);
        }
        yield return new WaitUntil(() => Mathf.Abs(nelio.transform.position.x - 83f) < 0.5f);
        nelio.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        nelio.GetComponent<Animator>().SetBool("isRun", false);
        nelio.transform.localScale = new Vector3(1, 1, 1);
        dialog4Start.SetActive(true);
        yield return new WaitUntil(() => dialog4End.GetComponent<Dialog>().index > dialog4End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog4End.activeSelf);
        //Gift Bottle Here
        gift.SetActive(true);
        giftSound.Play();
        tutorial3.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        yield return new WaitForSeconds(0.3f);
        gift.SetActive(false);
        tutorial3.SetActive(false);
        dialog5Start.SetActive(true);
        yield return new WaitUntil(() => dialog5Start.GetComponent<Dialog>().index > dialog5Start.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog5Start.activeSelf);
        panLaugh.Play();
        yield return new WaitUntil(() => dialog5End.GetComponent<Dialog>().index > dialog5End.GetComponent<Dialog>().lines.Length - 1
                                    && !dialog5End.activeSelf);
        blackBg.CrossFadeAlpha(1, 3f, false);
        bgMusic2.GetComponent<AudioSource>().volume = 0.4f;
        yield return new WaitForSeconds(0.5f);
        bgMusic2.GetComponent<AudioSource>().volume = 0.3f;
        yield return new WaitForSeconds(0.5f);
        bgMusic2.GetComponent<AudioSource>().volume = 0.2f;
        yield return new WaitForSeconds(0.5f);
        bgMusic2.GetComponent<AudioSource>().volume = 0.1f;
        yield return new WaitForSeconds(0.5f);
        bgMusic2.Stop();
        StartCoroutine(NextScene4());
    }

    IEnumerator NextScene4()
    {
        blackBg.gameObject.SetActive(true);
        blackBg.CrossFadeAlpha(1, 3f, false);
        yield return new WaitForSeconds(3f);
        NST2.SetActive(true);
        yield return new WaitUntil(() => NST2.GetComponent<Dialog>().index > NST2.GetComponent<Dialog>().lines.Length - 1 && !NST2.activeSelf);
        SceneManager.LoadScene("S4");
    }
}
