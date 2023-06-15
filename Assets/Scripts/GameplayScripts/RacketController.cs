using UnityEngine;

public class RacketController : MonoBehaviour
{
    public float speed;
    public KeyCode upKey;
    public KeyCode downKey;
    public bool isPlayer = true;
    public float offset = 0.2f;

    private Rigidbody racketRb;
    private Transform ball;

    private void Start()
    {
        racketRb = GetComponent<Rigidbody>();
        ball = GameObject.FindGameObjectWithTag("Ball").transform;

        // Check if this is Player 1 or Player 2 and set the isPlayer variable accordingly
        if (gameObject.name == "Player")
        {
            isPlayer = true;
        }
        else if (gameObject.name == "PlayerTwo")
        {
            isPlayer = true;
        }
        else
        {
            isPlayer = false;
        }
    }

    private void Update()
    {
        if (isPlayer)
        {
            if (gameObject.name == "Player")
            {
                MovePlayerByInput();
            }
            else if (gameObject.name == "PlayerTwo")
            {
                MovePlayerTwoByInput();
            }
        }
        else
        {
            MoveByComputer();
        }
    }

    private void MovePlayerByInput()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 velocity = Vector3.forward * verticalInput * speed;
        racketRb.velocity = velocity;
    }

    private void MovePlayerTwoByInput()
    {
        float verticalInput = Input.GetAxis("Vertical2");
        Vector3 velocity = Vector3.forward * verticalInput * speed;
        racketRb.velocity = velocity;
    }

    private void MoveByComputer()
    {
        float targetZ = ball.position.z + (ball.position.z - transform.position.z > offset ? offset : -offset);
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, targetZ);
        Vector3 velocity = (targetPosition - transform.position).normalized * speed;
        racketRb.velocity = velocity;
    }
}