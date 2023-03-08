using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // needed to use UnityEvent

public class PlayerControls : MonoBehaviour
{
    private Vector2 input;
    public UnityEvent<Vector2> onInput;

    private float inputX;
    private float inputY;

    void Update() // Get keyboard inputs
   {
       inputY = Input.GetAxis("Vertical");
       inputX = Input.GetAxis("Horizontal");
       this.input = new Vector2(inputX, inputY).normalized;
       onInput.Invoke(this.input);
   }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
