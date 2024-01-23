using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // public bool MenuBool = true;
    private GameManager instance;

    public string targetTag = "DontDestroy";
    void Awake()  //setup dontDestroy
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance.gameObject);
        }
        else if(instance != this)
        {
            Destroy(instance.gameObject);
        }
    } 
    void Start()
    {
    // GameObject[] objectsWithSameTag = GameObject.FindGameObjectsWithTag(targetTag);  //lors du changement de scene menu -> game le dont destroy est dupliqué..
    //     if (objectsWithSameTag.Length > 1)
    //     {
    //         {
    //             Destroy(gameObject);
    //         }
    //     }   
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){  //echap pour retourné au menu ()
        MenuSwitchOn();
        }
    }

    public void MenuSwitchOn()
    {
        // if (MenuBool == false) {
        // MenuBool = true;
        Debug.Log("Menu");
        SceneManager.LoadScene("Menu");
        // }
    }
    public void MenuSwitchOff()
    {
        // if (MenuBool == true) {
        // MenuBool = false;
        Debug.Log("Game");
        SceneManager.LoadScene("Gameplay");
        // }
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
