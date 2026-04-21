using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NMOutlineVisionManager : MonoBehaviour
{
    public static NMOutlineVisionManager Instance { get; private set; }

    private readonly List<NMBlockOutline> registeredBlocks = new List<NMBlockOutline>();
    private Coroutine outlineRoutine;
    private bool outlinesActive = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void Register(NMBlockOutline block)
    {
        if (block == null || registeredBlocks.Contains(block)) return;

        registeredBlocks.Add(block);
        block.SetOutline(outlinesActive);
    }

    public void Unregister(NMBlockOutline block)
    {
        if (block == null) return;

        registeredBlocks.Remove(block);
    }

    public void ActivateOutlineVision(float duration)
    {
        if (outlineRoutine != null)
        {
            StopCoroutine(outlineRoutine);
        }

        outlineRoutine = StartCoroutine(OutlineRoutine(duration));
    }

    private IEnumerator OutlineRoutine(float duration)
    {
        SetAllOutlines(true);

        yield return new WaitForSeconds(duration);

        SetAllOutlines(false);
        outlineRoutine = null;
    }

    private void SetAllOutlines(bool state)
    {
        outlinesActive = state;

        for (int i = registeredBlocks.Count - 1; i >= 0; i--)
        {
            if (registeredBlocks[i] == null)
            {
                registeredBlocks.RemoveAt(i);
                continue;
            }

            registeredBlocks[i].SetOutline(state);
        }
    }
}