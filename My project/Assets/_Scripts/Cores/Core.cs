using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    #region Core Components
    public Movement Movement { get; private set; }
    #endregion

    #region Unity Callback Methods
    /// <summary>
    /// Called on instantiation.
    /// </summary>
    private void Awake()
    {
        Movement = GetComponentInChildren<Movement>();

        if(!Movement)
        {
            Debug.LogError("Missing core component.");
        }
    }

    /// <summary>
    /// Called once every frame.
    /// </summary>
    public void LogicUpdate()
    {
        Movement.LogicUpdate();
    }
    #endregion
}
