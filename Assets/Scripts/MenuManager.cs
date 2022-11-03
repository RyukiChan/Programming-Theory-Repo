using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField playerName;
    public TextMeshProUGUI invalidEntry;

    //Quit Application
    public void QuitApp()
    {
        Application.Quit();
    }

    //Start game if vaild Player name
    public void StartButton()
    {
        if (string.IsNullOrWhiteSpace(playerName.text))
        {
            invalidEntry.gameObject.SetActive(true);
            
        }
        else
        {
            PersistantData.Instance.playerName = playerName.text;
            SceneManager.LoadScene(1);
        }
    }
}
