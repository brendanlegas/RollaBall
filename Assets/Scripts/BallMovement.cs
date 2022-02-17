using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallMovement : MonoBehaviour
{
    //Player's movement parameters
    public Vector3 direction;
    public float speed;

    public Rigidbody rb; //the player's rigidbody

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // All physics calculations happen in FixedUpdate
    void FixedUpdate()
    {
        //transform.Translate(direction * speed * Time.deltaTime);
        Vector3 localDirection = transform.TransformDirection(direction);
        //rb.MovePosition(rb.position + (localDirection * speed * Time.deltaTime));
        rb.AddForce(new Vector3(direction.x, 0f, direction.z));
    }

    //OnPlayerMove Event Handler
    public void OnPlayerMove(InputValue value)
    {
        // a vector with x and y components corresponding to the player's WASD and Arrow inputs
        //both components are in teh range [-1,1]
        Vector2 inputVector = value.Get<Vector2>();

        //Move in the x z plane
        direction.x = inputVector.x;
        direction.z = inputVector.y;

        direction.y = 0f;
    }
}
