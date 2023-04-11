using System;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private bool hasBeenSeen = false;
    private float direction;
    private float speed;

    void Start()
    {
        direction = (float)System.Math.Round(UnityEngine.Random.Range(0f, 1f)) * 2f - 1f;
        speed = UnityEngine.Random.Range(0.6f, 4f);
    }
    // Update is called once per frame
    void Update()
    {
        if(hasBeenSeen){
            transform.position = transform.position + new Vector3(direction * Time.deltaTime * speed, 0f, 0f);
        }
    }

    void OnBecameVisible(){
        hasBeenSeen = true;
    }
}
