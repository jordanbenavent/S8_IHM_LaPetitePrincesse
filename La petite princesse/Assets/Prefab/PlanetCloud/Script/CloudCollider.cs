using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollider : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Calculate the dot product of the collision normal and the up vector of the character
        float dotProduct = Vector3.Dot(collision.contacts[0].normal, transform.up);

        // Check if the collision happened from above or below
        if (dotProduct >= 0)
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
}
