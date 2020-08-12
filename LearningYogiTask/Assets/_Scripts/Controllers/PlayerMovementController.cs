using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovementController : MonoBehaviour
{
    #region Private Variables

    [Header("Player's Movement Values")]
    // Reference to the Y-axis value to which Player will be jumped
    [SerializeField]
    private float _jumpValue;
    
    // Reference for speed value to be used for Player's jump
    [SerializeField]
    private float _speedValue;
    
    // Reference to the Player's Animator Controller to change Player's animation States
    private Animator _playerAnimatorController;

    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        // Set the Player's Animator Controller reference 
        _playerAnimatorController = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Condition to Detect If the User has touched the Screen
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            // If the User is touching the Screen, jump the Player
            StartCoroutine(MovePlayerOnYAxis());
            
            _playerAnimatorController.SetBool("isJumping", true);
            
            // Assign the touch to a local variable to be used later
            var touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Began)
            {
                
            }

            if (touch.phase == TouchPhase.Ended)
            {
                
            }
        }
    }

    /// <summary>
    /// Function which changes Jumping Bool on Player Animator
    /// </summary>
    public void StopJumpingAndBringPlayerBackToGround()
    {
        // Set the Bool as false and make the Player stop jumping
        _playerAnimatorController.SetBool("isJumping", false);
    }

    /// <summary>
    /// Function which moves the Player based on boolean
    /// </summary>
    private IEnumerator MovePlayerOnYAxis()
    {
        // Play the Jumping up Animation 
        var jumpingUpTween = transform.DOMoveY(transform.position.y + _jumpValue, 
            _speedValue);
        
        yield return jumpingUpTween.WaitForCompletion();
        
        // Play the Jumping down Animation, which will play after Jumping up
        transform.DOMoveY(transform.position.y - _jumpValue, 
            _speedValue);
        
    }
}
