using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    #region Private Variables

    // Reference to multiple Positions in the Scene where an Enemy can be instantiated
    [Header("Enemy Spawner Points")]
    [SerializeField]
    private Transform[] _enemySpawnerPoints;

    // Reference for Enemy Prefab
    [Header("Enemy Controller Prefab")]
    [SerializeField]
    private EnemyController _enemyControllerPrefab;
    
    [Header("Enemy Spawner Time Values")]
    [SerializeField]
    private float _startTimeBetweenSpawnValue;
    
    // Reference for time value which will keep decreasing the _startTimeBetweenSpawn
    // to spawn enemies quicker and increase difficulty
    [SerializeField]
    private float _timeDecreaseValue;
    
    // Reference to have a limit to which the _startTimeBetweenSpawnValue can be decreased
    [SerializeField]
    private float _minStartTimeBetweenSpawnValue;
    
    // Reference for time which will be used between spawns
    private float _timeSinceLastSpawnValue;

    #endregion
    
    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check every frame if the Time since last Spawn has reached 0 or not
        if (_timeSinceLastSpawnValue <= 0)
        {
            // If it has, Instantiate an Enemy
            InstantiateAnEnemyInTheGame();
            
            // Reset the Time Between Spawn
            _timeSinceLastSpawnValue = _startTimeBetweenSpawnValue;

            if (_startTimeBetweenSpawnValue > _minStartTimeBetweenSpawnValue)
            {
                // After Every Spawn decrease the _startTimeBetweenSpawnValue to increase Enemy Spawn
                _startTimeBetweenSpawnValue -= _timeDecreaseValue;
            }
        }
        // If the Time since last Spawn hasn't reached 0
        else
        {
            // Keep reducing the time
            _timeSinceLastSpawnValue -= Time.deltaTime;
        }
    }

    #endregion
    
    #region Public Methods

    

    #endregion
    
    #region Private Methods

    private void InstantiateAnEnemyInTheGame()
    {
        // Get a random Enemy Spawner Point
        var randomEnemySpawnerPosition = _enemySpawnerPoints[Random.Range(0, _enemySpawnerPoints.Length)];
        
        Instantiate(_enemyControllerPrefab, randomEnemySpawnerPosition);
    }

    #endregion
}
