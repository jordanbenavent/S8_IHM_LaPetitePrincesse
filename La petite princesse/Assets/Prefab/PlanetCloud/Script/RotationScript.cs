using System;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float rotationSpeedY = 100.0f;
    public float rotationSpeedX = 100.0f;
    public float swingAngle = 60.0f;
    public float swingSpeed = 40.0f;
    
    private float swingDirection = 1.0f;
    private float swingAngleCurrent = 0.0f;

    public delegate void TrophyAction();
    public static TrophyAction fading;

    void Start(){
        BoxCollider bc = gameObject.AddComponent<BoxCollider>();
        bc.isTrigger = true;
    }
    
    void Update()
    {
        // Rotate on the Y axis
        transform.Rotate(Vector3.up * rotationSpeedY * Time.deltaTime, Space.World);
        
        // Swing on the X axis
        float swingAngleDelta = swingDirection * swingSpeed * Time.deltaTime;
        swingAngleCurrent += swingAngleDelta;
        if (swingAngleCurrent > swingAngle || swingAngleCurrent < -swingAngle) {
            swingDirection *= -1.0f;
        }
        transform.Rotate(Vector3.right * swingAngleDelta, Space.Self);
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            fading();
        }
    }
}