using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject overMenu; 
    public float fallThreshold = -10f; 
    public GameObject player; 
    void Start()
    {
        overMenu.SetActive(false);
    }

    void Update()
    {
        if (player.transform.position.y < fallThreshold)
        {
            ShowOverMenu();
        }
    }
    public void ShowOverMenu()
    {
        Time.timeScale = 0f;
        overMenu.SetActive(true);
        
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }


    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
