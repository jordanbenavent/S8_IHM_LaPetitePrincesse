using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        IngredientText.text = playerInventory.NumberOfIngredients.ToString();
        if(playerInventory.NumberOfIngredients == 4)
        {
            IngredientText.text = "You have collected all the ingredients !";
        }
    }
}
