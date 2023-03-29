using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellColision : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float dmg;
    void Start()
    {
        Destroy(gameObject,4);
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            Debug.Log("je suis le sort");
            collision.gameObject.GetComponent<MonsterInteraction>().applyDmg(dmg);
            Destroy(gameObject);
        }
        
    }
}
