using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    protected BallController ballController; // Encapsulation: Protected field for controlled access, representing the BallController
    protected bool isPowerupActive = false; // Encapsulation: Protected field for controlled access, representing the power-up's active state

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            SpeedPowerup speedPowerup = GetComponent<SpeedPowerup>(); // Abstraction: Getting the SpeedPowerup component from the GameObject

            if (speedPowerup != null)
            {
                speedPowerup.ApplyPowerupEffect(); // Abstraction: Calling the ApplyPowerupEffect method of the SpeedPowerup component
                GetComponent<MeshRenderer>().enabled = false; // Encapsulation: Accessing the MeshRenderer component to disable rendering
            }

            DoublePowerup doublePowerup = GetComponent<DoublePowerup>(); // Abstraction: Getting the DoublePowerup component from the GameObject

            if (doublePowerup != null)
            {
                doublePowerup.ApplyPowerupEffect(); // Abstraction: Calling the ApplyPowerupEffect method of the DoublePowerup component
                GetComponent<MeshRenderer>().enabled = false; // Encapsulation: Accessing the MeshRenderer component to disable rendering
            }

            GiantPowerup giantPowerup = GetComponent<GiantPowerup>(); // Abstraction: Getting the GiantPowerup component from the GameObject

            if (giantPowerup != null)
            {
                giantPowerup.ApplyPowerupEffect(); // Abstraction: Calling the ApplyPowerupEffect method of the GiantPowerup component
                GetComponent<MeshRenderer>().enabled = false; // Encapsulation: Accessing the MeshRenderer component to disable rendering
            }

            ShrinkPowerup shrinkPowerup = GetComponent<ShrinkPowerup>(); // Abstraction: Getting the ShrinkPowerup component from the GameObject

            if (shrinkPowerup != null)
            {
                shrinkPowerup.ApplyPowerupEffect(); // Abstraction: Calling the ApplyPowerupEffect method of the ShrinkPowerup component
                GetComponent<MeshRenderer>().enabled = false; // Encapsulation: Accessing the MeshRenderer component to disable rendering
            }
        }
    }

    public abstract void ApplyPowerupEffect(); // Abstraction: Abstract method to be implemented by derived classes to apply the power-up effect
}