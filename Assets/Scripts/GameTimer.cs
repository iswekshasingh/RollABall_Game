using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 60f;
    public TMP_Text timerText;
    public TMP_Text gameOverText;
    public GameObject gameOverPanel;
    public PlayerController player;

    private bool timerRunning = true;

    void Start()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (!timerRunning) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Ceil(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            timerRunning = false;
            timerText.text = "Time: 0";

            gameOverPanel.SetActive(true);
            gameOverText.text = "GAME OVER\n\nFinal Score: " + player.count;

            Time.timeScale = 0f;
        }
    }
}