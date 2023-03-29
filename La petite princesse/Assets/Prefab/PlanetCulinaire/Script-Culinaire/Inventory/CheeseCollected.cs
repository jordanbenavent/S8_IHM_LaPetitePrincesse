using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseCollected : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Inventory playerInventory = other.GetComponent<Inventory>();

        if (playerInventory != null)
        {
            playerInventory.IngredientCollected();
            playerInventory.CheeseCollected();
            gameObject.SetActive(false);
        }
    }
}
