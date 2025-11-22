using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;                   // Current score
    public TextMeshProUGUI scoreText;       // Drag your TMP text here

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        Debug.Log("AddScore called!");
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
}