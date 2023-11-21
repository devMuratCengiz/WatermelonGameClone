using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Score scoreSc;
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreDisplayText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplayText.text = "Your Score: " + scoreSc.score;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
