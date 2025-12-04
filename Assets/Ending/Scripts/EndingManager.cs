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
        textToSpeak = "Cảm ơn bạn đã chơi game của tụi mình đến cuối cùng.";
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
        textToSpeak = "Mong là game mang đến cho bạn phút giây giải trí và những trải nghiệm thú vị.";
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
    }

}
