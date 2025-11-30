using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class SceneController2_end : MonoBehaviour
{
    public GameObject Fade;
    public GameObject cat;
    public GameObject cauthoai;
    public GameObject BG;
    public GameObject Title;
    public GameObject Catandlighthere;
    public GameObject Fade2;
    public GameObject endc2;
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
        textToSpeak = "...Mình đã nhảy... và thất bại.";
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
        textToSpeak = "..Nhưng chính điều đó lại mở ra con đường mới.";
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
        else if (eventPos == 10)
        {
            StartCoroutine(EventTen());
        }
        else if (eventPos == 11)
        {
            StartCoroutine(EventEleven());
        }
        else if (eventPos == 12)
        {
            StartCoroutine(EventTwelve());
        }
        else if (eventPos == 13)
        {
            StartCoroutine(EventThirteen());
        }
    }
    IEnumerator EventTwo()
    {
        NextBttn.SetActive(false);
        cat.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Có lẽ... không phải lúc nào con đường dễ thấy nhất cũng là con đường đúng.";
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
        textToSpeak = "...Mình từng nghĩ thất bại là kết thúc.";
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
        textToSpeak = "Nhưng giờ mình hiểu... nó chỉ là một phần của hành trình.";
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
        textToSpeak = "Nếu cứ sợ sai... mình sẽ chẳng bao giờ dám đi tiếp.";
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
        textToSpeak = "Thất bại không giết mình. Nó dạy mình cách khác.";
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
        cat.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Mình... vẫn đang học cách tin vào chính mình.";
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
        textToSpeak = "Có những thất bại tưởng như là dấu chấm hết.";
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
        cat.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Nhưng đôi khi, chính cú ngã ấy… mở ra lối đi khác.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 10;
    }
    IEnumerator EventTen()
    {
        NextBttn.SetActive(false);
        cat.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Khi mọi thứ trước mắt đều dẫn đến bế tắc, hãy nhớ:";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 11;
    }
    IEnumerator EventEleven()
    {
        NextBttn.SetActive(false);
        cat.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Không phải con đường nào cũng nằm phía trước.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 12;
    }
    IEnumerator EventTwelve()
    {
        NextBttn.SetActive(false);
        cat.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Có lối đi… chỉ xuất hiện sau khi bạn dám thất bại một lần.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 13;
    }
    IEnumerator EventThirteen()
    {
        NextBttn.SetActive(false);
        Fade2.SetActive(true);
        yield return new WaitForSeconds(2f);
        Catandlighthere.SetActive(true);
        meo.Play();
        yield return new WaitForSeconds(4f);
        endc2.SetActive(true);
    }
}
