using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    #region Private Variables

    // Reference to store a GameManager instance
    private GameManager _gameManagerInstance;

    #endregion

    private void Start()
    {
        // Set the GameManager
        _gameManagerInstance = FindObjectOfType<GameManager>();
    }
     
    /// <summary>
    /// Function which detects if another Collider has come in contact with this gameObject
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Create a enemy variable which checks if the Collider has a EnemyController 
        // component attached
        var enemy = other.GetComponent<EnemyController>();
        
        // If the component exists
        if (enemy)
        {
            // Increase the Score
            _gameManagerInstance.IncreaseScore();
        }
    }
}
