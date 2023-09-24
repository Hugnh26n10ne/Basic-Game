using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Car settings")]
    public float accelerationFactor = 30f;
    public float turnFactor = 3.5f;
    public float driftFactor = 0.95f;


    // local variables
    float accelerationInput = 0;
    float steeringInput = 0;

    float rotationAngle = 0;

    float velocityVsUp = 0;
    public float maxSpeed = 50f;


    // Components
    Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    //Frame-rate independent for physics calculations
    private void FixedUpdate()
    {
        ApplyEngineForce();

        KillOrthogonalVelocity();

        ApplySteering();
    }

    public void ApplyEngineForce()
    {


        //Caculate how much "forward" we are going in terms of the direction of our velocity
        velocityVsUp = Vector2.Dot(transform.up, rb2d.velocity);

        // Limit so we cannot go faster than the max speed in the "forward" direction
        if(velocityVsUp > maxSpeed && accelerationInput > 0f)
            return;

        if(velocityVsUp < -maxSpeed * 0.5f && accelerationInput < 0)
            return;

        if(rb2d.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
            return;

        if (accelerationInput == 0) {
            rb2d.drag = Mathf.Lerp(rb2d.drag, 3.0f, Time.fixedDeltaTime * 3);
        }
        else
        {
            rb2d.drag = 0;
        }

        //Create a force for the engine
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

        //Apply forces and pushes the car forward
        rb2d.AddForce(engineForceVector, ForceMode2D.Force);
    }

    public void ApplySteering()
    {

        // Limit the cars ability to tủn whien moving slowly
        float minSpeedBeforeAllowTurningFactor = (rb2d.velocity.magnitude / 8);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

        //Update the rotation angle based on input
        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeAllowTurningFactor;

        //Apply steering by rotation the car object
        rb2d.MoveRotation(rotationAngle);
    }

    public void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb2d.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(rb2d.velocity, transform.right);

        rb2d.velocity = forwardVelocity + rightVelocity * driftFactor;
    }


    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }
}
