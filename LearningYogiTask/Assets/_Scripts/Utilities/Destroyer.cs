using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    #region Private Variables

    [Header("Time value")]
    
    // Reference for time after which the gameObject will be destroyed
    [SerializeField]
    private float _lifetimeValue;

    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        // Destroy this gameObject after _lifetimeValue time
        Destroy(gameObject, _lifetimeValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
