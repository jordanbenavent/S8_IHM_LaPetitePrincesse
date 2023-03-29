using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInteraction : MonoBehaviour
{
    public float oldHealthBarre;
    public float healthBarre;
    public Animator anim;
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
            anim.Play("Damage");
            oldHealthBarre=healthBarre; 
        }
        if (healthBarre <= 0)
        {
            anim.Play("Damage");
            Destroy(gameObject);        }
    }


    public void applyDmg(float dmg)
    {
        healthBarre -= dmg;
    }
}
