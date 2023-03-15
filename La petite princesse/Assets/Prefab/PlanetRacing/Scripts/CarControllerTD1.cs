using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerTD1 : MonoBehaviour
{

   public Rigidbody rg;
   public float forwardMoveSpeed;
   public float backwardMoveSpeed;
   public float steerSpeed;

   private float inputX;
   private float inputY;
   void Update() // Get keyboard inputs
   {
       inputY = Input.GetAxis("Vertical");
       inputX = Input.GetAxis("Horizontal");
       //Debug.Log(inputX + "," + inputY);
   }
   
   void FixedUpdate() // Apply physics here
   {
       // Accelerate
       float speed = inputY > 0 ? forwardMoveSpeed : backwardMoveSpeed;
       if (inputY == 0) speed = 0;
       rg.AddForce(this.transform.forward * speed, ForceMode.Acceleration);
       // Steer
       float rotation = inputX * steerSpeed * Time.fixedDeltaTime;
       transform.Rotate(0, rotation, 0, Space.World);
   }
        // Start is called before the first frame update
    void Start()
    {
        
    }
}
