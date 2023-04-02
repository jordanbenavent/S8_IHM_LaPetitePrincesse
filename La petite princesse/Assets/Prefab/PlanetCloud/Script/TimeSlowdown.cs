using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlowdown : MonoBehaviour
{
    public Transform playerTransform;
    public float slowdownRadius = 40;
    public float slowdownFactor = 0.5f;
    public float maxTimeScale = 1f;

    private bool trophyFound;
    private Transform trophyTransform;

    private void Update()
    {
        if(trophyFound){
            // Calculate the distance between the player and the trophy
            float distance = Vector3.Distance(playerTransform.position, trophyTransform.position);

            // If the player is within the slowdown radius
            if (distance < slowdownRadius)
            {
                // Calculate the new time scale based on the distance
                float newTimeScale = Mathf.InverseLerp(0f, slowdownFactor, distance / slowdownRadius);

                // Set the time scale
                Time.timeScale = newTimeScale;

                // Update the fixed delta time accordingly
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
            }
            else
            {
                // Reset the time scale and fixed delta time
                Time.timeScale = maxTimeScale;
                Time.fixedDeltaTime = 0.02f;
            }
        } else {
            GameObject trophy = GameObject.FindWithTag("trophyTag");
            if(trophy != null){
                trophyFound = true;
                trophyTransform = trophy.transform;
            }
        }
    }
}