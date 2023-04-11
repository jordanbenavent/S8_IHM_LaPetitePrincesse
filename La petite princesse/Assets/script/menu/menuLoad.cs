using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuLoad : MonoBehaviour
{

    public GameObject carTrophy;
    public GameObject cloudTrophy;
    public GameObject pizzaTrophy;
    public GameObject minotaureTrophy;
    public GameObject carCarpet;
    public GameObject cloudCarpet;
    public GameObject pizzaCarpet;
    public GameObject minotaureCarpet;

    public GameObject cadreMusee;
    public GameObject cadreMuseePhoto;

    // Start is called before the first frame update
    void Start()
    {

        carTrophy.SetActive(false);
        cloudTrophy.SetActive(false);
        pizzaTrophy.SetActive(false);
        minotaureTrophy.SetActive(false);

        carCarpet.SetActive(false);
        cloudCarpet.SetActive(false);
        pizzaCarpet.SetActive(false);
        minotaureCarpet.SetActive(false);

        cadreMusee.SetActive(false);
        cadreMuseePhoto.SetActive(false);

        //carTrophy

        menuManager mM = FindObjectOfType<menuManager>();

        if(mM.haveCarTrophy())
        {
            carTrophy.SetActive(true);
            carCarpet.SetActive(true);
        }

        //cloudTrophy

        if (mM.haveCloudTrophy())
        {
            cloudTrophy.SetActive(true);
            cloudCarpet.SetActive(true);
        }

        //carTrophy

        if (mM.havePizzaTrophy())
        {
            pizzaTrophy.SetActive(true);
            pizzaCarpet.SetActive(true);
        }

        //carTrophy

        if (mM.haveMinotaureTrophy())
        {
            minotaureTrophy.SetActive(true);
            minotaureCarpet.SetActive(true);
        }


        if (mM.haveCarTrophy()
            && mM.haveCloudTrophy()
            && mM.havePizzaTrophy()
            && mM.haveMinotaureTrophy())
        {
            cadreMusee.SetActive(true);
            cadreMuseePhoto.SetActive(true);
        }
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
