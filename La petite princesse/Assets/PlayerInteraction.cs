using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float maxHealth=100;
    public float maxMana=100;
    public float healthBarre = 100;
    public float ManaBarre = 100;
    public float manaCost = 10;
    private float oldHealthBarre;
    public Animator animator;
    public bool isAttacking;
    public Image hp;
    public Image mana;

    public float spellSpeed;
    public GameObject spellGO;
    public GameObject portalGO;
    public GameObject departureSpell;
    private float oldTime;
    // Start is called before the first frame update
    void Start()
    {
        oldTime=Time.time;
        oldHealthBarre = healthBarre;
        isAttacking = false;
        departureSpell.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (healthBarre <= 0)
        {
            Debug.Log("You are dead");
        }
        if (Time.time - oldTime > 2 & ManaBarre <= maxMana-2) 
        {
            ManaBarre += 2;
            oldTime = Time.time;
        }
        float percentageHp = ((healthBarre * 100) / maxHealth) / 100;
        float percentageMana = ((ManaBarre * 100) / maxMana) / 100;
        hp.fillAmount = percentageHp;
        mana.fillAmount = percentageMana;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spell1();

        }
        if (healthBarre != oldHealthBarre)
        {
            Debug.Log(healthBarre);
            animator.Play("hit");
            oldHealthBarre=healthBarre;
        }

    }


    public void Spell1()
    {
        if (ManaBarre > manaCost)
        {
            animator.Play("castSpell");


            GameObject spell = Object.Instantiate(spellGO, departureSpell.transform.position, transform.rotation);
            GameObject portal = Object.Instantiate(portalGO, departureSpell.transform.position, transform.rotation);
            spell.GetComponent<Rigidbody>().AddForce(transform.forward * spellSpeed);

            isAttacking = true;
            ManaBarre -= manaCost;
        }
        
            
        
        
    }
}
