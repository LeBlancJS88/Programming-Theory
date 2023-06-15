using UnityEngine;

public class Starter : MonoBehaviour
{
    private GameController gameController; // Encapsulation: Private field encapsulated within the class
    private Animator animator; // Encapsulation: Private field encapsulated within the class

    [SerializeField]
    private AudioClip countdownSoundEffect; // Encapsulation: Private field encapsulated within the class

    private AudioSource audioSource; // Encapsulation: Private field encapsulated within the class

    private void Start()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        gameController = FindObjectOfType<GameController>(); // Encapsulation: Accessing a private field through a method
        animator = GetComponent<Animator>(); // Encapsulation: Accessing a private field through a method
        audioSource = gameObject.GetComponent<AudioSource>(); // Encapsulation: Accessing a private field through a method
    }

    public void StartCountdown()
    {
        if (countdownSoundEffect != null && audioSource != null)
        {
            audioSource.PlayOneShot(countdownSoundEffect); // Encapsulation: Invoking a method on a private field
        }

        animator.SetTrigger("StartCountdown"); // Encapsulation: Invoking a method on a private field
    }

    public void StartGame()
    {
        gameController.StartGame(); // Encapsulation: Invoking a method on a private field
    }
}