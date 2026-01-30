using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchSystem : MonoBehaviour
{
    public void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true; 
    }

    public void Playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResetPreviousScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); 
    }
}
