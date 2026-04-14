using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelPuzzleProgress : MonoBehaviour
{
    public static TunnelPuzzleProgress Instance;

    [SerializeField] private int requiredCorrectNodes = 2;
    [SerializeField] private SpaceGravityController gravityController;

    private int correctNodesActivated = 0;
    public bool PuzzleCompleted { get; private set; } = false;

    private IActionCommand unlockCommand;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        unlockCommand = new RestoreGravityCommand(gravityController);
    }

    public void RegisterCorrectNode()
    {
        if (PuzzleCompleted) return;

        correctNodesActivated++;

        Debug.Log("Correct nodes activated: " + correctNodesActivated);

        if (correctNodesActivated >= requiredCorrectNodes)
        {
            PuzzleCompleted = true;
            Debug.Log("Puzzle complete!");

            if (unlockCommand != null)
            {
                unlockCommand.Execute();
            }
        }
    }
}