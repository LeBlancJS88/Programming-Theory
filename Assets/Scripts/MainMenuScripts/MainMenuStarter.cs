using UnityEngine;

public class MainMenuStarter : MonoBehaviour
{
    private MainMenuGameController mainMenuGameController;
    private Animator animator;

    [SerializeField]
    private AudioClip countdownSoundEffect;

    private AudioSource audioSource;

    private void Start()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        mainMenuGameController = FindObjectOfType<MainMenuGameController>();
        animator = GetComponent<Animator>();
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void StartCountdown()
    {
        if (countdownSoundEffect != null && audioSource != null)
        {
            audioSource.PlayOneShot(countdownSoundEffect);
        }

        animator.SetTrigger("StartCountdown");
    }

    public void StartGame()
    {
        mainMenuGameController.StartGame();
    }
}