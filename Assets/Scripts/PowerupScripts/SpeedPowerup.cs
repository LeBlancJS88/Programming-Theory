using UnityEngine;

public class SpeedPowerup : Powerup // Inheritance: SpeedPowerup inherits from the base class Powerup
{
    [SerializeField] private float speedMultiplier = 2f; // Encapsulation: Private field with serialized attribute for controlled access, representing the speed multiplier

    public override void ApplyPowerupEffect() // Abstraction: Override method to apply the power-up effect
    {
        ballController = FindObjectOfType<BallController>(); // Abstraction: Finding the BallController component

        if (ballController != null && !isPowerupActive) // Abstraction: Checking if BallController exists and power-up is not already active
        {
            // Apply the speed multiplier
            ballController.ApplySpeedMultiplier(speedMultiplier);
            isPowerupActive = true;

            Debug.Log("Speed power-up effect applied. Ball speed increased by: " + (speedMultiplier - 1)); // Abstraction: Logging the effect of the speed power-up
        }
        else
        {
            Debug.LogWarning("BallController script not found or power-up is already active. Power-up effect cannot be applied."); // Abstraction: Logging a warning if BallController is not found or power-up is already active
        }
    }
}