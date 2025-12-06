using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public bool isPaused = true;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    [SerializeField] AudioSource music;
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayNew()
    {
        music.Stop();
        SceneManager.LoadScene("S1");

    }
    public void QuitGame()
    {
        Debug.Log("Quitting game..."); 
        Application.Quit();
    }
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; 
    }
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; 
    }
}
