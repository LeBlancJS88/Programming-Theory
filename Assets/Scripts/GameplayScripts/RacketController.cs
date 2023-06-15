using UnityEngine;

public class RacketController : MonoBehaviour
{
    [SerializeField]
    private float speed;  // Encapsulation - speed field is encapsulated and made private with a SerializeField attribute

    [SerializeField]
    private KeyCode upKey;  // Encapsulation - upKey field is encapsulated and made private with a SerializeField attribute

    [SerializeField]
    private KeyCode downKey;  // Encapsulation - downKey field is encapsulated and made private with a SerializeField attribute

    [SerializeField]
    internal bool isPlayer = true;  // Encapsulation - isPlayer field is encapsulated and made internal with a SerializeField attribute

    [SerializeField]
    private float offset = 0.2f;  // Encapsulation - offset field is encapsulated and made private with a SerializeField attribute

    private Rigidbody racketRb;  // Abstraction - racketRb field represents the Rigidbody component of the racket, abstracting the details of its implementation

    private Transform ball;  // Abstraction - ball field represents the Transform component of the ball, abstracting the details of its implementation

    private void Start()
    {
        racketRb = GetComponent<Rigidbody>();  // Abstraction - Getting the Rigidbody component of the racket using GetComponent method, abstracting the details of its implementation
        ball = GameObject.FindGameObjectWithTag("Ball").transform;  // Abstraction - Finding the ball object by tag and accessing its Transform component, abstracting the details of its implementation

        // Check if this is Player 1 or Player 2 and set the isPlayer variable accordingly
        if (gameObject.name == "Player" || gameObject.name == "PlayerTwo")
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
        float verticalInput = Input.GetAxis("Vertical");  // Abstraction - Getting the vertical input using Input.GetAxis method, abstracting the details of input retrieval
        Vector3 velocity = Vector3.forward * verticalInput * speed;  // Encapsulation - Calculating velocity using private speed field
        racketRb.velocity = velocity;
    }

    private void MovePlayerTwoByInput()
    {
        float verticalInput = Input.GetAxis("Vertical2");  // Abstraction - Getting the vertical input using Input.GetAxis method, abstracting the details of input retrieval
        Vector3 velocity = Vector3.forward * verticalInput * speed;  // Encapsulation - Calculating velocity using private speed field
        racketRb.velocity = velocity;
    }

    private void MoveByComputer()
    {
        float targetZ = ball.position.z + (ball.position.z - transform.position.z > offset ? offset : -offset);  // Abstraction - Calculating the target position using the ball's position and the offset
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, targetZ);  // Abstraction - Creating the target position vector, abstracting the details of its implementation
        Vector3 velocity = (targetPosition - transform.position).normalized * speed;  // Encapsulation - Calculating velocity using private speed field
        racketRb.velocity = velocity;
    }
}