using System.Collections;
using UnityEngine;

public class MovingPlatformTrigger : MonoBehaviour
{
    public enum MoveDirection { Vertical, Horizontal }

    [Header("Movement Settings")]
    public MoveDirection moveDirection = MoveDirection.Vertical;
    public float moveDistance = 3f;
    public float moveSpeed = 2f;
    public float delayBeforeReturning = 2f;

    private Vector3 startPos;
    private Vector3 targetPos;
    private Coroutine moveCoroutine;
    private int playersOnPlatform = 0;

    private void Start()
    {
        startPos = transform.position;
        targetPos = startPos + ((moveDirection == MoveDirection.Vertical) ? Vector3.up : Vector3.right) * moveDistance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playersOnPlatform++;

            if (moveCoroutine != null)
                StopCoroutine(moveCoroutine);

            moveCoroutine = StartCoroutine(MovePlatform(targetPos));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playersOnPlatform--;

            if (playersOnPlatform <= 0)
            {
                moveCoroutine = StartCoroutine(DelayedMoveDown());
            }
        }
    }

    private IEnumerator DelayedMoveDown()
    {
        yield return new WaitForSeconds(delayBeforeReturning);
        moveCoroutine = StartCoroutine(MovePlatform(startPos));
    }

    private IEnumerator MovePlatform(Vector3 destination)
    {
        while (Vector3.Distance(transform.position, destination) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = destination;
    }
}
