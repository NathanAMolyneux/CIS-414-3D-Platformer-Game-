using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NMOutlinePowerUp : MonoBehaviour
{
    [SerializeField] private float duration = 5f;
    [SerializeField] private float respawnTime = 25f;

    private Collider powerupCollider;
    private Renderer[] renderers;
    private bool isAvailable = true;

    private void Start()
    {
        powerupCollider = GetComponent<Collider>();
        renderers = GetComponentsInChildren<Renderer>(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isAvailable) return;

        NMFirstPersonController player = other.GetComponent<NMFirstPersonController>();

        if (player != null)
        {
            if (NMOutlineVisionManager.Instance != null)
            {
                NMOutlineVisionManager.Instance.ActivateOutlineVision(duration);
            }

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