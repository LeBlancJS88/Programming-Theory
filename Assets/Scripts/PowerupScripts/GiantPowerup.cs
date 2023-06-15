using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantPowerup : Powerup // Inheritance: the GiantPowerup class inherits from the Powerup base class.
{
    [SerializeField] private float giantMultiplier = 2f; // Encapsulation: Serialized field for controlled access, representing the giant multiplier

    public override void ApplyPowerupEffect()
    {
        ballController = FindObjectOfType<BallController>(); // Encapsulation: Assigning the BallController found in the scene to the protected field

        if (ballController != null && !isPowerupActive)
        {
            // Apply the size multiplier
            ballController.ApplyGiantMultiplier(giantMultiplier); // Abstraction: Calling the ApplyGiantMultiplier method of the BallController
            isPowerupActive = true; // Encapsulation: Updating the power-up's active state

            Debug.Log("Giant powerup effect applied. Ball scale increased by: " + (giantMultiplier - 1));
        }
        else
        {
            Debug.LogWarning("BallController script not found or powerup is already active. Powerup effect cannot be applied.");
        }
    }
}
