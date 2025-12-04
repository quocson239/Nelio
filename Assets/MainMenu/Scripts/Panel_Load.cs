using UnityEngine;
using UnityEngine.SceneManagement;

public class Panel_Load : MonoBehaviour
{
    public GameObject PanelLoad_Panel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggelActive()
    {
        if (PanelLoad_Panel != null)
        {
            PanelLoad_Panel.SetActive(!PanelLoad_Panel.activeSelf);
        }
    }
    public void LoadScene1()
    {
        SceneManager.LoadScene("S1");
    }
    public void LoadScene2()
    {
        SceneManager.LoadScene("S2");
    }
    public void LoadScene3()
    {
        SceneManager.LoadScene("S3");
    }
    public void LoadScene4()
    {
        SceneManager.LoadScene("S4");
    }
    public void LoadScene5()
    {
        SceneManager.LoadScene("S5");
    }
    public void LoadScene6()
    {
        SceneManager.LoadScene("S6Darker");
    }
    public void LoadScene7()
    {
        SceneManager.LoadScene("S7");
    }
    public void LoadScene8()
    {
        SceneManager.LoadScene("S8Losmind");
    }
    public void LoadScene9()
    {
        SceneManager.LoadScene("S9Undead");
    }
    public void LoadScene10()
    {
        SceneManager.LoadScene("S10");
    }
}
