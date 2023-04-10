using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class steleManager : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        menuManager mM = FindObjectOfType<menuManager>();
        mM.giveCarTrophy();
    }
}
