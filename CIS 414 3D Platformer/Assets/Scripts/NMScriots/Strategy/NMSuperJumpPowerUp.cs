using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NMSuperJumpPowerUp : MonoBehaviour
{
    [SerializeField] private float duration = 5f;
    [SerializeField] private float respawnTime = 20f;

    private Collider powerupCollider;
    private Renderer[] renderers;
    private bool isAvailable = true;

    private void Start()
    {
        powerupCollider = GetComponent<Collider>();
        renderers = GetComponentsInChildren<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isAvailable) return;

        NMFirstPersonController controller = other.GetComponent<NMFirstPersonController>();

        if (controller != null)
        {
            controller.ActivateSuperJump(duration);
            StartCoroutine(RespawnRoutine());
        }
    }

    private IEnumerator RespawnRoutine()
    {
        isAvailable = false;

        if (powerupCollider != null)
        {
            powerupCollider.enabled = false;
        }

        foreach (Renderer r in renderers)
        {
            r.enabled = false;
        }

        yield return new WaitForSeconds(respawnTime);

        if (powerupCollider != null)
        {
            powerupCollider.enabled = true;
        }

        foreach (Renderer r in renderers)
        {
            r.enabled = true;
        }

        isAvailable = true;
    }
}