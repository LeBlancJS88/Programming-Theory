using UnityEngine;

public class MainMenuOutOfBounds : MonoBehaviour
{
    private MainMenuGameController mainMenuGameController;

    private void Awake()
    {
        mainMenuGameController = FindObjectOfType<MainMenuGameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (mainMenuGameController != null)
            {
                mainMenuGameController.ResetBall();
            }
        }
    }
}