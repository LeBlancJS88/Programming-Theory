using UnityEngine;

public class SpeedPowerup : Powerup
{
    [SerializeField] private float speedMultiplier = 2f; // Speed multiplier to adjust the ball's speed

    public override void ApplyPowerupEffect()
    {
        ballController = FindObjectOfType<BallController>();

        if (ballController != null && !isPowerupActive)
        {
            // Apply the speed multiplier
            ballController.ApplySpeedMultiplier(speedMultiplier);
            isPowerupActive = true;

            Debug.Log("Speed powerup effect applied. Ball speed increased by: " + (speedMultiplier - 1));
        }
        else
        {
            Debug.LogWarning("BallController script not found or powerup is already active. Powerup effect cannot be applied.");
        }
    }
}