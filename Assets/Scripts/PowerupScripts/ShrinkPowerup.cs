using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPowerup : Powerup // Inheritance: ShrinkPowerup inherits from the base class Powerup
{
    [SerializeField] private float shrinkDividend = 2f; // Encapsulation: Private field with serialized attribute for controlled access, representing the shrink dividend

    public override void ApplyPowerupEffect() // Abstraction: Override method to apply the power-up effect
    {
        ballController = FindObjectOfType<BallController>(); // Abstraction: Finding the BallController component

        if (ballController != null && !isPowerupActive) // Abstraction: Checking if BallController exists and power-up is not already active
        {
            // Apply the shrink dividend
            ballController.ApplyShrinkDividend(shrinkDividend);
            isPowerupActive = true;

            Debug.Log("Shrink power-up effect applied. Ball scale decreased by: " + (shrinkDividend - 1)); // Abstraction: Logging the effect of the shrink power-up
        }
        else
        {
            Debug.LogWarning("BallController script not found or power-up is already active. Power-up effect cannot be applied."); // Abstraction: Logging a warning if BallController is not found or power-up is already active
        }
    }
}