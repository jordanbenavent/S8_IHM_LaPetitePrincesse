using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    void Start () {
        transform.position = player.transform.position + new Vector3(0, 1, -12);
    }

    // Update is called once per frame
    void Update () {
        if (player.transform.position.y > transform.position.y)
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
    }
}
