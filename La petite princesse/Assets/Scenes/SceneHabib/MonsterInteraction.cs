using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInteraction : MonoBehaviour
{
    public float oldHealthBarre;
    public float healthBarre;
    // Start is called before the first frame update
    void Start()
    {

        oldHealthBarre = healthBarre;
    }

    // Update is called once per frame
    void Update()
    {
        if(oldHealthBarre != healthBarre)
        {
            Debug.Log("Grrrrrrrrrrrrrrr");
            oldHealthBarre=healthBarre; 
        }
    }


    public void applyDmg(float dmg)
    {
        healthBarre -= dmg;
    }
}
