using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject infoHUD;
    public static bool isPaused;
    public GameObject[] blockingMenus;

    void Start()
    {
        pauseMenu.SetActive(false);
        infoHUD.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!AnyMenuOpen())
            {
                if (isPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        infoHUD.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        
        FindFirstObjectByType<PlayerMovement>().canControl = false;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        infoHUD.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
        FindFirstObjectByType<PlayerMovement>().canControl = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        isPaused = false;

    }

    public void TutorialLevel(){
        SceneManager.LoadScene("IntroLevel");
    }
    
    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
    
    bool AnyMenuOpen()
    {
        foreach (GameObject menu in blockingMenus)
        {
            if (menu.activeSelf) return true;
        }
        return false;
    }
}
