using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public float healthBarre = 100;
    private float oldHealthBarre;
    public Animator animator;
    public bool isAttacking;

    public float spellSpeed;
    public GameObject spellGO;
    public GameObject portalGO;
    public GameObject departureSpell;
    // Start is called before the first frame update
    void Start()
    {
        oldHealthBarre = healthBarre;
        isAttacking = false;
        departureSpell.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

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
            
        
            animator.Play("castSpell");
            
            
            GameObject spell = Object.Instantiate(spellGO, departureSpell.transform.position ,transform.rotation);
            GameObject portal = Object.Instantiate(portalGO, departureSpell.transform.position, transform.rotation);
            spell.GetComponent<Rigidbody>().AddForce(transform.forward * spellSpeed); 
            
            isAttacking = true;
        
        
    }
}
