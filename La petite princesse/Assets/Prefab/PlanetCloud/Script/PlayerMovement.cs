using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    private float walkValue;

    public float jumpspeed;
    public float walkspeed;
    public GameObject[] groundObjects;       // layer mask for the ground
    public GameObject[] nonTangibleObjects;       // made fot the trophy
    public Animator animator;
    public static event EventHandler<PlayerOutOfScreenEventArgs> PlayerOutOfScreen;

    private Rigidbody rb;               // reference to the Rigidbody component
    private Collider coll;              // reference to the Collider component
    private bool isGrounded = false;    // flag for checking if the player is grounded
    private int layerMask = 0;
    private RaycastHit hit;
    private bool launched = false;
    private float maxAltitude = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();     // get the Rigidbody component
        coll = GetComponent<Collider>();    // get the Collider component
        /*foreach (GameObject obj in nonTangibleObjects)
        {
            int layerIndex = obj.layer;
            layerMask &= ~(1 << layerIndex);
            Debug.Log(layerIndex);
        }
        foreach (GameObject ground in groundObjects)
        {
            int layerIndex = ground.layer;
            layerMask |= 1 << layerIndex;
            Debug.Log(layerIndex);
        }*/
        layerMask &= ~(1 << 7);
        layerMask |= 1 << 6;
    }

    void Update()
    {
        walkValue = Input.GetAxis("Horizontal");
        Debug.Log("CloudWalk: " + walkValue);
        isGrounded = rb.velocity.y <= 0 && Physics.Raycast(transform.position, Vector3.down, out hit, 0.5f, layerMask);
        // check if the player is grounded
        if(!isGrounded){
            animator.SetFloat("jump", 1);
        } else {
            if(launched){
                animator.SetFloat("jump", 0);
                rb.velocity = new Vector3(rb.velocity.x, jumpspeed, rb.velocity.z);
            } else {
                if(Input.GetKeyDown(KeyCode.Space)){
                    animator.SetFloat("jump", 1);
                    rb.velocity = new Vector3(rb.velocity.x, jumpspeed, rb.velocity.z);
                    launched = true;
                } else {
                    animator.SetFloat("jump", 0);
                    animator.SetFloat("walk", Math.Abs(walkValue));
                }
            }
        }

        if (walkValue > 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.right);
            transform.Translate(0, 0, walkspeed * Time.deltaTime);
        }
        if (walkValue < -0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.left);
            transform.Translate(0, 0, walkspeed * Time.deltaTime);
        }
        
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * 3f * Time.deltaTime;
        }

        if (transform.position.y > maxAltitude) maxAltitude = transform.position.y;
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.y < 0)
        {
            PlayerOutOfScreen.Invoke(this, new PlayerOutOfScreenEventArgs(maxAltitude));
        }
    }
}