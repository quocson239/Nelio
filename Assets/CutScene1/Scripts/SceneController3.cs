using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class SceneController3 : MonoBehaviour
{
    public GameObject Fade;
    public GameObject cat_vuive;
    public GameObject cat_thugian;
    public GameObject cauthoai;
    public GameObject BG;
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
        BG.SetActive(true);
        yield return new WaitForSeconds(5);
        cauthoai.SetActive(true);
        hopthoai.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Một khu rừng mộng mị. Ánh sáng xuyên qua tán lá dịu dàng như ru ngủ.";
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
        textToSpeak = "Tiếng suối chảy… mùi hoa… tiếng cười khe khẽ vọng xa.";
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
    }
    IEnumerator EventTwo()
    {
        NextBttn.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Không còn tiếng bước chân gấp gáp. Không còn nỗi sợ.";
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
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Chỉ còn sự êm đềm… như thể đây là nơi để nghỉ ngơi mãi mãi.";
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
        cat_vuive.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = " Ở đây đẹp thật đấy";
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
        cat_thugian.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = " Thoải mái quá";
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
        cat_thugian.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = " Cơ thể mình… như tan vào không khí. Nhẹ bẫng.";
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
        cat_thugian.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Có lẽ… mình nên dừng lại một lúc? Nghỉ một chút thôi...";
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
        cat_thugian.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "…Một chút thôi mà…";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
    }
}
