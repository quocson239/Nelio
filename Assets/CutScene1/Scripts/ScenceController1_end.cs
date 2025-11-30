using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class SceneController1_end : MonoBehaviour
{
    public GameObject Fade;
    public GameObject cat;
    public GameObject cauthoai;
    public GameObject BG;
    public GameObject Title;
    public GameObject Catandlighthere;
    public GameObject Fade2;
    public GameObject endc1;
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
        BG.SetActive(true);
        yield return new WaitForSeconds(3);
        meo.Play();
        cat.SetActive(true);
        cauthoai.SetActive(true);
        hopthoai.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Không có ai chờ mình ở cuối con đường.";
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
        cat.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Nhưng... mình vẫn đến được đây.";
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
            StartCoroutine(EventSeven());
        }
        else if (eventPos == 8)
        {
            StartCoroutine(EventEight());
        }
        else if (eventPos == 9)
        {
            StartCoroutine(EventNine());
        }
    }
    IEnumerator EventTwo()
    {
        NextBttn.SetActive(false);
        cat.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Một mình, nhưng không còn thấy sợ nữa.";
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
        textToSpeak = "Có lẽ... không cần ai nắm tay, mình vẫn có thể bước tiếp.";
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
        cat.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Cô đơn là bóng tối đầu tiên mà con người phải đi qua.";
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
        cat.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = " Không có bản đồ, không có người chỉ đường, không có sự đảm bảo nào cả.";
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
        cat.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = " Nhưng chính trong những lúc đó, bạn học được cách nghe rõ nhịp tim của mình";
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
    IEnumerator EventSeven()
    {
        NextBttn.SetActive(false);
        cat.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = " và hiểu rằng";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 8;
    }
    IEnumerator EventEight()
    {
        NextBttn.SetActive(false);
        cat.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Bản thân bạn chính là ánh sáng đầu tiên mà bạn cần.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 9;
        
    }
    IEnumerator EventNine()
    {
        NextBttn.SetActive(false);
        Fade2.SetActive(true);
        yield return new WaitForSeconds(2f);
        Catandlighthere.SetActive(true);
        meo.Play();
        yield return new WaitForSeconds(4f);
        endc1.SetActive(true);
    }    
}
