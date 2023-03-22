using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrintheManager : MonoBehaviour
{
    public Canvas myCanvas;
    public Dialogues Dialogues;
    public GameObject player;
    public List<CheckPointLabyrinthe> CheckPoints;
    private bool labStart = false;

    void Start()
    {
        // Cacher le canvas au démarrage
        myCanvas.enabled = false;
        ListenCheckpoints(true);
    }

    void FixedUpdate()
    {
       
    }

    private void ListenCheckpoints(bool subscribe)
    {
        foreach(CheckPointLabyrinthe checkpoint in CheckPoints) {
            //TODO : refacctor onChekpointEnter event
            if(subscribe) checkpoint.onCheckpointEnter.AddListener(CheckpointActivated);
            else checkpoint.onCheckpointEnter.RemoveListener(CheckpointActivated);
        }
    }

    public void CheckpointActivated(PrincesseIdentity car, CheckPointLabyrinthe checkpoint)
    {
        int checkpointNumber = CheckPoints.IndexOf(checkpoint);
        Debug.Log(checkpointNumber);
        if(checkpointNumber == 1 && !labStart){
            Debug.Log("laby pas commencé");
            return;
        }

        if(checkpointNumber == 0){
            labStart = true;
        }

        if(checkpointNumber == 1 && labStart){
            Debug.Log("Bravo !");
            return;
        }
    }
}