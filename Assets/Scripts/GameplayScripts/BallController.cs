using UnityEngine;

public class BallController : MonoBehaviour
{
    // ENCAPSULATION:
    // Private fields with serialized attributes for controlled access
    [SerializeField] private float initialSpeed = 20f; // Initial speed of the ball

    private float currentSpeed; // Current speed of the ball

    [SerializeField] private float minDirection = 0.5f;

    [SerializeField] private GameObject sparksVFX;

    [SerializeField] private AudioClip[] collisionSounds;

    // ABSTRACTION:
    // Private fields to hide internal implementation details
    private Vector3 direction;
    private Rigidbody ballRb;
    private bool stopped = false;
    private AudioSource audioSource;

    // Delegate function for adjusting the speed
    private delegate void SpeedAdjustmentDelegate(float speedMultiplier);
    private SpeedAdjustmentDelegate speedAdjustmentFunc;

    // Encapsulation and Abstraction:
    // Getter and Setter for the minDirection property
    protected float MinDirection
    {
        get { return minDirection; }
        set { minDirection = value; }
    }

    // POLYMORPHISM:
    // Virtual methods that can be overridden by derived classes
    protected virtual void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
        currentSpeed = initialSpeed;
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public void SetCurrentSpeed(float speed)
    {
        currentSpeed = speed;
        Vector3 velocity = ballRb.velocity.normalized * currentSpeed;
        ballRb.velocity = velocity;
    }

    // Encapsulation and Abstraction:
    // FixedUpdate method for physics-related logic
    private void FixedUpdate()
    {
        if (stopped)
            return;

        ballRb.MovePosition(ballRb.position + direction * currentSpeed * Time.fixedDeltaTime);
    }

    public void ApplySpeedMultiplier(float speedMultiplier)
    {
        currentSpeed *= speedMultiplier;
        // You can add additional logic here to clamp the speed within a desired range if needed
    }

    public void ResetSpeed()
    {
        currentSpeed = initialSpeed;
    }

    public void ApplyGiantMultiplier(float giantMultiplier)
    {
        transform.localScale *= giantMultiplier;
    }

    public void ApplyShrinkDividend(float shrinkDividend)
    {
        transform.localScale /= shrinkDividend;
    }

    public void ResetSize()
    {
        transform.localScale = Vector3.one;
    }

    // ABSTRACTION:
    // Protected method that can be overridden by derived classes
    protected virtual void OnTriggerEnter(Collider other)
    {
        bool hit = false;

        if (other.CompareTag("Wall"))
        {
            direction.z = -direction.z;
            hit = true;

            PlayCollisionSound(1);
        }

        if (other.CompareTag("Racket"))
        {
            Vector3 newDirection = (transform.position - other.transform.position).normalized;

            float randomFactor = Random.Range(0.8f, 1.2f); // Adjust the range for desired randomness

            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), MinDirection) * randomFactor;
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), MinDirection) * randomFactor;

            direction = newDirection;
            hit = true;

            PlayCollisionSound(0);
        }

        if (hit)
        {
            GameObject sparks = Instantiate(sparksVFX, transform.position, transform.rotation);
            Destroy(sparks, 2f);
        }
    }

    // ABSTRACTION:
    // Public methods that provide a high-level interface to control behavior
    public void Stop()
    {
        stopped = true;
    }

    public void Go()
    {
        stopped = false;
        ChooseDirection();
    }

    // ABSTRACTION:
    // Private method for internal implementation details
    private void ChooseDirection()
    {
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        float signZ = Mathf.Sign(Random.Range(-1f, 1f));

        direction = new Vector3(0.5f * signX, 0, 0.5f * signZ);
    }

    // ABSTRACTION:
    // Private method for internal implementation details
    private void PlayCollisionSound(int index)
    {
        if (collisionSounds.Length == 0)
            return;

        if (index >= 0 && index < collisionSounds.Length)
            audioSource.PlayOneShot(collisionSounds[index]);
    }
}