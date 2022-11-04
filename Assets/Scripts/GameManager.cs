using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI currentScoreDisplay;
    public int highScore;
    public int currentScore;
    public GameObject gameOverText;
    public GameObject restartbutton;
    public bool gameRunning = true;
    
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
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

    public void UpdateScore(int points)
    {
        currentScore = currentScore + points;
        currentScoreDisplay.SetText(""+currentScore);
    }
    public void GameOver()
    {
        gameOverText.SetActive(true);
        restartbutton.SetActive(true);
        gameRunning = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
