using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 1500f;
    public float sideWayForce = 500f;

    public bool movesLeft, movesRight = false;

    void Update()
    {
        movesLeft = false;
        movesRight = false;

        if (Input.GetKey("d"))
            movesRight = true;

        if (Input.GetKey("a")) 
            movesLeft = true;
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (movesRight)
            rb.AddForce(sideWayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (movesLeft)
            rb.AddForce(-sideWayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
