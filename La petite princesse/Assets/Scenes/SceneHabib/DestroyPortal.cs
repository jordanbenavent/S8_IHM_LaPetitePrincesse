using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPortal : MonoBehaviour
{
    // Start is called before the first frame update
    private float oldTIme;
    void Start()
    {
        Destroy(gameObject,3);
    }

    // Update is called once per frame
    
}
