using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject winMenu; 
    public GameObject infoHUD;

    void Start()
    {
        winMenu.SetActive(false);
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered by: " + other.name);
        
        if (other.CompareTag("Player"))
        {
            ShowWinMenu(); 
        }
    }
    public void ShowWinMenu()
    {
        infoHUD.SetActive(false);
        Time.timeScale = 0f;
        winMenu.SetActive(true);
        FindFirstObjectByType<PlayerMovement>().canControl = false;

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
