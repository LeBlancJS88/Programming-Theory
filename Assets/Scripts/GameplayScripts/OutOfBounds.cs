using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private GameController gameController;  // Abstraction - gameController field represents the GameController script, abstracting the details of its implementation

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();  // Abstraction - Finding the instance of the GameController script in the scene, abstracting the details of its implementation
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))  // Abstraction - Checking if the collided object has the "Ball" tag, abstracting the details of the object's implementation
        {
            if (gameController != null)  // Encapsulation - Checking if the gameController variable is not null before accessing it
            {
                gameController.ResetBall();  // Abstraction - Calling the ResetBall() method of the gameController, abstracting the details of its implementation
            }
        }
    }
}