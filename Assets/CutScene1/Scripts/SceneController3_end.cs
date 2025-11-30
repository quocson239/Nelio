using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class SceneController3_end : MonoBehaviour
{
    public GameObject Fade;
    public GameObject cat_binhthuong;
    public GameObject cat_buonba;
    public GameObject cauthoai;
    public GameObject BG;
    public GameObject Title;
    public GameObject Catandlighthere;
    public GameObject Fade2;
    public GameObject endc3;
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
        cat_binhthuong.SetActive(true);
        cauthoai.SetActive(true);
        hopthoai.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Mọi thứ bắt đầu đẹp đẽ đến kỳ lạ...";
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
        cat_binhthuong.SetActive(false);
        cat_buonba.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Và rồi... mình mất kiểm soát.";
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
        else if (eventPos == 14)
        {
            StartCoroutine(EventFourteen());
        }
        else if (eventPos == 15)
        {
            StartCoroutine(EventFifteen());
        }
        else if (eventPos == 16)
        {
            StartCoroutine(EventSixteen());
        }
        else if (eventPos == 17)
        {
            StartCoroutine(EventSeventeen());
        }
        else if (eventPos == 18)
        {
            StartCoroutine(EventEightteen());
        }
        else if (eventPos == 19)
        {
            StartCoroutine(EventNineteen());
        }
        else if (eventPos == 20)
        {
            StartCoroutine(EventTwenty());
        }
        else if (eventPos == 21)
        {
            StartCoroutine(EventTwentyOne());
        }
        else if (eventPos == 22)
        {
            StartCoroutine(EventTwentyTwo());
        }
        else if (eventPos == 23)
        {
            StartCoroutine(EventTwentyThree());
        }
    }
    IEnumerator EventTwo()
    {
        NextBttn.SetActive(false);
        cat_binhthuong.SetActive(false);
        cat_buonba.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Không còn biết đâu là thật, đâu là ảo...";
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
        cat_binhthuong.SetActive(false);
        cat_buonba.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Cứ như thế… từng bước một, mình trượt dài.";
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
        cat_binhthuong.SetActive(false);
        cat_buonba.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Những thứ tưởng là cứu rỗi… lại khiến mình rơi vào hỗn loạn.";
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
        cat_binhthuong.SetActive(false);
        cat_buonba.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Mình đã dùng rượu... để thoát.";
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
        cat_binhthuong.SetActive(false);
        cat_buonba.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Và rồi... mình cũng suýt mất tất cả.";
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
        cat_buonba.SetActive(false);
        cat_binhthuong.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "...Nhưng không thể đổ lỗi cho rượu...";
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
        cat_buonba.SetActive(false);
        cat_binhthuong.SetActive(true);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Bạn";
        textToSpeak = "Lỗi là ở mình – vì đã không kiểm soát được chính mình.";
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
        cat_buonba.SetActive(false);
        cat_binhthuong.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Không phải thứ gì khiến ta dễ chịu… cũng là thứ nên giữ lại lâu dài.";
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
        cat_buonba.SetActive(false);
        cat_binhthuong.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Thư giãn là một liều thuốc – nhưng lạm dụng nó, và nó sẽ trở thành độc dược.";
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
        cat_buonba.SetActive(false);
        cat_binhthuong.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Có những khoảnh khắc yên bình đến mức ta không muốn quay về…";
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
        cat_buonba.SetActive(false);
        cat_binhthuong.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Nhưng chính lúc ấy, ta bắt đầu mất mình.";
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
        cat_binhthuong.SetActive(false);
        cat_buonba.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Thư giãn là một món quà – nhưng không có kỷ luật, nó trở thành xiềng xích.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 14;
    }
    IEnumerator EventFourteen()
    {
        NextBttn.SetActive(false);
        cat_binhthuong.SetActive(false);
        cat_buonba.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = " Có những nơi khiến ta quên đi tất cả, kể cả chính bản thân mình.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 15;
    }
    IEnumerator EventFifteen()
    {
        NextBttn.SetActive(false);
        cat_binhthuong.SetActive(false);
        cat_buonba.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = " Trốn chạy dưới vỏ bọc “nghỉ ngơi” chỉ dẫn ta xa rời con đường thật.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 16;
    }
    IEnumerator EventSixteen()
    {
        NextBttn.SetActive(false);
        cat_binhthuong.SetActive(false);
        cat_buonba.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = " Muốn đi xa… trước hết phải học cách kiểm soát chính mình.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 17;
    }
    IEnumerator EventSeventeen()
    {
        NextBttn.SetActive(false);
        cat_binhthuong.SetActive(false);
        cat_buonba.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Sự an toàn giả tạo có thể giết chết ý chí.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 18;
    }
    IEnumerator EventEightteen()
    {
        NextBttn.SetActive(false);
        cat_binhthuong.SetActive(false);
        cat_buonba.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Không có kỷ luật, sự dễ chịu sẽ nuốt chửng tất cả.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 19;
    }
    IEnumerator EventNineteen()
    {
        NextBttn.SetActive(false);
        cat_binhthuong.SetActive(false);
        cat_buonba.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Không phải mọi cảm giác nhẹ nhõm đều đúng lúc.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 20;
    }
    IEnumerator EventTwenty()
    {
        NextBttn.SetActive(false);
        cat_binhthuong.SetActive(false);
        cat_buonba.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Không phải mọi nơi yên bình đều nên ở lại mãi.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 21;
    }
    IEnumerator EventTwentyOne()
    {
        NextBttn.SetActive(false);
        cat_binhthuong.SetActive(false);
        cat_buonba.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Giờ ta hiểu…";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 22;
    }
    IEnumerator EventTwentyTwo()
    {
        NextBttn.SetActive(false);
        cat_binhthuong.SetActive(false);
        cat_buonba.SetActive(false);
        Title.GetComponent<TMPro.TextMeshProUGUI>().text = "Dẫn truyện";
        textToSpeak = "Thật ra, giữ vững được bản thân mới là nghỉ ngơi đúng nghĩa.";
        cauthoai.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        NextBttn.SetActive(true);
        eventPos = 23;
    }
    IEnumerator EventTwentyThree()
    {
        NextBttn.SetActive(false);
        Fade2.SetActive(true);
        yield return new WaitForSeconds(2f);
        Catandlighthere.SetActive(true);
        meo.Play();
        yield return new WaitForSeconds(4f);
        endc3.SetActive(true);
    }
}
