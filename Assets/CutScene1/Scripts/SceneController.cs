using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class SceneController : MonoBehaviour
{
    public GameObject Fade;
    public GameObject cat;
    public GameObject cauthoai;
    public GameObject BG;
    public GameObject Cat_eyes;
    public GameObject Title;
    [SerializeField] AudioSource meo;

    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject hopthoai;
    [SerializeField] GameObject NextBttn;
    [SerializeField] int eventPos = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(EventStarter());
        NextBttn.GetComponent<Button>().onClick.AddListener(NextButton);
    }

    // Update is called once per frame
    void Update()
    {
        textLength = TextCreator.charCount;
    }
    IEnumerator EventStarter()
    {
        Cat_eyes.SetActive(true);
        BG.SetActive(true);
        yield return new WaitForSeconds(6);
         meo.Play();
        cauthoai.SetActive(true);
        hopthoai.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Một hang động lạnh lẽo. Không có tiếng người. Không có ánh sáng.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 1;
    }

    IEnumerator EventOne()
    {
        NextBttn.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Chỉ còn lại... sự im lặng và nỗi cô đơn bao trùm.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 2;
    }
    public void NextButton()
    {
        if (eventPos == 1)
        {
            StartCoroutine(EventOne());
        }
        else if (eventPos == 2)
        {
            StartCoroutine(EventTwo());
        }
        else if (eventPos == 3)
        {
            StartCoroutine(EventThree());
        }
        else if (eventPos == 4)
        {
            StartCoroutine(EventFour());
        }
        else if (eventPos == 5)
        {
            StartCoroutine(EventFive());
        }
        else if (eventPos == 6)
        {
            StartCoroutine(EventSix());
        }
        else if (eventPos == 7)
        {
            StartCoroutine(NextScene());
        }
    }
    IEnumerator EventTwo()
    {
        NextBttn.SetActive(false);
        cat.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "…Mình đang ở đâu vậy…?";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 3;
    }
    IEnumerator EventThree()
    {
        NextBttn.SetActive(false);
        cat.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Không ai ở đây…mình…chỉ còn một mình thôi sao?";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 4;
    }
    IEnumerator EventFour()
    {
        NextBttn.SetActive(false);
        cat.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "...Có ai ở đây không...?";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 5;
    }
    IEnumerator EventFive()
    {
        NextBttn.SetActive(false);
        cat.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = " ...Mình... chỉ muốn nghe ai đó trả lời...";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 6;
    }
    IEnumerator EventSix()
    {
        NextBttn.SetActive(false);
        cat.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "  ...Im lặng quá…";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 7;
    }

    IEnumerator NextScene()
    {
        NextBttn.SetActive(false);
        Fade.SetActive(true);
        yield return new WaitForSeconds(2);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Map");
    }
}
