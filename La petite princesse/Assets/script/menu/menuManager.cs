using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuManager : MonoBehaviour
{

    Boolean carTrophyWon = false;
    Boolean cloudTrophyWon = false;
    Boolean pizzaTrophyWon = false;
    Boolean minotaureTrophyWon = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START !!");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void giveCarTrophy()
    {
        Debug.Log("giveCarTrophy !!");
        carTrophyWon = true;
    }

    public Boolean haveCarTrophy()
    {
        return carTrophyWon;
    }


    public void giveCloudTrophy()
    {
        Debug.Log("giveCloudTrophy !!");
        cloudTrophyWon = true;
    }

    public Boolean haveCloudTrophy()
    {
        return cloudTrophyWon;
    }

    public void givePizzaTrophy()
    {
        Debug.Log("giveCarTrophy !!");
        pizzaTrophyWon = true;
    }

    public Boolean havePizzaTrophy()
    {
        return pizzaTrophyWon;
    }

    public void giveMinotaureTrophy()
    {
        Debug.Log("giveCarTrophy !!");
        minotaureTrophyWon = true;
    }

    public Boolean haveMinotaureTrophy()
    {
        return minotaureTrophyWon;
    }


}