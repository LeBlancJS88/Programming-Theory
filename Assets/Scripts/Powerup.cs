using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    protected BallController ballController;
    protected bool isPowerupActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            SpeedPowerup speedPowerup = GetComponent<SpeedPowerup>();

            if (speedPowerup != null)
            {
                speedPowerup.ApplyPowerupEffect();
                GetComponent<MeshRenderer>().enabled = false;
            }

            DoublePowerup doublePowerup = GetComponent<DoublePowerup>();

            if (doublePowerup != null)
            {
                doublePowerup.ApplyPowerupEffect();
                GetComponent<MeshRenderer>().enabled = false;
            }

            GiantPowerup giantPowerup = GetComponent<GiantPowerup>();

            if (giantPowerup != null)
            {
                giantPowerup.ApplyPowerupEffect();
                GetComponent<MeshRenderer>().enabled = false;
            }

            ShrinkPowerup shrinkPowerup = GetComponent<ShrinkPowerup>();

            if (shrinkPowerup != null)
            {
                shrinkPowerup.ApplyPowerupEffect();
                GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    public abstract void ApplyPowerupEffect();
}
