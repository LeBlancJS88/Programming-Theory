using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float minDirection = 0.5f;

    [SerializeField]
    private GameObject sparksVFX;

    private Vector3 direction;
    private Rigidbody ballRb;
    private bool stopped = false;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public float MinDirection
    {
        get { return minDirection; }
        set { minDirection = value; }
    }

    private void Start()
    {
        ballRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (stopped)
            return;

        ballRb.MovePosition(ballRb.position + direction * Speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        bool hit = false;

        if (other.CompareTag("Wall"))
        {
            direction.z = -direction.z;
            hit = true;
        }

        if (other.CompareTag("Racket"))
        {
            Vector3 newDirection = (transform.position - other.transform.position).normalized;

            float randomFactor = Random.Range(0.8f, 1.2f); // Adjust the range for desired randomness

            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), MinDirection) * randomFactor;
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), MinDirection) * randomFactor;

            direction = newDirection;
            hit = true;
        }

        if (hit)
        {
            GameObject sparks = Instantiate(sparksVFX, transform.position, transform.rotation);
            Destroy(sparks, 2f);
        }
    }

    public void Stop()
    {
        stopped = true;
    }

    public void Go()
    {
        stopped = false;
        ChooseDirection();
    }

    private void ChooseDirection()
    {
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        float signZ = Mathf.Sign(Random.Range(-1f, 1f));

        direction = new Vector3(0.5f * signX, 0, 0.5f * signZ);
    }
}