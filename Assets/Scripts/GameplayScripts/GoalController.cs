using UnityEngine;
using UnityEngine.Events;

public class GoalController : MonoBehaviour
{
    public UnityEvent<GameObject> onBallEnter = new UnityEvent<GameObject>();
    public UnityEvent<GameObject> onDuplicateBallEnter = new UnityEvent<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            onBallEnter.Invoke(other.gameObject);
        }

        else if (other.CompareTag("DuplicateBall"))
        {
            onDuplicateBallEnter.Invoke(other.gameObject);
        }
    }
}
