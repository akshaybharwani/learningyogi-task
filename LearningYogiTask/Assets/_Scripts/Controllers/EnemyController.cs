using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Private Variables

    [Header("Enemy Movement Values")]
    
    // Reference for speed value to be used for Enemy's movement towards Player
    [SerializeField]
    private float _speedValue;

    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Continuously move the Enemy towards Player to the left direction
        transform.Translate(Vector2.left * _speedValue * Time.deltaTime);
    }

    /// <summary>
    /// Function which detects if another Collider has come in contact with this gameObject
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Create a player variable which checks if the Collider has a PlayerMovementController 
        // component attached
        var player = other.GetComponent<PlayerMovementController>();
        
        // If the component exists
        if (player)
        {
            // Kill the player
            player.KillPlayer();
            
            // Kill this Enemy gameObject on Colliding
            Destroy(gameObject);
        }
    }
}
