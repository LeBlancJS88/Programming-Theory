using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantPowerup : Powerup
{
    [SerializeField] private float giantMultiplier = 2f; // giant multiplier to adjust the ball's scale
    public override void ApplyPowerupEffect()
    {
        ballController = FindObjectOfType<BallController>();

        if (ballController != null && !isPowerupActive)
        {
            // Apply the size multiplier
            ballController.ApplyGiantMultiplier(giantMultiplier);
            isPowerupActive = true;

            Debug.Log("Giant powerup effect applied. Ball scale increased by: " + (giantMultiplier - 1));
        }
        else
        {
            Debug.LogWarning("BallController script not found or powerup is already active. Powerup effect cannot be applied.");
        }
    }
}
