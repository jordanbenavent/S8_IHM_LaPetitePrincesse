using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogues : MonoBehaviour
{

    public Canvas myCanvas;
    public GameObject player;
    public GameObject pnj;
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI[] lines;
    public float textSpeed;
    private bool EndDialogue = false;
    private bool noTalked;
    private bool talking;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        noTalked = true;
        talking = false;
        myCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(){
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine(){
        textComponent.text = string.Empty;
        foreach(char c in lines[index].text.ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    
    void FixedUpdate()
    {
        // Si l'utilisateur appuie sur la touche "Echap", cacher le canvas
        if (Input.GetKeyDown(KeyCode.E) && noTalked)
        {   
            double  minDist=3;
            float dist = Vector3. Distance(player.transform.position, pnj.transform.position);
            if(dist < minDist)
            {
                myCanvas.enabled = true;
                StartDialogue();
                talking = true;
            }
        }

        if(!IsFinished() && (Input.GetKeyDown(KeyCode.Return) )){
            if(talking){
                newDialague();
            }
            if(IsFinished()){
                myCanvas.enabled = false;
                noTalked = false;
            }
        }
    }


    public bool IsFinished(){
        return EndDialogue;//index >= lines.Length;
    }

    public void newDialague() // Get keyboard inputs
    {
        index++;
        if(index >= lines.Length){
            myCanvas.enabled = false;
            EndDialogue = true;
            index = 0;
        } else {
            StartCoroutine(TypeLine());
        }
    }
}
