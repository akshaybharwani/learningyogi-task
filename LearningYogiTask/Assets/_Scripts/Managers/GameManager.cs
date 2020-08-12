using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Public Variables

    [Header("Audio References")]
    [SerializeField]
    private AudioSource _gameOverAudioSource;

    [SerializeField] 
    private AudioSource _backgroundAudioSource;
    
    #endregion
    
    #region Private Variables
    
    // Reference to store Score for the Game
    private int _score = 0;
    
    // Reference to store a UIManager instance
    private UIManager _UIManager;

    private bool _hasTheGameEnded;
    
    // Reference to the HighScore string in PlayerPrefs
    private string _highScorePlayerPrefKey = "HighScore";

    #endregion
    
    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        // Set the UIManager
        _UIManager = FindObjectOfType<UIManager>();
        
        // Set a default value to HighScore to PlayerPrefs that would be compared, if a key 
        // doesn't already exists
        
        if (!PlayerPrefs.HasKey(_highScorePlayerPrefKey))
            SetHighScoreInPlayerPref(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion
    
    #region Public Methods

    /// <summary>
    /// Ends the Game and shows the Game Over Panel
    /// </summary>
    public void EndGame()
    {
        if (!_hasTheGameEnded)
        {
            // Play the Game Over Audio Source
            _gameOverAudioSource.Play();
        
            // Stop the BG Audio Source
            _backgroundAudioSource.Stop();
        
            // Set the boolean of EndGame to true
            _hasTheGameEnded = true;

            StartCoroutine(waitSomeTimeAndThenShowGameOverPanel());
        }
    }

    /// <summary>
    /// Increases the Score and shows it InGame
    /// </summary>
    public void IncreaseScore()
    {
        // If the Game has not ended
        if (_hasTheGameEnded) return;
        // Increase the Score
        _score++;
        
        // Set the Score Text in UI
        _UIManager.SetScoreText(_score);
    }

    public void RestartGame()
    {
        // Load the first scene
        SceneManager.LoadScene(0);
    }

    #endregion
    
    #region Private Methods

    /// <summary>
    /// Compares the Current Score with High Score, replaces High Score
    /// if Current Score is higher and returns
    /// </summary>
    /// <returns></returns>
    private int _compareCurrentScoreWithHighScoreAndReturn()
    {
        var highScore = PlayerPrefs.GetInt(_highScorePlayerPrefKey);

        if (_score > highScore)
        {
            SetHighScoreInPlayerPref(_score);
            return _score;
        }

        return highScore;
    }

    private void SetHighScoreInPlayerPref(int scoreValue)
    {
        PlayerPrefs.SetInt(_highScorePlayerPrefKey, scoreValue);
    }

    private IEnumerator waitSomeTimeAndThenShowGameOverPanel()
    {
        yield return new WaitForSeconds(1f);

        _UIManager.ShowGameOverPanelWithScore(_score, 
            _compareCurrentScoreWithHighScoreAndReturn());

        _UIManager.FinalScoreText.text = _score.ToString();
    }

    #endregion
    
    
}
