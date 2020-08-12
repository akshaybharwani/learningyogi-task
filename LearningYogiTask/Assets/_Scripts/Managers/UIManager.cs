using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Private Variables

    [Header("Game UI Reference")]
    // Reference to the Score Text
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [Header("Game Over UI Reference")]
    [SerializeField] 
    private GameObject _gameOverPanel;

    public TextMeshProUGUI FinalScoreText;

    [SerializeField] 
    private TextMeshProUGUI _highScoreText;
    
    #endregion

    /// <summary>
    /// Which increases the Score Value by 1 every time it is called
    /// </summary>
    public void SetScoreText(int scoreValue)
    {
        _scoreText.text = scoreValue.ToString();
    }
    
    /// <summary>
    /// Which increases the Score Value by 1 every time it is called
    /// </summary>
    public void ShowGameOverPanelWithScore(int currentScoreValue, int highScoreValue)
    {
        // Show the Game Over Panel
        _gameOverPanel.SetActive(true);
        
        // Set the Scores
        _scoreText.text = currentScoreValue.ToString();
        _highScoreText.text = highScoreValue.ToString();
    }
}
