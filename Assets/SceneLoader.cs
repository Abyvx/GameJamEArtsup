using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void MenuSwitchOn()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene("Menu");
    }
    public void MenuSwitchOff()
    {
        Debug.Log("Game");
        SceneManager.LoadScene("Gameplay");
    }
    public void Credits()
    {
        Debug.Log("Credits");
        SceneManager.LoadScene("Credits");
    }
    public void CloseGame()
    {
        Application.Quit();
    }
void Update()
{
    if(Input.GetKeyDown(KeyCode.Escape)){  //echap pour retourné au menu ()
    MenuSwitchOn();
    }
}
}

