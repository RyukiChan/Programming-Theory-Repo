using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI currentScoreDisplay;
    //public int highScore;
    public int currentScore;
    public GameObject gameOverText;
    public GameObject restartbutton;
    public bool gameRunning = true;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI highScoreName;
    public GameObject newHighScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        //PersistantData.Instance = null;
        playerName.text = PersistantData.Instance.playerName;
        PersistantData.Instance.LoadHighScore();
        highScore.SetText("" + PersistantData.Instance.highScore);
        highScoreName.SetText("" + PersistantData.Instance.highUserName);
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

        if (currentScore > PersistantData.Instance.highScore)
        {
            PersistantData.Instance.SaveHighScore(currentScore);
            newHighScoreText.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
