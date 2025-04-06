using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenu; 

    void Start()
    {
        Time.timeScale = 0f; 
        startMenu.SetActive(true);
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
        Time.timeScale = 1f; 
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}