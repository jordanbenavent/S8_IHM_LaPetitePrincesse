using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoCollected : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Inventory playerInventory = other.GetComponent<Inventory>();

        if (playerInventory != null)
        {
            playerInventory.IngredientCollected();
            playerInventory.TomatoCollected();
            gameObject.SetActive(false);
        }
    }
}
