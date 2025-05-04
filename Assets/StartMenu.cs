using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenu; 
    public GameObject infoHUD;
    public static bool IsRestarting = false;

    void Start()
    {
        if (IsRestarting)
        {
            IsRestarting = false;
            StartGame();
        }
        else
        {
            Time.timeScale = 0f;
            startMenu.SetActive(true);
            infoHUD.SetActive(false);
        }
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
        infoHUD.SetActive(true);
        Time.timeScale = 1f; 
        PauseMenu.isPaused = false;
        FindFirstObjectByType<PlayerMovement>().canControl = true;
    }
    
    public void SkipTutorial(){
        IsRestarting = true;
        SceneManager.LoadScene("LevelOne");
    }  
    
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}