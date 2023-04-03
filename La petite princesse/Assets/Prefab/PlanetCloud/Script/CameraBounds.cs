using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraBounds : MonoBehaviour
{
    public UnityEvent PlayerOutOfScreen;
    public Transform player;

    private Camera cam;
    private Vector3 bottomLeft;
    private Vector3 topRight;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Start()
    {
        bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        topRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.nearClipPlane));
    }

    private void Update()
    {
        if (PlayerIsOutOfScreen())
        {
            PlayerOutOfScreen.Invoke();
        }
    }

    private bool PlayerIsOutOfScreen()
    {
        Vector3 playerPosition = player.position;
        return playerPosition.x < bottomLeft.x || playerPosition.x > topRight.x ||
               playerPosition.y < bottomLeft.y || playerPosition.y > topRight.y;
    }
}