using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float rotationSpeed;

    private Camera mainCamera;
    private Vector2 movementDirection;
    private Vector2 startPosition;
    private Rigidbody2D rb2d;
    private Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Getting the rigidbody component
        mainCamera = Camera.main;  // Fetch the main camera of the scene
        startPosition = new Vector2(0f, 0f);
        transform.position = startPosition; // set the starting position of player as 0,0  
    }

    private void ProcessInput()
    {
        // Process the rotation of the spaceship
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition); // converting pixel coords to the world coords

        // Set the movement direction in this method
        if (Input.GetKey(KeyCode.W))
        {
            movementDirection = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementDirection = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movementDirection = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movementDirection = Vector2.left;
        }
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb2d.position; // Direction to look at for the spaceship
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb2d.rotation = angle;

        if (movementDirection == Vector2.zero) { return; }

        rb2d.AddForce(movementDirection * forceMagnitude * Time.fixedDeltaTime, ForceMode2D.Force);

        // Restrict the max speed of player's spaceship
        rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }
}
