using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPowerup : Powerup
{
    [SerializeField] private float shrinkDividend = 2f; // shrink dividend to adjust the ball's scale
    public override void ApplyPowerupEffect()
    {
        ballController = FindObjectOfType<BallController>();

        if (ballController != null && !isPowerupActive)
        {
            // Apply the speed multiplier
            ballController.ApplyShrinkDividend(shrinkDividend);
            isPowerupActive = true;

            Debug.Log("Shrink powerup effect applied. Ball scale decreased by: " + (shrinkDividend - 1));
        }
        else
        {
            Debug.LogWarning("BallController script not found or powerup is already active. Powerup effect cannot be applied.");
        }
    }
}
