using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private GameController gameController;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (gameController != null)
            {
                gameController.ResetBall();
            }
        }
    }
}