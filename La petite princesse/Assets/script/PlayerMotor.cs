using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMotor : MonoBehaviour
{

    public float runspeed;
    public float walkspeed;
    public float turnspeed;
    public Rigidbody rg;

    public Animator animator;

    private float runValue;
    private float turnValue;
    private float walkValue;


    private void Update()
    {
        animator.SetFloat("walk", walkValue);
        animator.SetFloat("run", runValue);
        animator.SetFloat("turn", turnValue);

    }


    void FixedUpdate() // Get keyboard inputs
    {
        runValue=Input.GetAxis("Run");
        walkValue = Input.GetAxis("Vertical");
        turnValue = Input.GetAxis("Horizontal");


        if (runValue > 0.4)
        {
           
            if (walkValue > 0.4)
            {
                rg.MovePosition(transform.position + transform.forward * runspeed * Time.deltaTime);
                //transform.Translate(0, 0, runspeed * Time.deltaTime);
            }
            if (walkValue < -0.4)
            {
                rg.MovePosition(transform.position + transform.forward * -(runspeed / 2) * Time.deltaTime);
                //transform.Translate(0, 0, -(runspeed / 2) * Time.deltaTime);
            }
        }
        if (walkValue > 0.4 & runValue < 0.4)
        {
            rg.MovePosition(transform.position + transform.forward * walkspeed * Time.deltaTime);
            //transform.Translate(0, 0, walkspeed * Time.deltaTime);
        }
        if (walkValue < -0.4 & runValue < 0.4)
        {
            rg.MovePosition(transform.position + transform.forward * -(walkspeed / 2) * Time.deltaTime);
            //transform.Translate(0, 0, -(walkspeed / 2) * Time.deltaTime);
        }

        if (turnValue > 0.4)
        {
            rg.MoveRotation(transform.rotation * Quaternion.Euler(0, turnspeed * Time.deltaTime, 0));
            //transform.Rotate(0, turnspeed * Time.deltaTime, 0);
        }
        if (turnValue < -0.4)
        {
            rg.MoveRotation(transform.rotation * Quaternion.Euler(0, -turnspeed * Time.deltaTime, 0));
            //transform.Rotate(0, -turnspeed * Time.deltaTime, 0);
        }

    }  
}

