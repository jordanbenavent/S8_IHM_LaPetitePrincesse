using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessMouvement : MonoBehaviour
{
    public Rigidbody rg;
    public float forwardMoveSpeed;
    public float backwardMoveSpeed;
    public float steerSpeed;
    private Vector2 input;


    void FixedUpdate() // Apply physics here
    {
        // Accelerate
        float speed = input.y > 0 ? forwardMoveSpeed : backwardMoveSpeed;
        if (input.y < 1 & input.y>-1) speed = 0;
        if(input.y==1 | input.y == -1)
        {
            rg.AddForce(this.transform.forward * speed, ForceMode.Acceleration);
           
        }
        // Steer
        if (input.x == 1 | input.x == -1)
        {
            float speedlateral = input.x > 0 ? steerSpeed : -steerSpeed;
            
            rg.AddForce(this.transform.right * speedlateral, ForceMode.Acceleration);
        }

    }

    public void SetInputs(Vector2 input)
    {
        this.input = input;
    }



}
