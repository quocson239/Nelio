using UnityEngine;
using TMPro;
using System.Collections;
public class Dialog : MonoBehaviour
{
    [SerializeField] GameObject nextDialogBox;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public bool isStop;
    public int index;
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialog();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isStop)
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialog()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            index++;
            gameObject.SetActive(false);
            if (nextDialogBox != null)
            {
                nextDialogBox.SetActive(true);
            }
        }
    }
}
