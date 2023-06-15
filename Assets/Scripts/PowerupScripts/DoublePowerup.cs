using UnityEngine;

public class DoublePowerup : Powerup // Inheritance: he DoublePowerup class inherits from the Powerup base class.
{
    public override void ApplyPowerupEffect()
    {
        ballController = FindObjectOfType<BallController>(); // Encapsulation: Assigning the BallController found in the scene to the protected field

        if (ballController != null && !isPowerupActive)
        {
            GameObject duplicateBall = Instantiate(ballController.gameObject); // Abstraction: Creating a duplicate ball object

            duplicateBall.tag = "DuplicateBall"; // Encapsulation: Modifying the tag of the duplicate ball object

            BallController duplicateBallController = duplicateBall.GetComponent<BallController>(); // Abstraction: Getting the BallController component of the duplicate ball

            if (duplicateBallController != null)
            {
                duplicateBallController.Go(); // Abstraction: Starting the movement of the duplicate ball
                duplicateBallController.ApplySpeedMultiplier(1.0f); // Abstraction: Applying a speed multiplier to the duplicate ball
            }

            isPowerupActive = true; // Encapsulation: Updating the power-up's active state
            Destroy(duplicateBall, 10f); // Abstraction: Destroying the duplicate ball after a certain time
        }
    }
}
