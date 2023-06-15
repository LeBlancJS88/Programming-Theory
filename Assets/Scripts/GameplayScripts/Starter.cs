using UnityEngine;

public class Starter : MonoBehaviour
{
    private GameController gameController;
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
        gameController = FindObjectOfType<GameController>();
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
        gameController.StartGame();
    }
}