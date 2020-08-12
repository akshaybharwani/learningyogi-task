using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    #region Private Variables

    [Header("Background Movement Values")]
    
    // Reference for speed value to be used
    [SerializeField]
    private float _speedValue;
    
    [Header("Background Position Values")]
    
    [SerializeField]
    private float _startPosition;
    
    [SerializeField]
    private float _endPosition;

    #endregion
    
    #region Unity Methods

    // Update is called once per frame
    void Update()
    {
        // Move the background to the left
        transform.Translate(Vector2.left * _speedValue * Time.deltaTime);

        // If the Background is beyond the EndPosition
        if (!(transform.position.x <= _endPosition)) return;
        
        // Change the Position of the Background and bring it to the Start position again
        var position = new Vector2(_startPosition, transform.position.y);
        transform.position = position;
    }

    #endregion

}