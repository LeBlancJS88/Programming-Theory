using UnityEngine;
using UnityEngine.Events;

public class GoalController : MonoBehaviour
{
    public UnityEvent<GameObject> onBallEnter = new UnityEvent<GameObject>();  // Abstraction - onBallEnter event represents an event that is triggered when a ball enters the goal, abstracting the details of event implementation

    public UnityEvent<GameObject> onDuplicateBallEnter = new UnityEvent<GameObject>();  // Abstraction - onDuplicateBallEnter event represents an event that is triggered when a duplicate ball enters the goal, abstracting the details of event implementation

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))  // Abstraction - Checking if the collided object has the "Ball" tag, abstracting the details of the object's implementation
        {
            onBallEnter.Invoke(other.gameObject);  // Abstraction - Invoking the onBallEnter event with the collided ball object, abstracting the details of event invocation
        }
        else if (other.CompareTag("DuplicateBall"))  // Abstraction - Checking if the collided object has the "DuplicateBall" tag, abstracting the details of the object's implementation
        {
            onDuplicateBallEnter.Invoke(other.gameObject);  // Abstraction - Invoking the onDuplicateBallEnter event with the collided duplicate ball object, abstracting the details of event invocation
        }
    }
}