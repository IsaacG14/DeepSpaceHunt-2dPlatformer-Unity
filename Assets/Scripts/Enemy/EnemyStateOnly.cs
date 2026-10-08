using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simplified enemy script that only sets the enemy state
/// </summary>
public class EnemyStateOnly : EnemyBase
{
    /// <summary>
    /// Description:
    /// Override Setup from EnemyBase
    /// Input: none
    /// Return: void
    /// </summary>
    protected override void Setup()
    {
        base.Setup();
    }

    /// <summary>
    /// Description:
    /// Updates the enemy state logic (to be filled in by specific behavior)
    /// Input: none
    /// Return: void
    /// </summary>
    protected override void Update()
    {
        SetStateInformation();
    }

    /// <summary>
    /// Description:
    /// Sets the state of this enemy — replace logic with custom behavior
    /// Input: none
    /// Return: void
    /// </summary>
    protected virtual void SetStateInformation()
    {
        // Default to idle; override or extend this logic in a subclass
        enemyState = EnemyState.Idle;
    }
}

