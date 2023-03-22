using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PNJ_Motor : MonoBehaviour
{

    public bool isTalking = false;
    
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isTalking", isTalking);
    }

    void FixedUpdate() // Get keyboard inputs
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isTalking=!isTalking;
            Debug.Log("E key was pressed." + isTalking);
        }
    }
}
