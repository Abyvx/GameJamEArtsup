using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
  
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool isPaused = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(instance.gameObject);
        }
        else
        {
            Debug.LogError("Il y a plus d'une instance de Clean.GameManager dans la scène !");
            // Destroy(this.gameObject);
        }
    } 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {  
            CanvasManager.instance.TogglePausePanel();

            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void PlayerVictory()
    {

    }

    public void PlayerDefeat()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;

        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;

        isPaused = false;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        ResumeGame();
    }
}
