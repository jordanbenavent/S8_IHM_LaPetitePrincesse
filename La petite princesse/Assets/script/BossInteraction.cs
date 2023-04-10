using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public float oldHealthBarre;
    public float healthBarre;
    public Animator anim;
    public bool isDead;
    public IABoss ia;
    private float oldTime;
    // Start is called before the first frame update
    void Start()
    {

        oldHealthBarre = healthBarre;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            oldTime = Time.time;
            if (oldHealthBarre != healthBarre)
            {
                anim.Play("Damage");
                oldHealthBarre = healthBarre;
            }
            if (healthBarre <= 0)
            {
                anim.Play("death");
                isDead = true;
                ia.Die();   
            }
        }
        
        
    }


    public void applyDmg(float dmg)
    {
        healthBarre -= dmg;
    }
}
