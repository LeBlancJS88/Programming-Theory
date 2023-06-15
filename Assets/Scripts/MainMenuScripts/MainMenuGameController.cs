using UnityEngine;
using TMPro;

public class MainMenuGameController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreTextLeft;

    [SerializeField]
    private TMP_Text scoreTextLeft2;

    [SerializeField]
    private TMP_Text scoreTextRight;
    
    [SerializeField]
    private TMP_Text scoreTextRight2;

    [SerializeField]
    private MainMenuStarter mainMenuStarter;

    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private AudioClip goalScoredSound;

    private bool started = false;
    private int scoreLeft;
    private int scoreRight;
    private Vector3 startingPosition;
    private BallController ballController;
    private AudioSource audioSource;

    void Start()
    {
        startingPosition = ball.transform.position;
        ballController = ball.GetComponent<BallController>();
        audioSource = gameObject.AddComponent<AudioSource>();
        mainMenuStarter.StartCountdown();
    }

    void Update()
    {
        if (started)
        {
            return;
        }

        /*if (Input.GetKey(KeyCode.Space))
        {
            started = true;
            starter.StartCountdown();
        }*/
    }

    public void StartGame()
    {
        ballController.Go();
    }

    public void ScoreGoalLeft()
    {
        PlayGoalScoredSound();
        scoreRight ++;
        UpdateUI();
        StartCoroutine(ResetBallWithDelay());
    }

    public void ScoreBonusGoalLeft()
    {
        PlayGoalScoredSound();
        scoreRight++;
        UpdateUI();
    }

    public void ScoreGoalRight()
    {
        PlayGoalScoredSound();
        scoreLeft ++;
        UpdateUI();
        StartCoroutine(ResetBallWithDelay());
    }

    public void ScoreBonusGoalRight()
    {
        PlayGoalScoredSound();
        scoreLeft++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreTextLeft.text = scoreLeft.ToString();
        scoreTextLeft2.text = scoreLeft.ToString();
        scoreTextRight.text = scoreRight.ToString();
        scoreTextRight2.text = scoreRight.ToString();
    }

    public void ResetBall()
    {
        ballController.Stop();
        ballController.ResetSpeed();
        ballController.ResetSize();
        ball.transform.position = startingPosition;
        mainMenuStarter.StartCountdown();
    }

    private void PlayGoalScoredSound()
    {
        if (goalScoredSound != null && audioSource != null)
            audioSource.PlayOneShot(goalScoredSound);
    }

    private System.Collections.IEnumerator ResetBallWithDelay()
    {
        yield return new WaitForSeconds(4.0f); // Adjust the delay time as needed
        ResetBall();
    }
}