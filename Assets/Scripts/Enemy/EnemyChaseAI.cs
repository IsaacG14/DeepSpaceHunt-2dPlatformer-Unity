using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Makes the enemy chase the player when within a certain distance.
/// Changes state via EnemyBase and handles flipping.
/// </summary>
public class EnemyChaseAI : MonoBehaviour
{
    [Header("References")]
    public Transform player;                      // Player's transform
    public EnemyBase enemyComponent;              // Link to EnemyBase
    public SpriteRenderer spriteRenderer;         // For flipping sprite

    [Header("Chase Settings")]
    public float chaseDistance = 5f;              // Distance to begin chasing
    public float moveSpeed = 3f;                  // Speed of the enemy

    private void Update()
    {
        if (player == null || enemyComponent == null)
            return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= chaseDistance)
        {
            ChasePlayer();
            enemyComponent.enemyState = EnemyBase.EnemyState.Walking;
        }
        else
        {
            enemyComponent.enemyState = EnemyBase.EnemyState.Idle;
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        // Move the enemy
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);

        // Flip the sprite based on horizontal movement
        if (direction.x != 0)
        {
            spriteRenderer.flipX = direction.x < 0;
        }
    }
}


public class ChaseAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
