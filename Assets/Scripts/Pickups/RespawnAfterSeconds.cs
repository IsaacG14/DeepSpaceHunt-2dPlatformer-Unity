using System.Collections;
using UnityEngine;

public class RespawnAfterSeconds : MonoBehaviour
{
    [Header("Respawn Settings")]
    public float respawnDelay = 3f;

    public void TriggerDespawn()
    {
        StartCoroutine(DespawnAndRespawn());
    }

    private IEnumerator DespawnAndRespawn()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        gameObject.SetActive(true);
    }
}
