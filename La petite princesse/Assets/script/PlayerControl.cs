using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControl1 : MonoBehaviour
{
    public UnityEvent<Vector2> onInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private float inputX;
    private float inputY;


    void Update() // Get keyboard inputs
    {
        inputY = Input.GetAxis("Vertical");
        inputX = Input.GetAxis("Horizontal");

        onInput.Invoke(new Vector2(inputX, inputY).normalized);
    }
}
