using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject overMenu; 
    public float fallThreshold = -10f; 
    public GameObject player;
    public GameObject infoHUD;
    
    void Start()
    {
        overMenu.SetActive(false);
    }

    void Update()
    {
        if (player.transform.position.y < fallThreshold)
        {
            infoHUD.SetActive(false);
            ShowOverMenu();
        }
    }
    public void ShowOverMenu()
    {
        Time.timeScale = 0f;
        overMenu.SetActive(true);
        FindFirstObjectByType<PlayerMovement>().canControl = false;

        
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
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
}
