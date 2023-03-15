using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI myText;
    // Start is called before the first frame update

    public void UpdateLapText(string newText){
        myText.text = newText;
    }

    void Start()
    {
        //myText.text = "Start !!!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
