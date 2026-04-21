using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMBlockOutline : MonoBehaviour
{
    [SerializeField] private GameObject outlineVisual;

    private void Awake()
    {
        if (outlineVisual != null)
        {
            outlineVisual.SetActive(false);
        }
    }

    private void Start()
    {
        if (NMOutlineVisionManager.Instance != null)
        {
            NMOutlineVisionManager.Instance.Register(this);
        }
    }

    private void OnDestroy()
    {
        if (NMOutlineVisionManager.Instance != null)
        {
            NMOutlineVisionManager.Instance.Unregister(this);
        }
    }

    public void SetOutline(bool state)
    {
        if (outlineVisual != null)
        {
            outlineVisual.SetActive(state);
        }
    }
}