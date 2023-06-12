using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{

    public float speed;

    public KeyCode up;
    public KeyCode down;

    public bool isPlayer = true;

    public float offset = 0.2f;

    private Rigidbody playerRb;

    private Transform ball;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isPlayer)
        {
            MoveByPlayer();
        }
        else
        {
            MoveByComputer();
        }
    }

    private void MoveByPlayer()
    {
        bool pressedUp = Input.GetKey(this.up);

        bool pressedDown = Input.GetKey(this.down);

        if (pressedUp)
        {
            playerRb.velocity = Vector3.forward * speed;
        }

        if (pressedDown)
        {
            playerRb.velocity = Vector3.back * speed;
        }

        if (!pressedUp && !pressedDown)
        {
            playerRb.velocity = Vector3.zero;
        }
    }

    private void MoveByComputer()
    {
        if (ball.position.z > transform.position.z + offset)
        {
            playerRb.velocity = Vector3.forward * speed;
        }
        else if (ball.position.z < transform.position.z - offset)
        {
            playerRb.velocity = Vector3.back * speed;
        }
        else
        {
            playerRb.velocity = Vector3.zero;
        }
    }
}
