using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreTextLeft; // Encapsulation: Private field with serialized attribute for controlled access

    [SerializeField]
    private TMP_Text scoreTextLeft2; // Encapsulation: Private field with serialized attribute for controlled access

    [SerializeField]
    private TMP_Text scoreTextRight; // Encapsulation: Private field with serialized attribute for controlled access

    [SerializeField]
    private TMP_Text scoreTextRight2; // Encapsulation: Private field with serialized attribute for controlled access

    [SerializeField]
    private Starter starter; // Encapsulation: Private field with serialized attribute for controlled access

    [SerializeField]
    private GameObject ball; // Encapsulation: Private field with serialized attribute for controlled access

    [SerializeField]
    private AudioClip goalScoredSound; // Encapsulation: Private field with serialized attribute for controlled access

    private bool started = false; // Encapsulation: Private field for controlled access
    private int scoreLeft; // Encapsulation: Private field for controlled access
    private int scoreRight; // Encapsulation: Private field for controlled access
    private Vector3 startingPosition; // Encapsulation: Private field for controlled access
    private BallController ballController; // Encapsulation: Private field for controlled access
    private AudioSource audioSource; // Encapsulation: Private field for controlled access

    void Start() // Abstraction: Start method for initialization
    {
        startingPosition = ball.transform.position; // Abstraction: Initializing the starting position
        ballController = ball.GetComponent<BallController>(); // Abstraction: Retrieving BallController component
        audioSource = gameObject.AddComponent<AudioSource>(); // Abstraction: Adding AudioSource component
    }

    void Update() // Abstraction: Update method for input handling and game state
    {
        if (started)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            started = true;
            starter.StartCountdown();
        }
    }

    public void StartGame() // Abstraction: Public method for starting the game
    {
        ballController.Go();
    }

    public void ScoreGoalLeft() // Abstraction: Public method for scoring a goal on the left side
    {
        PlayGoalScoredSound();
        scoreRight++;
        UpdateUI();
        StartCoroutine(ResetBallWithDelay());
    }

    public void ScoreBonusGoalLeft() // Abstraction: Public method for scoring a bonus goal on the left side
    {
        PlayGoalScoredSound();
        scoreRight++;
        UpdateUI();
    }

    public void ScoreGoalRight() // Abstraction: Public method for scoring a goal on the right side
    {
        PlayGoalScoredSound();
        scoreLeft++;
        UpdateUI();
        StartCoroutine(ResetBallWithDelay());
    }

    public void ScoreBonusGoalRight() // Abstraction: Public method for scoring a bonus goal on the right side
    {
        PlayGoalScoredSound();
        scoreLeft++;
        UpdateUI();
    }

    private void UpdateUI() // Abstraction: Private method for updating the user interface
    {
        scoreTextLeft.text = scoreLeft.ToString();
        scoreTextLeft2.text = scoreLeft.ToString();
        scoreTextRight.text = scoreRight.ToString();
        scoreTextRight2.text = scoreRight.ToString();
    }

    public void ResetBall() // Abstraction: Public method for resetting the ball
    {
        ballController.Stop();
        ballController.ResetSpeed();
        ballController.ResetSize();
        ball.transform.position = startingPosition;
        starter.StartCountdown();
    }

    private void PlayGoalScoredSound() // Abstraction: Private method for playing the goal scored sound
    {
        if (goalScoredSound != null && audioSource != null)
            audioSource.PlayOneShot(goalScoredSound);
    }

    private System.Collections.IEnumerator ResetBallWithDelay() // Abstraction: Private method for resetting the ball with a delay
    {
        yield return new WaitForSeconds(4.0f); // Adjust the delay time as needed
        ResetBall();
    }
}