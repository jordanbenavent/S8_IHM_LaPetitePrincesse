using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LabyrintheManager : MonoBehaviour
{
    public Canvas myCanvas;
    public Dialogues Dialogues;
    public GameObject player;
    public Transform parent;
    public GameObject princesseWithPower;
    public GameObject startDoor;
    public GameObject endDoor;
    public List<CheckPointLabyrinthe> CheckPoints;
    private bool labStart = false;
    private bool closedDoor = true;
    private bool endDoorOpen = false;
    private float angle = 90;

    public SceneLoader SceneLoader;
    public BossInteraction boss;

    void Start()
    {
        // Cacher le canvas au démarrage
        myCanvas.enabled = false;
        princesseWithPower.SetActive(false);
        //Destroy(princesseWithPower);
        ListenCheckpoints(true);
    }

    void FixedUpdate()
    {
       if(Dialogues.IsFinished() && closedDoor){
        OpenDoor();
       }

       if(boss.IsDead()){
        menuManager mM = FindObjectOfType<menuManager>();
        mM.giveMinotaureTrophy();
        SceneManager.LoadScene(1);
       }
    }

    private void ListenCheckpoints(bool subscribe)
    {
        foreach(CheckPointLabyrinthe checkpoint in CheckPoints) {
            //TODO : refacctor onChekpointEnter event
            if(subscribe) checkpoint.onCheckpointEnter.AddListener(CheckpointActivated);
            else checkpoint.onCheckpointEnter.RemoveListener(CheckpointActivated);
        }
    }

    public void CheckpointActivated(PrincesseIdentity p, CheckPointLabyrinthe checkpoint)
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
            if(!endDoorOpen){
                OpenDoor(endDoor);
            }
            return;
        }
    }

    private void OpenDoor(){
        startDoor.transform.Rotate(0, angle , 0, Space.Self);
        closedDoor = false;
        princesseWithPower.SetActive(true);
        player.SetActive(false);
        player = princesseWithPower;
    }

    private void OpenDoor(GameObject door){
        door.transform.Rotate(0, angle , 0, Space.Self);
        closedDoor = false;
    }
}
