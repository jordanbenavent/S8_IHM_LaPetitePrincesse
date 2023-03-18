using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectIngredients : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.IngredientCollected();
            gameObject.SetActive(false);
        }
    }
}

