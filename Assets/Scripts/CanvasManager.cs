using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Il y a plus d'une instance de CanvasManager dans la scène !");
        }
    }

    [SerializeField] private GameObject _pausePanel;

    public void TogglePausePanel()
    {
        _pausePanel.SetActive(!_pausePanel.activeInHierarchy);
    }

    public void TogglePanel(GameObject panel)
    {
        panel.SetActive(!panel.activeInHierarchy);
    }
}
