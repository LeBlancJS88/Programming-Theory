using UnityEngine;

public class DoublePowerup : Powerup
{
    public override void ApplyPowerupEffect()
    {
        ballController = FindObjectOfType<BallController>();

        if (ballController != null && !isPowerupActive)
        {
            GameObject duplicateBall = Instantiate(ballController.gameObject);
            duplicateBall.tag = "DuplicateBall"; // Set the tag for the duplicate ball object

            BallController duplicateBallController = duplicateBall.GetComponent<BallController>();

            if (duplicateBallController != null)
            {
                duplicateBallController.Go(); // Start the movement of the duplicate ball
                duplicateBallController.ApplySpeedMultiplier(1.0f); // Reset any speed multipliers on the duplicate ball
            }

            isPowerupActive = true;
            Destroy(duplicateBall, 10f);
        }
    }
}