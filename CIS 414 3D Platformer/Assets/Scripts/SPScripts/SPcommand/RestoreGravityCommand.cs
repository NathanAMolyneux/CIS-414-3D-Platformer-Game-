using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreGravityCommand : IActionCommand
{
    private SpaceGravityController gravityController;

    public RestoreGravityCommand(SpaceGravityController controller)
    {
        gravityController = controller;
    }

    public void Execute()
    {
        if (gravityController != null)
        {
            gravityController.RestoreGravity();
            Debug.Log("Gravity restored by command.");
        }
    }
}