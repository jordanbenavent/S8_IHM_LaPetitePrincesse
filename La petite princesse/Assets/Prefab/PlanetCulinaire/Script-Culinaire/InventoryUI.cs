using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI IngredientText;

    // Start is called before the first frame update
    void Start()
    {
        IngredientText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateIngredientText(PlayerInventory playerInventory)
    {
        IngredientText.text = playerInventory.NumberOfIngredients.ToString()+"/7";
        if(playerInventory.NumberOfIngredients == 7)
        {
            IngredientText.text = "You have collected all the ingredients !";
        }
    }
}
