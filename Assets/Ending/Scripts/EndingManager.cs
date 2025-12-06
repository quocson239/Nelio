using System.Collections;
using TMPro;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public TextMeshProUGUI THOAI_ENDING;
    public GameObject catrun;
    public GameObject fireflies;

    public GameObject catrun2;
    public GameObject fireflies2;

    public GameObject effect1;
    public GameObject effect2;
    public GameObject effect3;

    [SerializeField] string textToSpeak;

    public GameObject nelio;
    void Start()
    {
        StartCoroutine(EventStarter());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator EventStarter()
    {
        yield return new WaitForSeconds(1f);
        THOAI_ENDING.CrossFadeAlpha(0f, 0.3f, false);
        yield return new WaitForSeconds(1f);
        effect1.SetActive(true);
        effect2.SetActive(true);
        effect3.SetActive(true);
        textToSpeak = "Chúc mừng bạn đã vượt qua toàn bộ thử thách.";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        THOAI_ENDING.CrossFadeAlpha(1f, 3f, false);
        yield return new WaitForSeconds(3f);


        yield return new WaitForSeconds(0.1f);
        THOAI_ENDING.CrossFadeAlpha(0f, 2f, false);
        yield return new WaitForSeconds(2f);
        effect3.SetActive(false);
        catrun.SetActive(true);
        fireflies.SetActive(true);
        textToSpeak = "Cảm ơn bạn đã chơi game của chúng tôi đến cuối cùng.";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        THOAI_ENDING.CrossFadeAlpha(1f, 3f, false);
        yield return new WaitForSeconds(3f);


        yield return new WaitForSeconds(0.1f);
        THOAI_ENDING.CrossFadeAlpha(0f, 2f, false);
        yield return new WaitForSeconds(2f);
        catrun.SetActive(false);
        fireflies.SetActive(false);
        catrun2.SetActive(true);
        fireflies2.SetActive(true);
        textToSpeak = "Hy vọng câu chuyện này chạm đến trái tim bạn,\n\nnhư cách nó đã chạm vào chúng tôi.";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        THOAI_ENDING.CrossFadeAlpha(1f, 3f, false);
        yield return new WaitForSeconds(3f);


        yield return new WaitForSeconds(0.1f);
        THOAI_ENDING.CrossFadeAlpha(0f, 2f, false);
        yield return new WaitForSeconds(2f);
        catrun.SetActive(true);
        fireflies.SetActive(true);
        catrun2.SetActive(false);
        fireflies2.SetActive(false);
        textToSpeak = "Khi viết nên hành trình của Nelio, chúng tôi nhận ra một điều:";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        THOAI_ENDING.CrossFadeAlpha(1f, 3f, false);
        yield return new WaitForSeconds(3f);

        yield return new WaitForSeconds(0.1f);
        THOAI_ENDING.CrossFadeAlpha(0f, 2f, false);
        yield return new WaitForSeconds(2f);
        catrun.SetActive(false);
        fireflies.SetActive(false);
        catrun2.SetActive(true);
        fireflies2.SetActive(true);
        textToSpeak = "Đôi khi thứ khiến chúng ta đau nhất không phải là mất mát";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        THOAI_ENDING.CrossFadeAlpha(1f, 3f, false);
        yield return new WaitForSeconds(3f);

        yield return new WaitForSeconds(0.1f);
        THOAI_ENDING.CrossFadeAlpha(0f, 2f, false);
        yield return new WaitForSeconds(2f);
        catrun.SetActive(false);
        fireflies.SetActive(false);
        catrun2.SetActive(true);
        fireflies2.SetActive(true);
        textToSpeak = "Mà là cảm giác bất lực khi không thể làm gì để giữ lại.";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        THOAI_ENDING.CrossFadeAlpha(1f, 3f, false);
        yield return new WaitForSeconds(3f);

        yield return new WaitForSeconds(0.1f);
        THOAI_ENDING.CrossFadeAlpha(0f, 2f, false);
        yield return new WaitForSeconds(2f);
        catrun.SetActive(true);
        fireflies.SetActive(true);
        catrun2.SetActive(false);
        fireflies2.SetActive(false);
        textToSpeak = "Cánh cổng trong câu chuyện chỉ là biểu tượng.";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        THOAI_ENDING.CrossFadeAlpha(1f, 3f, false);
        yield return new WaitForSeconds(3f);

        yield return new WaitForSeconds(0.1f);
        THOAI_ENDING.CrossFadeAlpha(0f, 2f, false);
        yield return new WaitForSeconds(2f);
        catrun.SetActive(false);
        fireflies.SetActive(false);
        catrun2.SetActive(true);
        fireflies2.SetActive(true);
        textToSpeak = "Nó đại diện cho những lựa chọn khó khăn mà mỗi người đều sẽ gặp trong đời";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        THOAI_ENDING.CrossFadeAlpha(1f, 3f, false);
        yield return new WaitForSeconds(3f);

        yield return new WaitForSeconds(0.1f);
        THOAI_ENDING.CrossFadeAlpha(0f, 2f, false);
        yield return new WaitForSeconds(2f);
        catrun.SetActive(true);
        fireflies.SetActive(true);
        catrun2.SetActive(false);
        fireflies2.SetActive(false);
        textToSpeak = "Hành trình của Nelio nhắc tôi nhớ rằng mỗi chúng ta đều có một phần yếu đuối";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        THOAI_ENDING.CrossFadeAlpha(1f, 3f, false);
        yield return new WaitForSeconds(3f);

        yield return new WaitForSeconds(0.1f);
        THOAI_ENDING.CrossFadeAlpha(0f, 2f, false);
        yield return new WaitForSeconds(2f);
        catrun.SetActive(false);
        fireflies.SetActive(false);
        catrun2.SetActive(true);
        fireflies2.SetActive(true);
        textToSpeak = "Nhưng chính khi ta đối diện với nó…\n\nta mới biết mình mạnh mẽ đến đâu.";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        THOAI_ENDING.CrossFadeAlpha(1f, 3f, false);
        yield return new WaitForSeconds(3f);

        yield return new WaitForSeconds(0.1f);
        THOAI_ENDING.CrossFadeAlpha(0f, 2f, false);
        yield return new WaitForSeconds(2f);
        catrun.SetActive(true);
        fireflies.SetActive(true);
        catrun2.SetActive(false);
        fireflies2.SetActive(false);
        textToSpeak = "Nếu câu chuyện này mang đến cho bạn dù chỉ một suy nghĩ nhỏ, một khoảnh khắc nhìn lại điều quan trọng với bạn";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        THOAI_ENDING.CrossFadeAlpha(1f, 3f, false);
        yield return new WaitForSeconds(3f);

        yield return new WaitForSeconds(0.1f);
        THOAI_ENDING.CrossFadeAlpha(0f, 2f, false);
        yield return new WaitForSeconds(2f);
        catrun.SetActive(false);
        fireflies.SetActive(false);
        catrun2.SetActive(true);
        fireflies2.SetActive(true);
        textToSpeak = "Thì hành trình của Nelio đã hoàn thành ý nghĩa của nó";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        THOAI_ENDING.CrossFadeAlpha(1f, 3f, false);
        yield return new WaitForSeconds(3f);


        yield return new WaitForSeconds(0.1f);
        THOAI_ENDING.CrossFadeAlpha(0f, 2f, false);
        yield return new WaitForSeconds(2f);
        catrun2.SetActive(false);
        fireflies2.SetActive(false);
        textToSpeak = "Lumora Rising cảm ơn bạn vì đã đồng hành:\n\nThái Quốc Sơn\n\nDương Thị Tuyết Trang";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        THOAI_ENDING.CrossFadeAlpha(1f, 3f, false);
        yield return new WaitForSeconds(3f);

        yield return new WaitForSeconds(0.1f);
        THOAI_ENDING.CrossFadeAlpha(0f, 2f, false);
        yield return new WaitForSeconds(2f);
        textToSpeak = "Chúng ta không thể cứu tất cả mọi thứ.\n\nNhưng chúng ta có thể chọn thứ mà trái tim mình muốn bảo vệ.";
        THOAI_ENDING.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        THOAI_ENDING.CrossFadeAlpha(1f, 3f, false);
        yield return new WaitForSeconds(3f);


        yield return new WaitForSeconds(0.1f);
        THOAI_ENDING.CrossFadeAlpha(0f, 2f, false);
        yield return new WaitForSeconds(2f);
        nelio.SetActive(true);
        yield return new WaitForSeconds(3f);
    }

}