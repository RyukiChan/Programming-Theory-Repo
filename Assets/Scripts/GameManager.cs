using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    
    // Start is called before the first frame update
    void Start()
    {
        playerName.text = PersistantData.Instance.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
