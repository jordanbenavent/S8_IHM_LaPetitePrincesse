using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryCheeseUI : MonoBehaviour
{
    private TextMeshProUGUI CheeseText;

    // Start is called before the first frame update
    void Start()
    {
        CheeseText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCheeseText(Inventory playerInventory)
    {
        CheeseText.text = playerInventory.NumberOfCheese.ToString() + "/4";
       
    }
}
